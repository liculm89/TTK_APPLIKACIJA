namespace TKK_Application
{
    partial class UserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.btnStartAuto = new System.Windows.Forms.Button();
            this.btnStopAuto = new System.Windows.Forms.Button();
            this.startSep1 = new System.Windows.Forms.Button();
            this.stopSep1 = new System.Windows.Forms.Button();
            this.startSep2 = new System.Windows.Forms.Button();
            this.stopSep2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sep1LabelStatus = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.transpLabelStatus = new System.Windows.Forms.Label();
            this.rotationLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sep2LabelStatus = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.scannerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.UserNameLbl = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.guiTimer = new System.Windows.Forms.Timer(this.components);
            this.inputStats = new System.Windows.Forms.Label();
            this.inputStats1 = new System.Windows.Forms.Label();
            this.outputStats = new System.Windows.Forms.Label();
            this.materialBox = new System.Windows.Forms.TextBox();
            this.losBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.signalLight = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.sep1SignalLight = new System.Windows.Forms.PictureBox();
            this.transpSignalLight = new System.Windows.Forms.PictureBox();
            this.sep2SignalLight = new System.Windows.Forms.PictureBox();
            this.inputConfirm = new System.Windows.Forms.Button();
            this.inputClear = new System.Windows.Forms.Button();
            this.btn_ispON = new System.Windows.Forms.Button();
            this.MotorStopbtn = new System.Windows.Forms.Button();
            this.MotorREVbtn = new System.Windows.Forms.Button();
            this.MotorFWDbtn = new System.Windows.Forms.Button();
            this.btn_ispOFF = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signalLight)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sep1SignalLight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transpSignalLight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sep2SignalLight)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartAuto
            // 
            this.btnStartAuto.BackColor = System.Drawing.Color.LimeGreen;
            this.btnStartAuto.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnStartAuto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnStartAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStartAuto.Location = new System.Drawing.Point(19, 242);
            this.btnStartAuto.Name = "btnStartAuto";
            this.btnStartAuto.Size = new System.Drawing.Size(170, 60);
            this.btnStartAuto.TabIndex = 17;
            this.btnStartAuto.Text = "START AUTO";
            this.btnStartAuto.UseVisualStyleBackColor = false;
            this.btnStartAuto.Click += new System.EventHandler(this.btnStartAuto_Click);
            // 
            // btnStopAuto
            // 
            this.btnStopAuto.BackColor = System.Drawing.Color.Red;
            this.btnStopAuto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStopAuto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStopAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStopAuto.Location = new System.Drawing.Point(195, 242);
            this.btnStopAuto.Name = "btnStopAuto";
            this.btnStopAuto.Size = new System.Drawing.Size(166, 60);
            this.btnStopAuto.TabIndex = 28;
            this.btnStopAuto.Text = "STOP AUTO";
            this.btnStopAuto.UseVisualStyleBackColor = false;
            this.btnStopAuto.Click += new System.EventHandler(this.btnStopAuto_Click);
            // 
            // startSep1
            // 
            this.startSep1.BackColor = System.Drawing.Color.LimeGreen;
            this.startSep1.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.startSep1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.startSep1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startSep1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startSep1.Location = new System.Drawing.Point(19, 313);
            this.startSep1.Name = "startSep1";
            this.startSep1.Size = new System.Drawing.Size(110, 50);
            this.startSep1.TabIndex = 35;
            this.startSep1.Text = "Start separator 1.";
            this.startSep1.UseVisualStyleBackColor = false;
            this.startSep1.Click += new System.EventHandler(this.startSep1_Click);
            // 
            // stopSep1
            // 
            this.stopSep1.BackColor = System.Drawing.Color.Red;
            this.stopSep1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stopSep1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stopSep1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopSep1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stopSep1.Location = new System.Drawing.Point(19, 369);
            this.stopSep1.Name = "stopSep1";
            this.stopSep1.Size = new System.Drawing.Size(110, 51);
            this.stopSep1.TabIndex = 36;
            this.stopSep1.Text = "Stop separator 1.";
            this.stopSep1.UseVisualStyleBackColor = false;
            this.stopSep1.Click += new System.EventHandler(this.stopSep1_Click);
            // 
            // startSep2
            // 
            this.startSep2.BackColor = System.Drawing.Color.LimeGreen;
            this.startSep2.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.startSep2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.startSep2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startSep2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startSep2.Location = new System.Drawing.Point(251, 313);
            this.startSep2.Name = "startSep2";
            this.startSep2.Size = new System.Drawing.Size(110, 50);
            this.startSep2.TabIndex = 37;
            this.startSep2.Text = "Start separator 2.";
            this.startSep2.UseVisualStyleBackColor = false;
            this.startSep2.Click += new System.EventHandler(this.startSep2_Click);
            // 
            // stopSep2
            // 
            this.stopSep2.BackColor = System.Drawing.Color.Red;
            this.stopSep2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stopSep2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stopSep2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopSep2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stopSep2.Location = new System.Drawing.Point(251, 370);
            this.stopSep2.Name = "stopSep2";
            this.stopSep2.Size = new System.Drawing.Size(110, 52);
            this.stopSep2.TabIndex = 38;
            this.stopSep2.Text = "Stop separator 2.";
            this.stopSep2.UseVisualStyleBackColor = false;
            this.stopSep2.Click += new System.EventHandler(this.stopSep2_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.sep1SignalLight);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.sep1LabelStatus);
            this.panel3.Location = new System.Drawing.Point(665, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(275, 90);
            this.panel3.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(50, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
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
            // sep1LabelStatus
            // 
            this.sep1LabelStatus.AutoSize = true;
            this.sep1LabelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sep1LabelStatus.Location = new System.Drawing.Point(110, 45);
            this.sep1LabelStatus.Name = "sep1LabelStatus";
            this.sep1LabelStatus.Size = new System.Drawing.Size(71, 20);
            this.sep1LabelStatus.TabIndex = 3;
            this.sep1LabelStatus.Text = "READY";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.transpSignalLight);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.transpLabelStatus);
            this.panel4.Controls.Add(this.rotationLabel);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(665, 112);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(275, 120);
            this.panel4.TabIndex = 41;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(50, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "STATUS:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(3, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(181, 25);
            this.label10.TabIndex = 7;
            this.label10.Text = "TRANSPORTER";
            // 
            // transpLabelStatus
            // 
            this.transpLabelStatus.AutoSize = true;
            this.transpLabelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.transpLabelStatus.Location = new System.Drawing.Point(110, 45);
            this.transpLabelStatus.Name = "transpLabelStatus";
            this.transpLabelStatus.Size = new System.Drawing.Size(71, 20);
            this.transpLabelStatus.TabIndex = 8;
            this.transpLabelStatus.Text = "READY";
            // 
            // rotationLabel
            // 
            this.rotationLabel.AutoSize = true;
            this.rotationLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rotationLabel.Location = new System.Drawing.Point(222, 91);
            this.rotationLabel.Name = "rotationLabel";
            this.rotationLabel.Size = new System.Drawing.Size(2, 15);
            this.rotationLabel.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Odabrani smjer vrtnje motora:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.sep2SignalLight);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.sep2LabelStatus);
            this.panel5.Location = new System.Drawing.Point(665, 242);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(275, 90);
            this.panel5.TabIndex = 42;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(50, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "STATUS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "SEPARATOR 2.";
            // 
            // sep2LabelStatus
            // 
            this.sep2LabelStatus.AutoSize = true;
            this.sep2LabelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sep2LabelStatus.Location = new System.Drawing.Point(110, 45);
            this.sep2LabelStatus.Name = "sep2LabelStatus";
            this.sep2LabelStatus.Size = new System.Drawing.Size(71, 20);
            this.sep2LabelStatus.TabIndex = 4;
            this.sep2LabelStatus.Text = "READY";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FloralWhite;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.scannerStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 478);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(954, 24);
            this.statusStrip1.TabIndex = 43;
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
            // UserNameLbl
            // 
            this.UserNameLbl.AutoSize = true;
            this.UserNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UserNameLbl.Location = new System.Drawing.Point(13, 13);
            this.UserNameLbl.Name = "UserNameLbl";
            this.UserNameLbl.Size = new System.Drawing.Size(65, 24);
            this.UserNameLbl.TabIndex = 44;
            this.UserNameLbl.Text = "USER";
            this.UserNameLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStatus.Location = new System.Drawing.Point(137, 203);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(99, 29);
            this.lblStatus.TabIndex = 45;
            this.lblStatus.Text = "READY";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(32, 296);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(165, 20);
            this.textBox1.TabIndex = 46;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 322);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 47;
            this.button1.Text = "Test csv";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // guiTimer
            // 
            this.guiTimer.Tick += new System.EventHandler(this.guiTimer_Tick);
            // 
            // inputStats
            // 
            this.inputStats.AutoSize = true;
            this.inputStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.inputStats.Location = new System.Drawing.Point(63, 351);
            this.inputStats.Name = "inputStats";
            this.inputStats.Size = new System.Drawing.Size(90, 24);
            this.inputStats.TabIndex = 49;
            this.inputStats.Text = "Input Ch0";
            // 
            // inputStats1
            // 
            this.inputStats1.AutoSize = true;
            this.inputStats1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.inputStats1.Location = new System.Drawing.Point(63, 382);
            this.inputStats1.Name = "inputStats1";
            this.inputStats1.Size = new System.Drawing.Size(90, 24);
            this.inputStats1.TabIndex = 50;
            this.inputStats1.Text = "Input Ch1";
            // 
            // outputStats
            // 
            this.outputStats.AutoSize = true;
            this.outputStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.outputStats.Location = new System.Drawing.Point(55, 427);
            this.outputStats.Name = "outputStats";
            this.outputStats.Size = new System.Drawing.Size(105, 24);
            this.outputStats.TabIndex = 51;
            this.outputStats.Text = "Output Ch0";
            // 
            // materialBox
            // 
            this.materialBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.materialBox.Location = new System.Drawing.Point(29, 39);
            this.materialBox.Name = "materialBox";
            this.materialBox.Size = new System.Drawing.Size(205, 26);
            this.materialBox.TabIndex = 53;
            // 
            // losBox
            // 
            this.losBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.losBox.Location = new System.Drawing.Point(29, 94);
            this.losBox.Name = "losBox";
            this.losBox.Size = new System.Drawing.Size(205, 26);
            this.losBox.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(25, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 55;
            this.label3.Text = "Materijal";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(28, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 56;
            this.label7.Text = "Los br.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackgroundImage = global::TKK_Application.Properties.Resources.sinel_logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(632, 419);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(322, 58);
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // signalLight
            // 
            this.signalLight.Location = new System.Drawing.Point(112, 50);
            this.signalLight.Name = "signalLight";
            this.signalLight.Size = new System.Drawing.Size(150, 150);
            this.signalLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.signalLight.TabIndex = 39;
            this.signalLight.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "glossy-green-button-2400px.png");
            this.imageList1.Images.SetKeyName(1, "glossy-yellow-button-2400px.png");
            this.imageList1.Images.SetKeyName(2, "glossy-red-button-2400px.png");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.inputClear);
            this.panel1.Controls.Add(this.inputConfirm);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.outputStats);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.inputStats1);
            this.panel1.Controls.Add(this.materialBox);
            this.panel1.Controls.Add(this.inputStats);
            this.panel1.Controls.Add(this.losBox);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(373, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 477);
            this.panel1.TabIndex = 57;
            // 
            // sep1SignalLight
            // 
            this.sep1SignalLight.Location = new System.Drawing.Point(200, 15);
            this.sep1SignalLight.Name = "sep1SignalLight";
            this.sep1SignalLight.Size = new System.Drawing.Size(50, 50);
            this.sep1SignalLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sep1SignalLight.TabIndex = 5;
            this.sep1SignalLight.TabStop = false;
            // 
            // transpSignalLight
            // 
            this.transpSignalLight.Location = new System.Drawing.Point(200, 15);
            this.transpSignalLight.Name = "transpSignalLight";
            this.transpSignalLight.Size = new System.Drawing.Size(50, 50);
            this.transpSignalLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.transpSignalLight.TabIndex = 58;
            this.transpSignalLight.TabStop = false;
            // 
            // sep2SignalLight
            // 
            this.sep2SignalLight.Location = new System.Drawing.Point(200, 15);
            this.sep2SignalLight.Name = "sep2SignalLight";
            this.sep2SignalLight.Size = new System.Drawing.Size(50, 50);
            this.sep2SignalLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sep2SignalLight.TabIndex = 59;
            this.sep2SignalLight.TabStop = false;
            // 
            // inputConfirm
            // 
            this.inputConfirm.BackColor = System.Drawing.Color.LimeGreen;
            this.inputConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inputConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.inputConfirm.Location = new System.Drawing.Point(3, 137);
            this.inputConfirm.Name = "inputConfirm";
            this.inputConfirm.Size = new System.Drawing.Size(129, 50);
            this.inputConfirm.TabIndex = 57;
            this.inputConfirm.Text = "Potvrdi";
            this.inputConfirm.UseVisualStyleBackColor = false;
            this.inputConfirm.Click += new System.EventHandler(this.inputConfirm_Click);
            // 
            // inputClear
            // 
            this.inputClear.BackColor = System.Drawing.Color.Red;
            this.inputClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inputClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.inputClear.Location = new System.Drawing.Point(138, 136);
            this.inputClear.Name = "inputClear";
            this.inputClear.Size = new System.Drawing.Size(121, 51);
            this.inputClear.TabIndex = 58;
            this.inputClear.Text = "Poništi";
            this.inputClear.UseVisualStyleBackColor = false;
            this.inputClear.Click += new System.EventHandler(this.inputClear_Click);
            // 
            // btn_ispON
            // 
            this.btn_ispON.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_ispON.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btn_ispON.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_ispON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ispON.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_ispON.Location = new System.Drawing.Point(135, 313);
            this.btn_ispON.Name = "btn_ispON";
            this.btn_ispON.Size = new System.Drawing.Size(110, 50);
            this.btn_ispON.TabIndex = 61;
            this.btn_ispON.Text = "Ispuhivanje ON";
            this.btn_ispON.UseVisualStyleBackColor = false;
            // 
            // MotorStopbtn
            // 
            this.MotorStopbtn.BackColor = System.Drawing.Color.Red;
            this.MotorStopbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MotorStopbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MotorStopbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MotorStopbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MotorStopbtn.Location = new System.Drawing.Point(135, 425);
            this.MotorStopbtn.Name = "MotorStopbtn";
            this.MotorStopbtn.Size = new System.Drawing.Size(110, 50);
            this.MotorStopbtn.TabIndex = 60;
            this.MotorStopbtn.Text = "Motor Stop";
            this.MotorStopbtn.UseVisualStyleBackColor = false;
            // 
            // MotorREVbtn
            // 
            this.MotorREVbtn.BackColor = System.Drawing.Color.LimeGreen;
            this.MotorREVbtn.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.MotorREVbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.MotorREVbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MotorREVbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MotorREVbtn.Location = new System.Drawing.Point(251, 425);
            this.MotorREVbtn.Name = "MotorREVbtn";
            this.MotorREVbtn.Size = new System.Drawing.Size(110, 50);
            this.MotorREVbtn.TabIndex = 59;
            this.MotorREVbtn.Text = "Motor REV";
            this.MotorREVbtn.UseVisualStyleBackColor = false;
            // 
            // MotorFWDbtn
            // 
            this.MotorFWDbtn.BackColor = System.Drawing.Color.LimeGreen;
            this.MotorFWDbtn.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.MotorFWDbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.MotorFWDbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MotorFWDbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MotorFWDbtn.Location = new System.Drawing.Point(19, 425);
            this.MotorFWDbtn.Name = "MotorFWDbtn";
            this.MotorFWDbtn.Size = new System.Drawing.Size(110, 50);
            this.MotorFWDbtn.TabIndex = 58;
            this.MotorFWDbtn.Text = "Motor FWD";
            this.MotorFWDbtn.UseVisualStyleBackColor = false;
            // 
            // btn_ispOFF
            // 
            this.btn_ispOFF.BackColor = System.Drawing.Color.Red;
            this.btn_ispOFF.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_ispOFF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_ispOFF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ispOFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_ispOFF.Location = new System.Drawing.Point(135, 367);
            this.btn_ispOFF.Name = "btn_ispOFF";
            this.btn_ispOFF.Size = new System.Drawing.Size(110, 52);
            this.btn_ispOFF.TabIndex = 62;
            this.btn_ispOFF.Text = "Ispuhivanje OFF";
            this.btn_ispOFF.UseVisualStyleBackColor = false;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(954, 502);
            this.Controls.Add(this.btn_ispOFF);
            this.Controls.Add(this.btn_ispON);
            this.Controls.Add(this.MotorStopbtn);
            this.Controls.Add(this.MotorREVbtn);
            this.Controls.Add(this.MotorFWDbtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.UserNameLbl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.signalLight);
            this.Controls.Add(this.startSep1);
            this.Controls.Add(this.stopSep1);
            this.Controls.Add(this.startSep2);
            this.Controls.Add(this.stopSep2);
            this.Controls.Add(this.btnStopAuto);
            this.Controls.Add(this.btnStartAuto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(970, 540);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserForm_FormClosing);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signalLight)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sep1SignalLight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transpSignalLight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sep2SignalLight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartAuto;
        private System.Windows.Forms.Button btnStopAuto;
        private System.Windows.Forms.Button startSep1;
        private System.Windows.Forms.Button stopSep1;
        private System.Windows.Forms.Button startSep2;
        private System.Windows.Forms.Button stopSep2;
        private System.Windows.Forms.PictureBox signalLight;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sep1LabelStatus;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label transpLabelStatus;
        private System.Windows.Forms.Label rotationLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label sep2LabelStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel scannerStatus;
        private System.Windows.Forms.Label UserNameLbl;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer guiTimer;
        private System.Windows.Forms.Label inputStats;
        private System.Windows.Forms.Label inputStats1;
        private System.Windows.Forms.Label outputStats;
        private System.Windows.Forms.TextBox materialBox;
        private System.Windows.Forms.TextBox losBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox sep1SignalLight;
        private System.Windows.Forms.PictureBox transpSignalLight;
        private System.Windows.Forms.PictureBox sep2SignalLight;
        private System.Windows.Forms.Button inputClear;
        private System.Windows.Forms.Button inputConfirm;
        private System.Windows.Forms.Button btn_ispON;
        private System.Windows.Forms.Button MotorStopbtn;
        private System.Windows.Forms.Button MotorREVbtn;
        private System.Windows.Forms.Button MotorFWDbtn;
        private System.Windows.Forms.Button btn_ispOFF;
    }
}