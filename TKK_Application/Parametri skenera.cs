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


namespace TKK_Application
{
    public partial class Parametri_skenera : Form
    {
        SerialPort _serialPort;

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
    }
}
