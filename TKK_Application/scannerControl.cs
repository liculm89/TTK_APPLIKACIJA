using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace TKK_Application
{
    public class scannerControl
    {
        public SerialPort _serialPort;
        public string result;
        public string connectionStatus;

        private delegate void SetTextDeleg(string text);

        public event dataRecHandler DataRec;
        public EventArgs e = null;
        public delegate void dataRecHandler(scannerControl sC, EventArgs e);

        public scannerControl()
        {
            Console.WriteLine("New scannerControl object created");
        }

        public void connectScanner(string comPort, int baudRate, int databits, int ReadTime, int WriteTime)
        {
            _serialPort = new SerialPort(comPort, baudRate, Parity.None, databits, StopBits.One);
            _serialPort.Handshake = Handshake.RequestToSend;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            _serialPort.ReadTimeout = ReadTime;
            _serialPort.WriteTimeout = WriteTime;
           // Init_scanner_connection();
        }

        public void Init_scanner_connection()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
                connectionStatus = "Scanner disconnected";
            }
            else
            {
                try
                {
                    _serialPort.Open();
                    Console.WriteLine("Port opened");
                    connectionStatus = "Scanner connected";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(110);
            Console.WriteLine("Press any key to continue...");
            string data = _serialPort.ReadExisting().ToString();
            Console.WriteLine(data);
            si_DataReceived(data);
        }

        public void si_DataReceived(string data)
        {
            result = data;
            if (result != null)
            {
                DataRec(this, e);
            }
        }

        public void closeConnection()
        {
            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                    Console.WriteLine("Connection Closed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error closing connection"  + ex.ToString());
            }
        }

        ~scannerControl()  // destructor
        {
            closeConnection();
        }
    }
}
