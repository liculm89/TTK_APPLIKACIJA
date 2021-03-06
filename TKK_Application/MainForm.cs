﻿using Automation.BDaq;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace TKK_Application
{
    public partial class TKK : Form
    {
        private Parametri_skenera param_skenera;
        private StatusIO _statusIO;
        private string csvFileLoc;
        private string profileLoc;

        private scannerControl scanner = new scannerControl();

        private const int m_startPort = 0;
        private const int m_portCountShow = 2;

        private char[] ChStates_port0;
        private char[] ChStates_port1;
        private char[] ChOutputStates_port0;
        public string[] lbl_States = { "READY", "ACTIVE", "ERROR" };

        public DaqCtrlBase IOModule;
        //private static IOControl IO = new IOControl();

        public DataTable dt = new DataTable();
        private delegate void SetTextDeleg(string text);

        public TKK()
        {
            InitializeComponent();
            this.CenterToScreen();
           // panel_debug.Hide();
           // lbl_States = {"READY", "ACTIVE", "ERROR"};
            csvFileLoc = @"D:\N046_17 DOKUMENTACIJA I PROGRAM\Res\Programi.csv";
            profileLoc = @"D:\N046_17 DOKUMENTACIJA I PROGRAM\Res\ioProfile.xml";
            #region Datagrid

            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("BARCODE", typeof(string));
            dt.Columns.Add("SMJER", typeof(string));

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;

            if (File.Exists(csvFileLoc))
            {
                string delimiter = ";";
                readCsv(csvFileLoc, delimiter);
            }

            #endregion Datagrid

            #region ScannerInit

            scanner.connectScanner("COM5", 9600, 8, 110, 110);
            scanner.Init_scanner_connection();
            scanner.DataRec += new scannerControl.dataRecHandler(scannerDataRec);
            scannerStatus.Text = scanner.connectionStatus;

            #endregion ScannerInit

            #region IOModul

            instantDoCtrl1.SelectedDevice = new DeviceInformation(1);
            instantDiCtrl1.SelectedDevice = new DeviceInformation(1);

            instantDiCtrl1.LoadProfile(profileLoc);

            if (!instantDoCtrl1.Initialized)
            {
                MessageBox.Show("No device is selected or device connection failed!", "StaticDO");
                this.Close();
                return;
            }

            if (!instantDiCtrl1.Initialized)
            {
                MessageBox.Show("No device is selected or device connection failed!", "StaticDI");
                this.Close();
                return;
            }
            InitializePortState();


            if (!instantDiCtrl1.Features.DiintSupported)
            {
                Console.WriteLine("The device can not support DI interrupt function.");
                return;
            }

            DiintChannel[] interruptChans = instantDiCtrl1.DiintChannels;
            interruptChans[0].Enabled = true;
            interruptChans[1].Enabled = true;

            instantDiCtrl1.SnapStart();
            ScanInputStates();

            instantDiCtrl1.ChangeOfState += new EventHandler<DiSnapEventArgs>(DInputChanged);
            instantDiCtrl1.Interrupt += new EventHandler<DiSnapEventArgs>(instantDiCtrl_Interrupt);

            timer1.Start();

            Globals.IOCtrl.resetOutputs();
            //setOutput(0, 0);
            #endregion IOModul

            lightReady.Image = imageList3.Images[0];
            ScanInputStates();
            //setOutput(0, 9);
            if (ChStates_port0[2] == '1')
            {
                setStatus(0);
            }
            else
            {
                setStatus(2);
            }
        }

        private void postavkeSkeneraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            param_skenera = new Parametri_skenera();
            param_skenera.Show();
        }

        #region IOMethods

        public void instantDiCtrl_Interrupt(object sender, DiSnapEventArgs e)
        {
           
        }

        public void DInputChanged(object sender, DiSnapEventArgs e)
        {
          
        }

        private void InitializePortState()
        {
            byte portData = 0;
            byte portDir = 0xFF;
            ErrorCode err = ErrorCode.Success;
            byte[] mask = instantDoCtrl1.Features.DoDataMask;

            for (int i = 0; (i + ConstVal.StartPort) < instantDoCtrl1.Features.PortCount && i < ConstVal.PortCountShow; ++i)
            {
                err = instantDoCtrl1.Read(i + ConstVal.StartPort, out portData);
                if (err != ErrorCode.Success)
                {
                    HandleError(err);
                    return;
                }

                if (instantDoCtrl1.Ports != null)
                {
                    portDir = (byte)instantDoCtrl1.Ports[i + ConstVal.StartPort].DirectionMask;
                }

            }
        }

        private void HandleError(ErrorCode err)
        {
            if ((err >= ErrorCode.ErrorHandleNotValid) && (err != ErrorCode.Success))
            {
                MessageBox.Show("Sorry ! Some errors happened, the error code is: " + err.ToString());
            }
        }
        #region Utility
        public static class ConstVal
        {
            public const int StartPort = 0;
            public const int PortCountShow = 4;
        }

        public struct DoBitInformation
        {
            #region fields
            private int m_bitValue;
            private int m_portNum;
            private int m_bitNum;
            #endregion

            public DoBitInformation(int bitvalue, int portNum, int bitNum)
            {
                m_bitValue = bitvalue;
                m_portNum = portNum;
                m_bitNum = bitNum;
            }

            #region Properties
            public int BitValue
            {
                get { return m_bitValue; }
                set
                {
                    m_bitValue = value & 0x1;
                }
            }
            public int PortNum
            {
                get { return m_portNum; }
                set
                {
                    if ((value - ConstVal.StartPort) >= 0
                       && (value - ConstVal.StartPort) <= (ConstVal.PortCountShow - 1))
                    {
                        m_portNum = value;
                    }
                }
            }
            public int BitNum
            {
                get { return m_bitNum; }
                set
                {
                    if (value >= 0 && value <= 7)
                    {
                        m_bitNum = value;
                    }
                }
            }
            #endregion
        }
        #endregion Utility

        private void DO1_btn_Click(object sender, EventArgs e)
        {
            ErrorCode err = ErrorCode.Success;
            int state = 1;
            int portNum = 0;

            int value;

            if (int.TryParse(textBox1.Text, out value))
            {
                //parsing successful 
            }
            else
            {
                //parsing failed. 
            }

            state = value;

            err = instantDoCtrl1.Write(portNum, (byte)state);
            if (err != ErrorCode.Success)
            {
                HandleError(err);
            }
        }

        #endregion IOMethods

        private void statusIOModulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _statusIO = new StatusIO(1);
            _statusIO.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("MM-dd-yyyy HH:mmtt:ss");
            ScanInputStates();

        }

        #region datagridMethods

        private void populate(string id, string barcode, string smjerRot)
        {
            dataGridView1.Rows.Add(id, barcode, smjerRot);
        }

        private void csvSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string directoryPath = Path.GetDirectoryName(openFileDialog1.FileName);
                string filename = System.IO.Path.GetFileName(openFileDialog1.FileName);
                Console.WriteLine(directoryPath + "\\" + filename);
                csvFileLoc = "'" + directoryPath + "\\" + filename + "'";

                csvFileLoc = Path.Combine(directoryPath, filename);
                // Console.WriteLine(csvFileLoc);
                string delimiter = ";";
                readCsv(csvFileLoc, delimiter);
            }
        }

        private void readCsv(string fileName, string delimiters)
        {
            using (TextFieldParser tfp = new TextFieldParser(fileName))
            {
                tfp.SetDelimiters(delimiters);

                if (!tfp.EndOfData)
                {
                    string[] fields = tfp.ReadFields();
                }

                while (!tfp.EndOfData)
                    dt.Rows.Add(tfp.ReadFields());
            }

        }

        private void scannedCode_TextChanged(object sender, EventArgs e)
        {
            string searchValue = scannedCode.Text;
            int rowIndex = -1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[1].Value.ToString().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
                catch { }
            }

            if (rowIndex != -1)
            {
                dataGridView1.Rows[rowIndex].Selected = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt.Clear();
            if (csvFileLoc != null)
            {
                string delimiter = ";";
                readCsv(csvFileLoc, delimiter);
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = null;
            }

            return;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string a = Convert.ToString(selectedRow.Cells["SMJER"].Value);

                Console.WriteLine(a);

                if (a == "1")
                {
                    rotationLabel.Text = "CW";
                }
                else if (a == "2")

                {
                    rotationLabel.Text = "CCW";
                }
                else
                {
                    rotationLabel.Text = "Error";
                }
            }
        }

        #endregion datagridMehtods

        #region Scanner

        private void connScanner_Click(object sender, EventArgs e)
        {
            scanner.Init_scanner_connection();
            scannerStatus.Text = scanner.connectionStatus;
        }

        public void scannerDataRec(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate
                {
                    scannedCode.Text = ("");
                    scannedCode.Text = scanner.result.Trim();
                }));

            }
        }
        #endregion Scanner

        #region Automatika

        public void initCheck()
        {
            ScanInputStates();
            if (ChStates_port0[2] == '1')
            {
                setStatus(0);
            }
            else
            {
                setStatus(2);
            }
        }

        private async void btnStartAuto_Click(object sender, EventArgs e)
        {
            resetOutputs();

            ScanInputStates();
            if (ChStates_port0[2] == '1')
            {
                btnStopAuto.Enabled = false;
                getOutputState();
                char[] newState = ChOutputStates_port0;
                string outputS = convertOutputToString(newState);
                int output = Convert.ToInt32(outputS, 2);
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string a = Convert.ToString(selectedRow.Cells["SMJER"].Value);

                await Task.Delay(500);
                #region motorDir
                if (a == "1")
                {
                    newState[7] = '1';
                    outputS = convertOutputToString(newState);
                    output = Convert.ToInt32(outputS, 2);
                    setOutput(0, output);
                }
                else if (a == "2")
                {
                    newState[6] = '1';
                    outputS = convertOutputToString(newState);
                    output = Convert.ToInt32(outputS, 2);
                    setOutput(0, output);
                }
                #endregion motorDir
                await Task.Delay(500);

                getOutputState();
                newState = ChOutputStates_port0;
                newState[5] = '1';
                newState[4] = '1';
                newState[3] = '1';
                newState[1] = '1';
                outputS = convertOutputToString(newState);
                output = Convert.ToInt32(outputS, 2);
                setOutput(0, output);

                /*
                setOutput(0, 9);
                */
                ScanInputStates();
                await Task.Delay(1000);

                //setOutput(0, 29);
                setStatus(1);
                panel_manual.Hide();
                btnStopAuto.Enabled = true;
            }
            else
            {
                MessageBox.Show("TOTAL STOP IS ACTIVE!", "TOTAL STOP ERROR");

            }

        }

        private async void automaticStop()
        {
            getOutputState();
            char[] newState = ChOutputStates_port0;
            string outputS = convertOutputToString(newState);
            int output = Convert.ToInt32(outputS, 2);

            newState[5] = '0';
            newState[4] = '0';
            outputS = convertOutputToString(newState);
            output = Convert.ToInt32(outputS, 2);
            setOutput(0, output);

            await Task.Delay(5000);

            getOutputState();
            newState = ChOutputStates_port0;
            newState[7] = '0';
            newState[6] = '0';
            newState[2] = '1';

            outputS = convertOutputToString(newState);
            output = Convert.ToInt32(outputS, 2);
            setOutput(0, output);

            await Task.Delay(100);

            setOutput(0, 0);
            Console.WriteLine("Output set to 0");

            setStatus(0);
            panel_manual.Show();
        }

        private async void btnStopAuto_Click(object sender, EventArgs e)
        {

            getOutputState();
            char[] newState = ChOutputStates_port0;
            string outputS = convertOutputToString(newState);
            int output = Convert.ToInt32(outputS, 2);

            newState[5] = '0';
            newState[4] = '0';
            outputS = convertOutputToString(newState);
            output = Convert.ToInt32(outputS, 2);
            setOutput(0, output);

            await Task.Delay(2000);

            getOutputState();
            newState = ChOutputStates_port0;
            newState[7] = '0';
            newState[6] = '0';
            newState[2] = '1';

            outputS = convertOutputToString(newState);
            output = Convert.ToInt32(outputS, 2);
            setOutput(0, output);

            await Task.Delay(100);

            setOutput(0, 0);
            Console.WriteLine("Output set to 0");

            setStatus(0);
            panel_manual.Show();
        }
        #endregion Automatika

        private void setOutput(int portNum, int state)
        {
            ErrorCode err = ErrorCode.Success;
            err = instantDoCtrl1.Write(portNum, (byte)state);
            if (err != ErrorCode.Success)
            {
                HandleError(err);
            }
            Console.WriteLine("Output set to: " + state);
        }

        private void setStatus(int state)
        {

            lightReady.Image = imageList3.Images[state];
            lblStatus.Text = lbl_States[state];
        }

        private void ScanInputStates()
        {
            #region Inputs
            byte portData = 0;

            ErrorCode err = ErrorCode.Success;
            err = instantDiCtrl1.Read(0, out portData);
            if (err != ErrorCode.Success)
            {
                timer1.Enabled = false;
                HandleError(err);
                return;
            }

            ChStates_port0 = convertToArr(portData);
            string a = new string(ChStates_port0);
            inputsStatus.Text = a;

            err = ErrorCode.Success;
            err = instantDiCtrl1.Read(1, out portData);
            if (err != ErrorCode.Success)
            {
                timer1.Enabled = false;
                HandleError(err);
                return;
            }
            ChStates_port1 = convertToArr(portData);
            string b = new string(ChStates_port1);
            inputStatus1.Text = b;
            #endregion Inputs

            getOutputState();

        }

        private async void resetOutputs()
        {
            getOutputState();
            char[] newState = ChOutputStates_port0;
            newState[3] = '0';
            newState[2] = '1';
            string outputS = convertOutputToString(newState);
            int output = Convert.ToInt32(outputS, 2);
            setOutput(0, output);
            await Task.Delay(300);
            setOutput(0, 8);
            Console.WriteLine("Ouputs reseted");
        }

        private void getOutputState()
        {
            byte portData = 0;
            byte portDir = 0xFF;
            ErrorCode err = ErrorCode.Success;
            byte[] mask = instantDoCtrl1.Features.DoDataMask;

            err = instantDoCtrl1.Read(ConstVal.StartPort, out portData);
            if (err != ErrorCode.Success)
            {
                HandleError(err);
                return;
            }

            if (instantDoCtrl1.Ports != null)
            {
                portDir = (byte)instantDoCtrl1.Ports[ConstVal.StartPort].DirectionMask;
            }
            ChOutputStates_port0 = convertToArr(portData);

            Array.Reverse(ChOutputStates_port0);
            string outStats = new string(ChOutputStates_port0);
            ostatustext.Text = outStats;
        }

        private char[] convertToArr(int state)
        {
            string s = Convert.ToString(state, 2);
            char[] bitsarr = s.PadLeft(8, '0').ToCharArray();
            Array.Reverse(bitsarr);
            return bitsarr;
        }

        private string convertOutputToString(char[] outputState)
        {
            string result = new string(outputState);
            return result;
        }

        //Separator 1. START
        private void button2_Click(object sender, EventArgs e)
        {
            Globals.IOCtrl.separator1Start();
        }
      
        //Separator 1. STOP
        private void button3_Click(object sender, EventArgs e)
        {
            Globals.IOCtrl.separator1Stop();
        }

        //Separator 2. Start
        private void button5_Click(object sender, EventArgs e)
        {
            Globals.IOCtrl.separator2Start();
        }

        //Separator 2 Stop
        private void button4_Click(object sender, EventArgs e)
        {
            Globals.IOCtrl.separator2Stop();
        }

        //MOTOR FWD
        private void button6_Click(object sender, EventArgs e)
        {
            Globals.IOCtrl.startMotorFWD();
        }
        //MOTOR STOP
        private void button8_Click(object sender, EventArgs e)
        {
            Globals.IOCtrl.stopAuto();
        }
        //MOTOR REV
        private void button7_Click(object sender, EventArgs e)
        {
            Globals.IOCtrl.startMotorREV();
        }

        private void btn_ispON_Click(object sender, EventArgs e)
        {
            Globals.IOCtrl.ispuhivanjeOn();
        }

        private void btn_ispOFF_Click(object sender, EventArgs e)
        {
            Globals.IOCtrl.ispuhivanjeOff();
        }

        private void timer_auto_Tick(object sender, EventArgs e)
        {
            ScanInputStates();
            if (ChStates_port0[2] == '0')
            {
                resetOutputs();
                Console.WriteLine("Total stop pressed");
                setStatus(2);
                timer_auto.Stop();
            }
        }

        private void TKK_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
