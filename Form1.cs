using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MySQL2SQLite
{
    public partial class Form1 : Form
    {
        MySqlConnection link;
        SQLiteConnection sqlite;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string host = "localhost";
            string user = "root";
            string pass = "";
            string dbname = "ace_world";
            string connect = $"server={host};database={dbname};uid={user};pwd={pass}";
            link = new MySqlConnection(connect);
            try
            {
                link.Open();
                //MessageBox.Show("Connected");
                string query = "show tables";
                SetUpSQLiteDB(dbname);
                List<string> tables = new List<string>();
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = link;
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            tables.Add(sdr.GetString(0));
                        }
                    }
                }

                // For testing...
                //tables.Clear();
                //tables.Add("weenie_properties_string");

                // Set up the Progress Bar...
                progDB.Maximum = tables.Count;
                progDB.Step = 1;
                progDB.Value = 0;

                foreach (var t in tables)
                {
                    try
                    {
                        //if (t.Contains("weenie") || t.Contains("version")) { 
                            DumpTable(t);
                        //}
                        progDB.PerformStep();
                        //MessageBox.Show("Done with " + t);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error with " + t + "\n" + ex.Message);
                    }
                }
                link.Close();
                MessageBox.Show("Done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + "Could not connect to database.");
            }
        }

        private void SetUpSQLiteDB(string dbName)
        {
            string filename = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, $"{dbName}.db");
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            sqlite = new SQLiteConnection("Data Source=" + dbName + ".db");
            sqlite.Open();
        }

        private long GetRowCount(string tableName)
        {
            //return 50;
            long count = 0;
            string query = $"select count(*) as MyCount from {tableName}";
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                cmd.Connection = link;
                count = (long)cmd.ExecuteScalar();
            }
            return count;
        }

        private void DumpTable(string table)
        {
            string CreateTable = $"DROP TABLE IF EXISTS `{table}`;\n";
            string baseInsertSQL;

            progTables.Step = 1;
            progTables.Value = 0;
            progTables.Maximum = 100;
            var TotalRows = GetRowCount(table);
            lblTable.Text = $"Processing `{table}` with {TotalRows:N0} rows...";
            this.Refresh();

            Dictionary<string, string> Fields = new Dictionary<string, string>();

            //string query = $"select * from {table} limit 50";
            string query = $"select * from {table}";
            long RowCount = 0;
            using (MySqlCommand cmd = new MySqlCommand(query))
            {

                cmd.Connection = link;
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    // Get the table defs
                    var colSchema = sdr.GetColumnSchema();
                    CreateTable += $"CREATE TABLE IF NOT EXISTS `{table}` (";
                    baseInsertSQL = $"INSERT INTO `{table}` (";
                    for (var i = 0; i < colSchema.Count; i++)
                    {
                        var col = colSchema[i];
                        CreateTable += $"`{col.ColumnName}`";
                        baseInsertSQL += $"`{col.ColumnName}`";
                        Fields.Add(col.ColumnName, col.DataType.Name);

                        switch (col.DataType.Name)
                        {
                            case "UInt16": CreateTable += "smallint unsigned"; break;
                            case "Int16": CreateTable += "smallint"; break;
                            case "UInt32": CreateTable += " int unsigned"; break;
                            case "Int32": CreateTable += " int"; break;
                            case "SByte": CreateTable += " tinyint"; break;
                            case "Byte": CreateTable += " tinyint"; break;
                            case "DateTime": CreateTable += " datetime"; break;
                            case "String": CreateTable += " text"; break;
                            case "Single": CreateTable += " float"; break;
                            case "Double": CreateTable += " double"; break;
                            // This is how MySQL connector treats the bit() types (also true bigint)
                            case "UInt64": CreateTable += " bigint unsigned"; break;
                            case "Int64": CreateTable += " bigint"; break;
                            default:
                                var UNHANDLED = col.DataType.Name;
                                break;
                        }
                        if (i < colSchema.Count - 1)
                        {
                            CreateTable += ", \n";
                            baseInsertSQL += ", ";
                        }
                    }
                    CreateTable += ");\n\n";
                    baseInsertSQL += ") VALUES (";

                    // Finish flushing out the insert SQL
                    int counter = 0;
                    foreach (var f in Fields)
                    {
                        switch (f.Value)
                        {
                            case "__String":
                            case "__DateTime":
                                baseInsertSQL += "'@" + f.Key + "'";
                                break;
                            default:
                                baseInsertSQL += "@" + f.Key;
                                break;
                        }
                        if (counter++ < Fields.Count - 1)
                            baseInsertSQL += ", ";
                    }
                    baseInsertSQL += ")";

                    string FileName = Path.Combine("D:\\Web Development\\sqlite\\dump", $"{table}.txt");
                    File.WriteAllText(FileName, CreateTable);

                    RunSQLiteQuery(CreateTable);
                    // using filename append=false mode

                    using (SQLiteTransaction oTransaction = sqlite.BeginTransaction())
                    {
                        while (sdr.Read())
                        {
                            RowCount++;
                            AdjustTablesProgressBar(RowCount, TotalRows);
                            string sql = baseInsertSQL;
                            counter = 0;
                            var command = sqlite.CreateCommand();
                            command.Transaction = oTransaction;
                            command.CommandText = baseInsertSQL;
                            foreach (var f in Fields)
                            {
                                var atField = "@" + f.Key;
                                //command.Parameters.AddWithValue(atField, sdr.GetValue(counter));
                                command.Parameters.Add(new SQLiteParameter(atField, sdr.GetValue(counter)));
                                counter++;
                            }
                            try
                            {
                                command.ExecuteNonQuery();
                                //RunSQLiteQuery(sql);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(sql);
                            }
                        }
                        oTransaction.Commit();
                    }
                }
            }
        }

        void AdjustTablesProgressBar(long current, long total)
        {
            double percDone = ((double)current / (double)total) * 100.0;
            if (percDone > progTables.Value)
            {
               // while (progTables.Value < percDone)
                    progTables.PerformStep();
            }
        }

        void RunSQLiteQuery(string sql)
        {
            if (sql == null) return;
            var command = sqlite.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

    }
}