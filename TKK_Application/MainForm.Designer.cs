namespace TKK_Application
{
    partial class TKK
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TKK));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.postavkeSkeneraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postavkeSkeneraToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.instantDoCtrl1 = new Automation.BDaq.InstantDoCtrl(this.components);
            this.instantDiCtrl1 = new Automation.BDaq.InstantDiCtrl(this.components);
            this.DO1_btn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.postavkeSkeneraToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(955, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // postavkeSkeneraToolStripMenuItem
            // 
            this.postavkeSkeneraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.postavkeSkeneraToolStripMenuItem1});
            this.postavkeSkeneraToolStripMenuItem.Name = "postavkeSkeneraToolStripMenuItem";
            this.postavkeSkeneraToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.postavkeSkeneraToolStripMenuItem.Text = "Postavke";
            // 
            // postavkeSkeneraToolStripMenuItem1
            // 
            this.postavkeSkeneraToolStripMenuItem1.Name = "postavkeSkeneraToolStripMenuItem1";
            this.postavkeSkeneraToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.postavkeSkeneraToolStripMenuItem1.Text = "Parametri skenera";
            this.postavkeSkeneraToolStripMenuItem1.Click += new System.EventHandler(this.postavkeSkeneraToolStripMenuItem1_Click);
            // 
            // instantDoCtrl1
            // 
            this.instantDoCtrl1._StateStream = ((Automation.BDaq.DeviceStateStreamer)(resources.GetObject("instantDoCtrl1._StateStream")));
            // 
            // instantDiCtrl1
            // 
            this.instantDiCtrl1._StateStream = ((Automation.BDaq.DeviceStateStreamer)(resources.GetObject("instantDiCtrl1._StateStream")));
            // 
            // DO1_btn
            // 
            this.DO1_btn.Location = new System.Drawing.Point(102, 144);
            this.DO1_btn.Name = "DO1_btn";
            this.DO1_btn.Size = new System.Drawing.Size(59, 41);
            this.DO1_btn.TabIndex = 1;
            this.DO1_btn.Text = "DO1";
            this.DO1_btn.UseVisualStyleBackColor = true;
            this.DO1_btn.Click += new System.EventHandler(this.DO1_btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(102, 118);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // TKK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 441);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.DO1_btn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TKK";
            this.Text = "TKK";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem postavkeSkeneraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postavkeSkeneraToolStripMenuItem1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Automation.BDaq.InstantDoCtrl instantDoCtrl1;
        private Automation.BDaq.InstantDiCtrl instantDiCtrl1;
        private System.Windows.Forms.Button DO1_btn;
        private System.Windows.Forms.TextBox textBox1;
    }
}

