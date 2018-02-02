using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Management;
using System.IO.Ports;
using System.Threading;
using Automation.BDaq;

namespace TKK_Application
{
    public partial class Parametri_skenera : Form
    {
        public SerialPort _serialPort;


        private delegate void SetTextDeleg(string text);


        public Parametri_skenera()
        {
            InitializeComponent();
        }

        private void Parametri_skenera_Load(object sender, EventArgs e)
        {
            var name = System.Configuration.ConfigurationManager.AppSettings["name"];
            Console.WriteLine(name);

            string[] ports = SerialPort.GetPortNames();

            

            Console.WriteLine("The following serial ports were found:");

            // Display each port name to the console.
            foreach (string port in ports)
            {
                com_combobox.Items.Add(port);
                Console.WriteLine(port);
            }

            //Console.ReadLine();
        }

        private void connectScanner_Click(object sender, EventArgs e)
        {
            _serialPort = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
            _serialPort.Handshake = Handshake.RequestToSend;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            _serialPort.ReadTimeout = 110;
            _serialPort.WriteTimeout = 110;
            //_serialPort.DtrEnable = true;
           // _serialPort.Open();
            if (_serialPort.IsOpen)
            {
                Console.WriteLine("Port open");
            }
            else
            {
                try
                {
                    _serialPort.Open();
                    Console.WriteLine("Port opened");
                }
                catch { }
            }
        }

        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            Thread.Sleep(110);
            Console.WriteLine("Press any key to continue...");
            string data = _serialPort.ReadExisting().ToString();
            Console.WriteLine(data);
            this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });
        }

        private void si_DataReceived(string data)
        {
            textBox1.Text = data.Trim();
        }

        private void Parametri_skenera_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _serialPort.Close();
                Console.WriteLine("Port closed");
            }
            catch
            {
                Console.WriteLine("no port is open");
            }

        }

    }
}
