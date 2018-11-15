using System;
using System.Data;
using System.Linq;
using System.IO;
using Automation.BDaq;
using System.Windows.Forms;

namespace TKK_Application
{
    public partial class UserForm : Form
    {
        //public string csvFileLoc = Globals.csvInput;
        public string csvFileLoc = @"D:\N046_17 DOKUMENTACIJA I PROGRAM\PROGRAMI\Transporter.csv";
        public string COMport = Globals.scannerCOM;
        public static settingsEditor settingsEdit = new settingsEditor();
        public string exportFolder = Globals.archive_loc;
        public string operater;
        public string motorRot;

        private csvLogger processLogger = new csvLogger();
        private StopInfo infomsg;

        //private scannerControl scanner = new scannerControl();
        private PictureBox[] statusLightArr = new PictureBox[4];
        private PictureBox[] inputCh0Pics = new PictureBox[8];
        private PictureBox[] inputCh1Pics = new PictureBox[8];
        private PictureBox[] outputCh0Pics = new PictureBox[8];

        public bool inputConfirmed;
        public string[] lbl_States = { "READY", "ACTIVE", "ERROR" };

        public UserForm()
        {
            InitializeComponent();
        }

        public UserForm(string name)
        {
            InitializeComponent();

            if (!string.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                MotorFWDbtn.Hide();
                MotorREVbtn.Hide();
                MotorStopbtn.Hide();
                btn_ispOFF.Hide();
                btn_ispON.Hide();
                settingsPicBox.Hide();
                statusPanel.Hide();
            }

            operater = name;
            this.CenterToScreen();
            UserNameLbl.Text = name;
            inputConfirmed = false;
            guiTimer.Start();

            Globals.Scnr.connectScanner(COMport, 9600, 8, 110, 110);
            Globals.Scnr.Init_scanner_connection();
            scannerStatus.Text = Globals.Scnr.connectionStatus;
            Globals.Scnr.DataRec += new scannerControl.dataRecHandler(scannerDataRec);
            statusLightArr = new PictureBox[] { signalLight, sep1SignalLight, transpSignalLight, sep2SignalLight };
            inputCh0Pics = new PictureBox[] { ch0port0Pic, ch0port1Pic, ch0port2Pic, ch0port3Pic, ch0port4Pic, ch0port5Pic, ch0port6Pic, ch0port7Pic };
            inputCh1Pics = new PictureBox[] { ch1port0Pic, ch1port1Pic, ch1port2Pic, ch1port3Pic, ch1port4Pic, ch1port5Pic, ch1port6Pic, ch1port7Pic };
            outputCh0Pics = new PictureBox[] { OCh0Port0Pic, OCh0Port1Pic, OCh0Port2Pic, OCh0Port3Pic, OCh0Port4Pic, OCh0Port5Pic, OCh0Port6Pic, OCh0Port7Pic };



            Globals.IOCtrl.timerChStats.Start();
            ErrorCode errSnap = ErrorCode.Success;
            errSnap = Globals.IOCtrl.instantDiCtrl1.SnapStart();
            if (errSnap != ErrorCode.Success)
            {
                Globals.IOCtrl.HandleError(errSnap);
            }
            else
            {
                Globals.pCol.writeLog(0, "SnapStart active", operater);
            }
            Globals.pCol.writeLog(0, "User logged in", operater);

            //

        }

        public void scannerDataRec(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate
                {
                    if (string.IsNullOrWhiteSpace(materialBox.Text))
                    {
                        materialBox.Text = Globals.Scnr.result.Trim();
                    }
                    else if (string.IsNullOrWhiteSpace(losBox.Text))
                    {
                        losBox.Text = Globals.Scnr.result.Trim();
                    }
                }));
            }
        }

        public string SearchCsv(string ScannedCode)
        {
            string res;
            res = "0";
            var lines = File.ReadLines(csvFileLoc);
            foreach (var line in lines)
            {
                var resline = line.Split(new char[] { ';' });
                if (resline[1] == ScannedCode)
                {
                    res = resline[2];
                }
            }
            return res;

        }

        private void guiTimer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("MM-dd-yyyy HH:mmtt:ss");
            signalLight.Image = imageList1.Images[0];
            updateStatusImages();
        }

        private void updateStatusImages()
        {

            int[] state = new int[4];
            for (int i = 0; i < Globals.IOCtrl.statusArr.Length; i++)
            {
                state[i] = Convert.ToInt32(Globals.IOCtrl.statusArr[i]);
            }

            signalLight.Image = imageList1.Images[state[0]];
            lblStatus.Text = lbl_States[state[0]];

            sep1SignalLight.Image = imageList1.Images[state[1]];
            sep1LabelStatus.Text = lbl_States[state[1]];

            sep2SignalLight.Image = imageList1.Images[state[2]];
            sep2LabelStatus.Text = lbl_States[state[2]];

            transpSignalLight.Image = imageList1.Images[state[3]];
            transpLabelStatus.Text = lbl_States[state[3]];


            directionBox.Image = imageList2.Images[Convert.ToInt32(Globals.IOCtrl.rotationDirection)];

            var arrayCh0 = convertToIntArr(Globals.IOCtrl.InputStateCh0);
            var arrayCh1 = convertToIntArr(Globals.IOCtrl.InputStateCh1);
            var OarrayCh0 = convertToIntArr(Globals.IOCtrl.OutputStateCh0);

            for (int i = 0; i < 8; ++i)
            {
                inputCh0Pics[i].Image = inputStatusImgList.Images[arrayCh0[i]];
                inputCh0Pics[i].Invalidate();
                inputCh1Pics[i].Image = inputStatusImgList.Images[arrayCh1[i]];
                inputCh0Pics[i].Invalidate();
                outputCh0Pics[i].Image = OutputStatusImgList.Images[OarrayCh0[i]];
            }
        }

        private void inputConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(materialBox.Text))
            {
                MessageBox.Show("Polje materijala je prazno!!! Poništi unos i ponovno skeniraj oba koda", "Material box empty");
                inputConfirmed = false;
                return;
            }
            else
            {

                motorRot = SearchCsv(materialBox.Text);
                Console.WriteLine("Motor rotation :" + motorRot);
                if (motorRot == "0")
                {
                    inputConfirmed = false;
                    MessageBox.Show("Materijal nije pronađen u datoteci programa!!! Poništi unos i ponovno skeniraj oba koda", "Material not found");
                    return;
                }
                else
                {
                    inputConfirmed = true;
                }
            }

            if (string.IsNullOrWhiteSpace(losBox.Text))
            {
                MessageBox.Show("Polje losa je prazno!!! Poništi unos i ponovno skeniraj oba koda", "Material box empty");
                inputConfirmed = false;
                return;
            }

            materialBox.Enabled = false;
            losBox.Enabled = false;
        }

        private void inputClear_Click(object sender, EventArgs e)
        {
            inputConfirmed = false;
            materialBox.Clear();
            losBox.Clear();
            materialBox.Enabled = true;
            losBox.Enabled = true;
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Globals.IOCtrl.resetOutputs();
            Globals.pCol.writeLog(0, "User logged out", operater);
        }

        /*
         *Fukcije za pokretranje i zaustavljanje separatora 1. 
         * 
         */
        private void startSep1_Click(object sender, EventArgs e)
        {
            if (Globals.IOCtrl.statusArr[1].Equals("0"))
            {
                Globals.IOCtrl.separator1Start();
                Globals.pCol.writeLog(0, "Separator 1 started", operater);
            }
            else if (Globals.IOCtrl.statusArr[1].Equals("1"))
            {
                infomsg = new StopInfo("Separator 1. je već aktivan.", false);
                infomsg.Show();
            }
            else
            {
                infomsg = new StopInfo("Separator 1. je u grešci.", false);
                infomsg.Show();
            }
        }

        private void stopSep1_Click(object sender, EventArgs e)
        {
            if (Globals.IOCtrl.statusArr[1].Equals("0"))
            {
                infomsg = new StopInfo("Separator 1. nije aktivan.", false);
                infomsg.Show();
            }
            else if (Globals.IOCtrl.statusArr[1].Equals("1"))
            {
                Globals.IOCtrl.separator1Stop();
                Globals.pCol.writeLog(0, "Separator 1 stoped", operater);
            }
            else
            {
                infomsg = new StopInfo("Separator 1. je u grešci.", false);
                infomsg.Show();
            }

        }

        /*
         *Fukcije za pokretranje i zaustavljanje separatora 1. 
         * 
         */
        private void startSep2_Click(object sender, EventArgs e)
        {
            if (Globals.IOCtrl.statusArr[2].Equals("0"))
            {
                Globals.IOCtrl.separator2Start();
                //sep2RestartTimer.Start();
                Globals.pCol.writeLog(0, "Separator 2 started", operater);
            }
            else if (Globals.IOCtrl.statusArr[2].Equals("1"))
            {
                infomsg = new StopInfo("Separator 2. je već aktivan.", false);
                infomsg.Show();
            }
            else
            {
                infomsg = new StopInfo("Separator 2. je u grešci.", false);
                infomsg.Show();
            }

        }

        private void stopSep2_Click(object sender, EventArgs e)
        {
            if (Globals.IOCtrl.statusArr[2].Equals("0"))
            {
                infomsg = new StopInfo("Separator 2. nije aktivan.", false);
                infomsg.Show();
            }
            else if (Globals.IOCtrl.statusArr[2].Equals("1"))
            {
                Globals.IOCtrl.separator2Stop();
                //sep2RestartTimer.Stop();
                Globals.pCol.writeLog(0, "Separator 2 stoped", operater);
            }
            else
            {
                infomsg = new StopInfo("Separator 2. je u grešci.", false);
                infomsg.Show();
            }
        }
        private void btnStartAuto_Click(object sender, EventArgs e)
        {

            if (inputConfirmed)
            {
                Globals.IOCtrl.startAuto(motorRot);


                string fileDate = string.Format("{0:dd-MM-yyyy}", DateTime.Now);
                string fileName = fileDate + "-" + operater + ".csv";

                string outputName = processLogger.createFileName(fileName);
                processLogger.createProcessLogFile();
                processLogger.appendcsvFile(fileDate, materialBox.Text, losBox.Text, motorRot, operater);
                Console.WriteLine(fileName);
            }
            else
            {
                MessageBox.Show("Prije pokretanja Auto ciklusa potrebno je skenirati Materijal i los kodove", "Input empty");
            }
        }

        private void btnStopAuto_Click(object sender, EventArgs e)
        {
            Globals.IOCtrl.stopAuto();
            Globals.pCol.writeLog(0, "Auto mode stoped", operater);
            infomsg = new StopInfo("Gašenje transportera za : " + (Int32.Parse(Globals.stopTimerInt) / 1000).ToString() + " s", true);
            infomsg.Show();
            Globals.IOCtrl.Belt_counter = 0;
            Globals.IOCtrl.Belt_counterOld = 0;

        }

        private void MotorFWDbtn_Click(object sender, EventArgs e)
        {
            if (Globals.IOCtrl.statusArr[3].Equals("0"))
            {
                Globals.IOCtrl.startMotorFWD();
                Globals.pCol.writeLog(0, "Motor FWD started from GUI", operater);
            }
            else if (Globals.IOCtrl.statusArr[3].Equals("1"))
            {
                infomsg = new StopInfo("Transporter je već aktivan.", false);
                infomsg.Show();
            }
            else
            {
                infomsg = new StopInfo("Transporter je u grešci.", false);
                infomsg.Show();
            }
        }

        private void MotorREVbtn_Click(object sender, EventArgs e)
        {
            if (Globals.IOCtrl.statusArr[3].Equals("0"))
            {
                Globals.IOCtrl.startMotorREV();
                Globals.pCol.writeLog(0, "Motor REV started from GUI", operater);
            }
            else if (Globals.IOCtrl.statusArr[3].Equals("1"))
            {
                infomsg = new StopInfo("Transporter je već aktivan.", false);
                infomsg.Show();
            }
            else
            {
                infomsg = new StopInfo("Transporter je u grešci.", false);
                infomsg.Show();
            }
        }

        private void MotorStopbtn_Click(object sender, EventArgs e)
        {
            Globals.IOCtrl.stopMotor();
            Globals.pCol.writeLog(0, "Motor Stop from GUI", operater);
        }

        private void btn_ispON_Click(object sender, EventArgs e)
        {
            Globals.IOCtrl.ispuhivanjeOn();
        }

        private void btn_ispOFF_Click(object sender, EventArgs e)
        {
            Globals.IOCtrl.ispuhivanjeOff();
        }

        private int[] convertToIntArr(string str)
        {
            int myInt;
            var array = str.ToCharArray().Where(x =>
            int.TryParse(x.ToString(), out myInt)).Select(x =>
            int.Parse(x.ToString())).ToArray();
            return array;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                settingsEdit.Close();
            }
            catch
            {

            }
            settingsEdit = new settingsEditor();
            settingsEdit.Show();
        }

        private void sep2RestartTimer_Tick(object sender, EventArgs e)
        {
            //sep2RestartTimer.Stop();
            Globals.IOCtrl.separator2Start();
        }
    }
}
