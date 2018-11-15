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
using System.IO;
using System.Media;
using System.IO.Ports;

namespace TKK_Application
{
    public partial class settingsEditor : Form
    {
        public string[] keys = new string[7];
        public SerialPort _serialPort;

        public settingsEditor()
        {
            InitializeComponent();
            this.CenterToScreen();
            keys[0] = "db_loc";
            keys[1] = "archive_loc";
            keys[2] = "db_passwd";
            keys[3] = "csvInput_loc";
            keys[4] = "IOdeviceNum";
            keys[5] = "ScannerCOM";
            keys[6] = "stopTimerTime";
            //keys[6] = "archiveTemplate";
            populate();
        }

        public void populate()
        {
            userDBtext.Text = Properties.Settings.Default[keys[0]].ToString();
            archiveLocBox.Text = Properties.Settings.Default[keys[1]].ToString();
            passwdBox.PasswordChar = '*';
            passwdBox.Text = Properties.Settings.Default[keys[2]].ToString();
            programListBox.Text = Properties.Settings.Default[keys[3]].ToString();
            deviceIDBox.Text = Properties.Settings.Default[keys[4]].ToString();
            stopTimerBox.Text = Properties.Settings.Default[keys[6]].ToString();

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comBox.Items.Add(port);
                Console.WriteLine(port);
            }
            comBox.SelectedIndex = comBox.FindString(Properties.Settings.Default[keys[5]].ToString());
        }

        public void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                Properties.Settings.Default[key] = value;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not write configuration key: " + ex);
            }

            Properties.Settings.Default.Save();
        }



        private void userDatabaseBtn_Click(object sender, EventArgs e)
        {
            if (selectUserDatabase.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string directoryPath = Path.GetDirectoryName(selectUserDatabase.FileName);
                string filename = System.IO.Path.GetFileName(selectUserDatabase.FileName);
                userDBtext.Text = "'" + directoryPath + "\\" + filename + "'";
            }
        }

        private void programListBtn_Click(object sender, EventArgs e)
        {
            if (selectProgramList.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string directoryPath = Path.GetDirectoryName(selectProgramList.FileName);
                string filename = System.IO.Path.GetFileName(selectProgramList.FileName);
                programListBox.Text = "'" + directoryPath + "\\" + filename + "'";
            }
        }

        private void ArchiveLocBtn_Click(object sender, EventArgs e)
        {
            if (selectArchiveLoc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string drp = Path.GetDirectoryName(selectArchiveLoc.SelectedPath);
                string full_path = Path.GetFullPath(selectArchiveLoc.SelectedPath);
                archiveLocBox.Text = full_path.ToString();
            }
        }

        private void saveChangesBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Saving changes");

            string[] values = new string[] { userDBtext.Text, archiveLocBox.Text, passwdBox.Text,
                programListBox.Text, deviceIDBox.Text.ToString(), comBox.SelectedItem.ToString(), stopTimerBox.Text.ToString() };

            Console.WriteLine(values);

            for (int i = 0; i < keys.Length; i++)
            {
                try
                {
                    Console.WriteLine("update: " + keys[i].ToString());
                    AddUpdateAppSettings(keys[i], values[i]);
                }
                catch (ConfigurationErrorsException ex)
                {
                    MessageBox.Show("Failed to update setting: " + ex.ToString());
                }
            }

            try
            {
                Program.update_globals();
            }
            catch
            {

            }
        }
    }
}
