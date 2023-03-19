namespace MySQL2SQLite
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnConvert = new Button();
            progDB = new ProgressBar();
            progTables = new ProgressBar();
            lblTable = new Label();
            saveDlgSQLite = new SaveFileDialog();
            label2 = new Label();
            txtHost = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtDatabase = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(295, 227);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(112, 34);
            btnConvert.TabIndex = 0;
            btnConvert.Text = "Convert";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += button1_Click;
            // 
            // progDB
            // 
            progDB.Dock = DockStyle.Bottom;
            progDB.Location = new Point(0, 370);
            progDB.Name = "progDB";
            progDB.Size = new Size(502, 34);
            progDB.TabIndex = 1;
            // 
            // progTables
            // 
            progTables.Dock = DockStyle.Bottom;
            progTables.Location = new Point(0, 336);
            progTables.Name = "progTables";
            progTables.Size = new Size(502, 34);
            progTables.TabIndex = 2;
            // 
            // lblTable
            // 
            lblTable.AutoSize = true;
            lblTable.Location = new Point(12, 299);
            lblTable.Name = "lblTable";
            lblTable.Size = new Size(71, 25);
            lblTable.TabIndex = 3;
            lblTable.Text = "lblTable";
            // 
            // saveDlgSQLite
            // 
            saveDlgSQLite.DefaultExt = "db";
            saveDlgSQLite.Filter = "SQLite DB|*.db|All Files|*.*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 57);
            label2.Name = "label2";
            label2.Size = new Size(82, 25);
            label2.TabIndex = 5;
            label2.Text = "DB Host:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtHost
            // 
            txtHost.Location = new Point(157, 54);
            txtHost.Name = "txtHost";
            txtHost.Size = new Size(250, 31);
            txtHost.TabIndex = 6;
            txtHost.Text = "127.0.0.1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 97);
            label3.Name = "label3";
            label3.Size = new Size(95, 25);
            label3.TabIndex = 7;
            label3.Text = "Username:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(59, 134);
            label4.Name = "label4";
            label4.Size = new Size(91, 25);
            label4.TabIndex = 8;
            label4.Text = "Password:";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(60, 173);
            label6.Name = "label6";
            label6.Size = new Size(90, 25);
            label6.TabIndex = 10;
            label6.Text = "Database:";
            label6.TextAlign = ContentAlignment.TopRight;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(157, 94);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(250, 31);
            txtUsername.TabIndex = 11;
            txtUsername.Text = "root";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(157, 131);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 31);
            txtPassword.TabIndex = 11;
            // 
            // txtDatabase
            // 
            txtDatabase.Location = new Point(157, 170);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new Size(250, 31);
            txtDatabase.TabIndex = 11;
            txtDatabase.Text = "ace_world";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(132, 9);
            label5.Name = "label5";
            label5.Size = new Size(222, 32);
            label5.TabIndex = 13;
            label5.Text = "MySQL Information";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 404);
            Controls.Add(label5);
            Controls.Add(txtDatabase);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtHost);
            Controls.Add(label2);
            Controls.Add(lblTable);
            Controls.Add(progTables);
            Controls.Add(progDB);
            Controls.Add(btnConvert);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "MySQL2SQLite";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConvert;
        private ProgressBar progDB;
        private ProgressBar progTables;
        private Label lblTable;
        private SaveFileDialog saveDlgSQLite;
        private Label label2;
        private TextBox txtHost;
        private Label label3;
        private Label label4;
        private Label label6;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtDatabase;
        private Label label5;
    }
}