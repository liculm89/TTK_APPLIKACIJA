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
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusIOModulaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.instantDoCtrl1 = new Automation.BDaq.InstantDoCtrl(this.components);
            this.instantDiCtrl1 = new Automation.BDaq.InstantDiCtrl(this.components);
            this.DO1_btn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.scannerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rotationLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.csvSelectFile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.scannedCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.connScanner = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel_debug = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.inputsStatus = new System.Windows.Forms.TextBox();
            this.ostatustext = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.inputStatus1 = new System.Windows.Forms.TextBox();
            this.btnStopAuto = new System.Windows.Forms.Button();
            this.btnStartAuto = new System.Windows.Forms.Button();
            this.panel_manual = new System.Windows.Forms.Panel();
            this.btn_ispOFF = new System.Windows.Forms.Button();
            this.btn_ispON = new System.Windows.Forms.Button();
            this.startSep1 = new System.Windows.Forms.Button();
            this.MotorStop = new System.Windows.Forms.Button();
            this.stopSep1 = new System.Windows.Forms.Button();
            this.MotorREV = new System.Windows.Forms.Button();
            this.startSep2 = new System.Windows.Forms.Button();
            this.MotorFWD = new System.Windows.Forms.Button();
            this.stopSep2 = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lightReady = new System.Windows.Forms.PictureBox();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.timer_auto = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel_debug.SuspendLayout();
            this.panel_manual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lightReady)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.postavkeSkeneraToolStripMenuItem,
            this.statusToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1105, 24);
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
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusIOModulaToolStripMenuItem});
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.statusToolStripMenuItem.Text = "Status";
            // 
            // statusIOModulaToolStripMenuItem
            // 
            this.statusIOModulaToolStripMenuItem.Name = "statusIOModulaToolStripMenuItem";
            this.statusIOModulaToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.statusIOModulaToolStripMenuItem.Text = "Status I/O modula";
            this.statusIOModulaToolStripMenuItem.Click += new System.EventHandler(this.statusIOModulaToolStripMenuItem_Click);
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
            this.DO1_btn.Location = new System.Drawing.Point(237, 50);
            this.DO1_btn.Name = "DO1_btn";
            this.DO1_btn.Size = new System.Drawing.Size(100, 38);
            this.DO1_btn.TabIndex = 1;
            this.DO1_btn.Text = "Set Ouput";
            this.DO1_btn.UseVisualStyleBackColor = true;
            this.DO1_btn.Click += new System.EventHandler(this.DO1_btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(190, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(41, 20);
            this.textBox1.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.scannerStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 562);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1105, 24);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 19);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // scannerStatus
            // 
            this.scannerStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.scannerStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.scannerStatus.Name = "scannerStatus";
            this.scannerStatus.Size = new System.Drawing.Size(122, 19);
            this.scannerStatus.Text = "toolStripStatusLabel2";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.panel1.Location = new System.Drawing.Point(783, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 528);
            this.panel1.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.PowderBlue;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(23, 274);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(275, 103);
            this.panel5.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 20);
            this.label13.TabIndex = 9;
            this.label13.Text = "STATUS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "SEPARATOR 2.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(90, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "READY";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.PowderBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.rotationLabel);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(23, 123);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(275, 120);
            this.panel4.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 20);
            this.label12.TabIndex = 5;
            this.label12.Text = "STATUS:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(181, 25);
            this.label10.TabIndex = 7;
            this.label10.Text = "TRANSPORTER";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(90, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "READY";
            // 
            // rotationLabel
            // 
            this.rotationLabel.AutoSize = true;
            this.rotationLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rotationLabel.Location = new System.Drawing.Point(222, 91);
            this.rotationLabel.Name = "rotationLabel";
            this.rotationLabel.Size = new System.Drawing.Size(2, 22);
            this.rotationLabel.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Odabrani smjer vrtnje motora:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PowderBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(23, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(275, 90);
            this.panel3.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "STATUS:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "SEPARATOR 1.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "READY";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = global::TKK_Application.Properties.Resources.sinel_logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 470);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(322, 58);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView1.Size = new System.Drawing.Size(402, 416);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "*.csv";
            // 
            // csvSelectFile
            // 
            this.csvSelectFile.Location = new System.Drawing.Point(22, 481);
            this.csvSelectFile.Name = "csvSelectFile";
            this.csvSelectFile.Size = new System.Drawing.Size(179, 47);
            this.csvSelectFile.TabIndex = 6;
            this.csvSelectFile.Text = "Odaberi CSV File";
            this.csvSelectFile.UseVisualStyleBackColor = true;
            this.csvSelectFile.Click += new System.EventHandler(this.csvSelectFile_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 481);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 47);
            this.button1.TabIndex = 7;
            this.button1.Text = "Osvježi tabelu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // scannedCode
            // 
            this.scannedCode.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.scannedCode.Location = new System.Drawing.Point(150, 20);
            this.scannedCode.Name = "scannedCode";
            this.scannedCode.Size = new System.Drawing.Size(203, 26);
            this.scannedCode.TabIndex = 8;
            this.scannedCode.TextChanged += new System.EventHandler(this.scannedCode_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Očitani Barcode:";
            // 
            // connScanner
            // 
            this.connScanner.Location = new System.Drawing.Point(217, 6);
            this.connScanner.Name = "connScanner";
            this.connScanner.Size = new System.Drawing.Size(122, 38);
            this.connScanner.TabIndex = 10;
            this.connScanner.Text = "Scanner";
            this.connScanner.UseVisualStyleBackColor = true;
            this.connScanner.Click += new System.EventHandler(this.connScanner_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.csvSelectFile);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.scannedCode);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.panel2.Location = new System.Drawing.Point(349, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(438, 528);
            this.panel2.TabIndex = 13;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "glossy-darkgray-button-2400px.png");
            this.imageList1.Images.SetKeyName(1, "glossy-green-button-2400px.png");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "glossy-darkgray-button-2400px.png");
            this.imageList2.Images.SetKeyName(1, "glossy-red-button-2400px(2).png");
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panel8.Controls.Add(this.panel_debug);
            this.panel8.Controls.Add(this.btnStopAuto);
            this.panel8.Controls.Add(this.btnStartAuto);
            this.panel8.Controls.Add(this.panel_manual);
            this.panel8.Controls.Add(this.lblStatus);
            this.panel8.Controls.Add(this.lightReady);
            this.panel8.Location = new System.Drawing.Point(0, 31);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(348, 528);
            this.panel8.TabIndex = 23;
            // 
            // panel_debug
            // 
            this.panel_debug.Controls.Add(this.label8);
            this.panel_debug.Controls.Add(this.textBox1);
            this.panel_debug.Controls.Add(this.DO1_btn);
            this.panel_debug.Controls.Add(this.connScanner);
            this.panel_debug.Controls.Add(this.inputsStatus);
            this.panel_debug.Controls.Add(this.ostatustext);
            this.panel_debug.Controls.Add(this.label7);
            this.panel_debug.Controls.Add(this.inputStatus1);
            this.panel_debug.Location = new System.Drawing.Point(3, 443);
            this.panel_debug.Name = "panel_debug";
            this.panel_debug.Size = new System.Drawing.Size(332, 100);
            this.panel_debug.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Status outputa";
            // 
            // inputsStatus
            // 
            this.inputsStatus.Location = new System.Drawing.Point(82, 43);
            this.inputsStatus.Name = "inputsStatus";
            this.inputsStatus.Size = new System.Drawing.Size(100, 20);
            this.inputsStatus.TabIndex = 28;
            // 
            // ostatustext
            // 
            this.ostatustext.Location = new System.Drawing.Point(82, 21);
            this.ostatustext.Name = "ostatustext";
            this.ostatustext.Size = new System.Drawing.Size(100, 20);
            this.ostatustext.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Status inputa";
            // 
            // inputStatus1
            // 
            this.inputStatus1.Location = new System.Drawing.Point(82, 69);
            this.inputStatus1.Name = "inputStatus1";
            this.inputStatus1.Size = new System.Drawing.Size(100, 20);
            this.inputStatus1.TabIndex = 30;
            // 
            // btnStopAuto
            // 
            this.btnStopAuto.BackColor = System.Drawing.Color.Red;
            this.btnStopAuto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStopAuto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStopAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStopAuto.Location = new System.Drawing.Point(175, 194);
            this.btnStopAuto.Name = "btnStopAuto";
            this.btnStopAuto.Size = new System.Drawing.Size(170, 60);
            this.btnStopAuto.TabIndex = 27;
            this.btnStopAuto.Text = "STOP AUTO";
            this.btnStopAuto.UseVisualStyleBackColor = false;
            this.btnStopAuto.Click += new System.EventHandler(this.btnStopAuto_Click);
            // 
            // btnStartAuto
            // 
            this.btnStartAuto.BackColor = System.Drawing.Color.LimeGreen;
            this.btnStartAuto.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnStartAuto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnStartAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStartAuto.Location = new System.Drawing.Point(3, 194);
            this.btnStartAuto.Name = "btnStartAuto";
            this.btnStartAuto.Size = new System.Drawing.Size(170, 60);
            this.btnStartAuto.TabIndex = 16;
            this.btnStartAuto.Text = "START AUTO";
            this.btnStartAuto.UseVisualStyleBackColor = false;
            this.btnStartAuto.Click += new System.EventHandler(this.btnStartAuto_Click);
            // 
            // panel_manual
            // 
            this.panel_manual.Controls.Add(this.btn_ispOFF);
            this.panel_manual.Controls.Add(this.btn_ispON);
            this.panel_manual.Controls.Add(this.startSep1);
            this.panel_manual.Controls.Add(this.MotorStop);
            this.panel_manual.Controls.Add(this.stopSep1);
            this.panel_manual.Controls.Add(this.MotorREV);
            this.panel_manual.Controls.Add(this.startSep2);
            this.panel_manual.Controls.Add(this.MotorFWD);
            this.panel_manual.Controls.Add(this.stopSep2);
            this.panel_manual.Location = new System.Drawing.Point(3, 265);
            this.panel_manual.Name = "panel_manual";
            this.panel_manual.Size = new System.Drawing.Size(340, 171);
            this.panel_manual.TabIndex = 40;
            // 
            // btn_ispOFF
            // 
            this.btn_ispOFF.BackColor = System.Drawing.Color.Red;
            this.btn_ispOFF.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_ispOFF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_ispOFF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ispOFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_ispOFF.Location = new System.Drawing.Point(119, 117);
            this.btn_ispOFF.Name = "btn_ispOFF";
            this.btn_ispOFF.Size = new System.Drawing.Size(100, 52);
            this.btn_ispOFF.TabIndex = 39;
            this.btn_ispOFF.Text = "Ispuhivanje OFF";
            this.btn_ispOFF.UseVisualStyleBackColor = false;
            this.btn_ispOFF.Click += new System.EventHandler(this.btn_ispOFF_Click);
            // 
            // btn_ispON
            // 
            this.btn_ispON.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_ispON.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btn_ispON.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_ispON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ispON.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_ispON.Location = new System.Drawing.Point(119, 61);
            this.btn_ispON.Name = "btn_ispON";
            this.btn_ispON.Size = new System.Drawing.Size(100, 50);
            this.btn_ispON.TabIndex = 38;
            this.btn_ispON.Text = "Ispuhivanje ON";
            this.btn_ispON.UseVisualStyleBackColor = false;
            this.btn_ispON.Click += new System.EventHandler(this.btn_ispON_Click);
            // 
            // startSep1
            // 
            this.startSep1.BackColor = System.Drawing.Color.LimeGreen;
            this.startSep1.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.startSep1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.startSep1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startSep1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startSep1.Location = new System.Drawing.Point(3, 61);
            this.startSep1.Name = "startSep1";
            this.startSep1.Size = new System.Drawing.Size(110, 50);
            this.startSep1.TabIndex = 31;
            this.startSep1.Text = "Start separator 1.";
            this.startSep1.UseVisualStyleBackColor = false;
            this.startSep1.Click += new System.EventHandler(this.button2_Click);
            // 
            // MotorStop
            // 
            this.MotorStop.BackColor = System.Drawing.Color.Red;
            this.MotorStop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MotorStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MotorStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MotorStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MotorStop.Location = new System.Drawing.Point(119, 5);
            this.MotorStop.Name = "MotorStop";
            this.MotorStop.Size = new System.Drawing.Size(100, 50);
            this.MotorStop.TabIndex = 37;
            this.MotorStop.Text = "Motor Stop";
            this.MotorStop.UseVisualStyleBackColor = false;
            this.MotorStop.Click += new System.EventHandler(this.button8_Click);
            // 
            // stopSep1
            // 
            this.stopSep1.BackColor = System.Drawing.Color.Red;
            this.stopSep1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stopSep1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stopSep1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopSep1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stopSep1.Location = new System.Drawing.Point(3, 117);
            this.stopSep1.Name = "stopSep1";
            this.stopSep1.Size = new System.Drawing.Size(110, 51);
            this.stopSep1.TabIndex = 32;
            this.stopSep1.Text = "Stop separator 1.";
            this.stopSep1.UseVisualStyleBackColor = false;
            this.stopSep1.Click += new System.EventHandler(this.button3_Click);
            // 
            // MotorREV
            // 
            this.MotorREV.BackColor = System.Drawing.Color.LimeGreen;
            this.MotorREV.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.MotorREV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.MotorREV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MotorREV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MotorREV.Location = new System.Drawing.Point(225, 5);
            this.MotorREV.Name = "MotorREV";
            this.MotorREV.Size = new System.Drawing.Size(110, 50);
            this.MotorREV.TabIndex = 36;
            this.MotorREV.Text = "Motor REV";
            this.MotorREV.UseVisualStyleBackColor = false;
            this.MotorREV.Click += new System.EventHandler(this.button7_Click);
            // 
            // startSep2
            // 
            this.startSep2.BackColor = System.Drawing.Color.LimeGreen;
            this.startSep2.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.startSep2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.startSep2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startSep2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startSep2.Location = new System.Drawing.Point(225, 61);
            this.startSep2.Name = "startSep2";
            this.startSep2.Size = new System.Drawing.Size(110, 50);
            this.startSep2.TabIndex = 33;
            this.startSep2.Text = "Start separator 2.";
            this.startSep2.UseVisualStyleBackColor = false;
            this.startSep2.Click += new System.EventHandler(this.button5_Click);
            // 
            // MotorFWD
            // 
            this.MotorFWD.BackColor = System.Drawing.Color.LimeGreen;
            this.MotorFWD.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.MotorFWD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.MotorFWD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MotorFWD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MotorFWD.Location = new System.Drawing.Point(3, 5);
            this.MotorFWD.Name = "MotorFWD";
            this.MotorFWD.Size = new System.Drawing.Size(110, 50);
            this.MotorFWD.TabIndex = 35;
            this.MotorFWD.Text = "Motor FWD";
            this.MotorFWD.UseVisualStyleBackColor = false;
            this.MotorFWD.Click += new System.EventHandler(this.button6_Click);
            // 
            // stopSep2
            // 
            this.stopSep2.BackColor = System.Drawing.Color.Red;
            this.stopSep2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stopSep2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stopSep2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopSep2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stopSep2.Location = new System.Drawing.Point(225, 117);
            this.stopSep2.Name = "stopSep2";
            this.stopSep2.Size = new System.Drawing.Size(110, 52);
            this.stopSep2.TabIndex = 34;
            this.stopSep2.Text = "Stop separator 2.";
            this.stopSep2.UseVisualStyleBackColor = false;
            this.stopSep2.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStatus.Location = new System.Drawing.Point(114, 156);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(99, 29);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "READY";
            // 
            // lightReady
            // 
            this.lightReady.Location = new System.Drawing.Point(90, 3);
            this.lightReady.Name = "lightReady";
            this.lightReady.Size = new System.Drawing.Size(150, 150);
            this.lightReady.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lightReady.TabIndex = 21;
            this.lightReady.TabStop = false;
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "glossy-green-button-2400px.png");
            this.imageList3.Images.SetKeyName(1, "glossy-yellow-button-2400px.png");
            this.imageList3.Images.SetKeyName(2, "glossy-red-button-2400px.png");
            // 
            // timer_auto
            // 
            this.timer_auto.Tick += new System.EventHandler(this.timer_auto_Tick);
            // 
            // TKK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 586);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1121, 624);
            this.Name = "TKK";
            this.Text = "TKK";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TKK_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel_debug.ResumeLayout(false);
            this.panel_debug.PerformLayout();
            this.panel_manual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lightReady)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusIOModulaToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel scannerStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button csvSelectFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox scannedCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button connScanner;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label rotationLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox lightReady;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStartAuto;
        private System.Windows.Forms.Button btnStopAuto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox inputsStatus;
        private System.Windows.Forms.TextBox inputStatus1;
        private System.Windows.Forms.Button stopSep2;
        private System.Windows.Forms.Button startSep2;
        private System.Windows.Forms.Button stopSep1;
        private System.Windows.Forms.Button startSep1;
        private System.Windows.Forms.Button MotorREV;
        private System.Windows.Forms.Button MotorFWD;
        private System.Windows.Forms.Button MotorStop;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ostatustext;
        private System.Windows.Forms.Panel panel_manual;
        private System.Windows.Forms.Panel panel_debug;
        private System.Windows.Forms.Button btn_ispON;
        private System.Windows.Forms.Button btn_ispOFF;
        private System.Windows.Forms.Timer timer_auto;
        private System.Windows.Forms.ImageList imageList3;
    }
}

