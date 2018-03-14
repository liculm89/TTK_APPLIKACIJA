using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
using Automation.BDaq;
using System.Threading;
using Microsoft.VisualBasic.FileIO;
using System.Windows.Forms;


namespace TKK_Application
{
    public partial class UserForm : Form
    {
        public string csvFileLoc = Globals.csvInput;
        public string COMport = Globals.scannerCOM;

        private static IOControl IO = new IOControl();
        private scannerControl scanner = new scannerControl();
        private PictureBox[] statusLightArr = new PictureBox[4];
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
            }

            this.CenterToScreen();
            UserNameLbl.Text = name;
            inputConfirmed = false;
            guiTimer.Start();

            scanner.connectScanner(COMport, 9600, 8, 110, 110);
            scanner.Init_scanner_connection();
            scannerStatus.Text = scanner.connectionStatus;
            scanner.DataRec += new scannerControl.dataRecHandler(scannerDataRec);
            statusLightArr = new PictureBox[] { signalLight, sep1SignalLight, transpSignalLight, sep2SignalLight };
        }

        public void scannerDataRec(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate
                {

                    if (string.IsNullOrWhiteSpace(materialBox.Text))
                    {

                        materialBox.Text = scanner.result.Trim();
                    }
                    else if (string.IsNullOrWhiteSpace(losBox.Text))
                    {
                        losBox.Text = scanner.result.Trim();
                    }

                    
                }));
            }
        }

        public string SearchCsv(string ScannedCode)
        {
            string res;
            res = "null";
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

        private void button1_Click(object sender, EventArgs e)
        {
            string code = textBox1.Text.ToString();
            string result;
            result = SearchCsv(code);
            Console.WriteLine(result);

            if (result == "1")
            {
                MessageBox.Show("Smjer vrtnje motora je CW");
            }
            else if (result == "2")
            {
                MessageBox.Show("Smjer vrtnje motora je CCW");
            }
            else
            {
                MessageBox.Show("Nema podatka o smjeru vrtnje motora za očitani kod");
            }
        }

        private void guiTimer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("MM-dd-yyyy HH:mmtt:ss");
            IO.ScanStates();
            inputStats.Text = IO.InputStateCh0;
            inputStats1.Text = IO.InputStateCh1;
            outputStats.Text = IO.OutputStateCh0;
            signalLight.Image = imageList1.Images[0];
            updateStatusImages();
        }

        private void updateStatusImages()
        {
            int[] state = new int[4];

            for (int i = 0; i < IO.statusArr.Length; i++)
            {
                state[i] = Convert.ToInt32(IO.statusArr[i]);
            }

            signalLight.Image = imageList1.Images[state[0]];
            lblStatus.Text = lbl_States[state[0]];

            sep1SignalLight.Image = imageList1.Images[state[1]];
            sep1LabelStatus.Text = lbl_States[state[1]];

            sep2SignalLight.Image = imageList1.Images[state[2]];
            sep2LabelStatus.Text = lbl_States[state[2]];

            transpSignalLight.Image = imageList1.Images[state[3]];
            transpLabelStatus.Text = lbl_States[state[3]];
        }

        private void inputConfirm_Click(object sender, EventArgs e)
        {
            inputConfirmed = true;
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
            Application.Exit();
        }

        private void startSep1_Click(object sender, EventArgs e)
        { 
            IO.separator1Start();
        }

        private void stopSep1_Click(object sender, EventArgs e)
        {
            IO.separator1Stop();
        }

        private void startSep2_Click(object sender, EventArgs e)
        {
            IO.separator2Start();
        }

        private void stopSep2_Click(object sender, EventArgs e)
        {
            IO.separator2Stop();
        }

        private void btnStartAuto_Click(object sender, EventArgs e)
        {
            IO.startAuto("1");
        }

        private void btnStopAuto_Click(object sender, EventArgs e)
        {
            IO.stopAuto();
        }


    }
}
