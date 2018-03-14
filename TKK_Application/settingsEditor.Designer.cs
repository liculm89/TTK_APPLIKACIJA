namespace TKK_Application
{
    partial class settingsEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.userDBtext = new System.Windows.Forms.TextBox();
            this.userDatabaseBtn = new System.Windows.Forms.Button();
            this.selectUserDatabase = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passwdBox = new System.Windows.Forms.TextBox();
            this.programListBox = new System.Windows.Forms.TextBox();
            this.programListBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.archiveLocBox = new System.Windows.Forms.TextBox();
            this.ArchiveLocBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.deviceIDBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.selectProgramList = new System.Windows.Forms.OpenFileDialog();
            this.selectArchiveLoc = new System.Windows.Forms.FolderBrowserDialog();
            this.saveChangesBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.saveChangesBtn);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.deviceIDBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ArchiveLocBtn);
            this.groupBox1.Controls.Add(this.archiveLocBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.programListBtn);
            this.groupBox1.Controls.Add(this.programListBox);
            this.groupBox1.Controls.Add(this.passwdBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.userDatabaseBtn);
            this.groupBox1.Controls.Add(this.userDBtext);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(785, 411);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Korisničke postavke";
            // 
            // userDBtext
            // 
            this.userDBtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userDBtext.Location = new System.Drawing.Point(220, 58);
            this.userDBtext.Name = "userDBtext";
            this.userDBtext.Size = new System.Drawing.Size(461, 21);
            this.userDBtext.TabIndex = 0;
            // 
            // userDatabaseBtn
            // 
            this.userDatabaseBtn.Location = new System.Drawing.Point(696, 53);
            this.userDatabaseBtn.Name = "userDatabaseBtn";
            this.userDatabaseBtn.Size = new System.Drawing.Size(72, 29);
            this.userDatabaseBtn.TabIndex = 1;
            this.userDatabaseBtn.Text = "...";
            this.userDatabaseBtn.UseVisualStyleBackColor = true;
            this.userDatabaseBtn.Click += new System.EventHandler(this.userDatabaseBtn_Click);
            // 
            // selectUserDatabase
            // 
            this.selectUserDatabase.FileName = "*.accdb";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Popis korisnika:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(499, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lozinka :";
            // 
            // passwdBox
            // 
            this.passwdBox.Location = new System.Drawing.Point(589, 95);
            this.passwdBox.Name = "passwdBox";
            this.passwdBox.Size = new System.Drawing.Size(92, 29);
            this.passwdBox.TabIndex = 4;
            // 
            // programListBox
            // 
            this.programListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.programListBox.Location = new System.Drawing.Point(220, 172);
            this.programListBox.Name = "programListBox";
            this.programListBox.Size = new System.Drawing.Size(461, 21);
            this.programListBox.TabIndex = 5;
            // 
            // programListBtn
            // 
            this.programListBtn.Location = new System.Drawing.Point(695, 168);
            this.programListBtn.Name = "programListBtn";
            this.programListBtn.Size = new System.Drawing.Size(72, 29);
            this.programListBtn.TabIndex = 6;
            this.programListBtn.Text = "...";
            this.programListBtn.UseVisualStyleBackColor = true;
            this.programListBtn.Click += new System.EventHandler(this.programListBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Popis programa (csv):";
            // 
            // archiveLocBox
            // 
            this.archiveLocBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.archiveLocBox.Location = new System.Drawing.Point(221, 223);
            this.archiveLocBox.Name = "archiveLocBox";
            this.archiveLocBox.Size = new System.Drawing.Size(461, 21);
            this.archiveLocBox.TabIndex = 8;
            // 
            // ArchiveLocBtn
            // 
            this.ArchiveLocBtn.Location = new System.Drawing.Point(696, 218);
            this.ArchiveLocBtn.Name = "ArchiveLocBtn";
            this.ArchiveLocBtn.Size = new System.Drawing.Size(72, 29);
            this.ArchiveLocBtn.TabIndex = 9;
            this.ArchiveLocBtn.Text = "...";
            this.ArchiveLocBtn.UseVisualStyleBackColor = true;
            this.ArchiveLocBtn.Click += new System.EventHandler(this.ArchiveLocBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Lokacija arhive:";
            // 
            // deviceIDBox
            // 
            this.deviceIDBox.Location = new System.Drawing.Point(727, 268);
            this.deviceIDBox.Name = "deviceIDBox";
            this.deviceIDBox.Size = new System.Drawing.Size(40, 29);
            this.deviceIDBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(599, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "I/O device ID:";
            // 
            // comBox
            // 
            this.comBox.FormattingEnabled = true;
            this.comBox.Location = new System.Drawing.Point(681, 304);
            this.comBox.Name = "comBox";
            this.comBox.Size = new System.Drawing.Size(86, 32);
            this.comBox.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(503, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "Scanner COM port:";
            // 
            // selectProgramList
            // 
            this.selectProgramList.FileName = "*.csv";
            // 
            // saveChangesBtn
            // 
            this.saveChangesBtn.BackColor = System.Drawing.Color.LimeGreen;
            this.saveChangesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveChangesBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.saveChangesBtn.Location = new System.Drawing.Point(6, 357);
            this.saveChangesBtn.Name = "saveChangesBtn";
            this.saveChangesBtn.Size = new System.Drawing.Size(228, 48);
            this.saveChangesBtn.TabIndex = 16;
            this.saveChangesBtn.Text = "Spremi promjene";
            this.saveChangesBtn.UseVisualStyleBackColor = false;
            this.saveChangesBtn.Click += new System.EventHandler(this.saveChangesBtn_Click);
            // 
            // settingsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(809, 436);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "settingsEditor";
            this.Text = "Postavke aplikacije";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button userDatabaseBtn;
        private System.Windows.Forms.TextBox userDBtext;
        private System.Windows.Forms.OpenFileDialog selectUserDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwdBox;
        private System.Windows.Forms.Button programListBtn;
        private System.Windows.Forms.TextBox programListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ArchiveLocBtn;
        private System.Windows.Forms.TextBox archiveLocBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox deviceIDBox;
        private System.Windows.Forms.OpenFileDialog selectProgramList;
        private System.Windows.Forms.FolderBrowserDialog selectArchiveLoc;
        private System.Windows.Forms.Button saveChangesBtn;
    }
}