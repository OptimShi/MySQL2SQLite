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
            button1 = new Button();
            progDB = new ProgressBar();
            progTables = new ProgressBar();
            lblTable = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(65, 79);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progDB
            // 
            progDB.Dock = DockStyle.Bottom;
            progDB.Location = new Point(0, 416);
            progDB.Name = "progDB";
            progDB.Size = new Size(800, 34);
            progDB.TabIndex = 1;
            // 
            // progTables
            // 
            progTables.Dock = DockStyle.Bottom;
            progTables.Location = new Point(0, 382);
            progTables.Name = "progTables";
            progTables.Size = new Size(800, 34);
            progTables.TabIndex = 2;
            // 
            // lblTable
            // 
            lblTable.AutoSize = true;
            lblTable.Location = new Point(12, 354);
            lblTable.Name = "lblTable";
            lblTable.Size = new Size(59, 25);
            lblTable.TabIndex = 3;
            lblTable.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTable);
            Controls.Add(progTables);
            Controls.Add(progDB);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ProgressBar progDB;
        private ProgressBar progTables;
        private Label lblTable;
    }
}