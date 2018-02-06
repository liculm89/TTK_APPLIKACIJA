using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using Automation.BDaq;
using System.Threading;
using Microsoft.VisualBasic.FileIO;

namespace TKK_Application
{
    public partial class TKK : Form
    {
        private Parametri_skenera param_skenera;
        private StatusIO _statusIO;
        private string csvFileLoc;

        private SerialPort _serialPort;
        private Label[] m_portNum;
        private Label[] m_portHex;

        public DataTable dt = new DataTable();

        private delegate void SetTextDeleg(string text);


        public TKK()
        {
            InitializeComponent();
            csvFileLoc = @"G:\2017\N046_17 DOKUMENTACIJA I PROGRAM\Res\Programi.csv";
          
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
            _serialPort = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
            _serialPort.Handshake = Handshake.RequestToSend;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            _serialPort.ReadTimeout = 110;
            _serialPort.WriteTimeout = 110;
            //_serialPort.DtrEnable = true;

            if (!(_serialPort.IsOpen))
            {
                scannerStatus.Text = "Scanner is not connected...";
            }
            #endregion ScannerInit

            #region IOModul
            instantDoCtrl1.SelectedDevice = new DeviceInformation(0);
            instantDiCtrl1.SelectedDevice = new DeviceInformation(0);

            if (!instantDoCtrl1.Initialized)
            {
                MessageBox.Show("No device be selected or device open failed!", "StaticDO");
                this.Close();
                return;
            }

            if (!instantDiCtrl1.Initialized)
            {
                MessageBox.Show("No device be selected or device open failed!", "StaticDI");
                this.Close();
                return;
            }
            InitializePortState();
            timer1.Start();
            #endregion IOModul
        }

        private void postavkeSkeneraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            param_skenera = new Parametri_skenera();
            param_skenera.Show();
        }

        #region IOMethods

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

                //m_portNum[i].Text = (i + ConstVal.StartPort).ToString();
                //m_portHex[i].Text = portData.ToString("X2");

                if (instantDoCtrl1.Ports != null)
                {
                    portDir = (byte)instantDoCtrl1.Ports[i + ConstVal.StartPort].DirectionMask;
                }
/*
                // Set picture box state
                for (int j = 0; j < 8; ++j)
                {
                    if (((portDir >> j) & 0x1) == 0 || ((mask[i] >> j) & 0x1) == 0)  // Bit direction is input.
                    {
                        m_pictrueBox[i, j].Image = imageList1.Images[2];
                        m_pictrueBox[i, j].Enabled = false;
                    }
                    else
                    {
                        m_pictrueBox[i, j].Click += new EventHandler(PictureBox_Click);
                        m_pictrueBox[i, j].Tag = new DoBitInformation((portData >> j) & 0x1, i + ConstVal.StartPort, j);
                        m_pictrueBox[i, j].Image = imageList1.Images[(portData >> j) & 0x1];
                    }
                    m_pictrueBox[i, j].Invalidate();
 */
                }
            }

        private void HandleError(ErrorCode err)
        {
            if ((err >= ErrorCode.ErrorHandleNotValid) && (err != ErrorCode.Success))
            {
                MessageBox.Show("Sorry ! Some errors happened, the error code is: " + err.ToString());
            }
        }

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
            _statusIO = new StatusIO(0);
            _statusIO.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("MM-dd-yyyy h:mmtt:ss");
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
                Console.WriteLine(directoryPath +"\\" + filename);
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

            //searchValue = scannedCode.Text;
            
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
  
           /* string columnName = "BARCODE";

            string rowFilter = string.Format("[{0}] = '{1}'", columnName, searchValue);
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            Init_scanner_connection();
        }

        void Init_scanner_connection()
        {

            if (_serialPort.IsOpen)
            {
                //Console.WriteLine("Port is open");
                _serialPort.Close();
                scannerStatus.Text = "Scanner disconnected.";
            }
            else
            {
                try
                {
                    _serialPort.Open();
                    Console.WriteLine("Port opened");
                    scannerStatus.Text = "Scanner is connected.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening port: " + ex.Message);
                }
            }
        }

        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(110);
            Console.WriteLine("Press any key to continue...");
            string data = _serialPort.ReadExisting().ToString();
            //Console.WriteLine(data);
            this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });
        }

        private void si_DataReceived(string data)
        {
            scannedCode.Text = ("");
            scannedCode.Text = data.Trim();
        }
        #endregion Scanner

    }
}
