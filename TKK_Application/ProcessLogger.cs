using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TKK_Application
{
    public partial class ProcessLogger : Form
    {

        public string[] logArr = new string[4];
        public DataTable dt = new DataTable();

        public ProcessLogger()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void ProcessLogger_Load(object sender, EventArgs e)
        {

            Globals.pCol.DataRec += new processCollector.updatelog(getNewLog);
            dt.Columns.Add("TimeStamp", typeof(string));
            dt.Columns.Add("Event Type", typeof(string));
            dt.Columns.Add("Event Message", typeof(string));
            dt.Columns.Add("User ID", typeof(string));

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;
            
            populateTable();
        }

        public void populateTable()
        {
            dt.Clear();
            readCsv(Globals.pCol.Fullpath, ";");
        }

        public void getNewLog(object sender, EventArgs e)
        {
            dt.Clear();
            readCsv(Globals.pCol.Fullpath, ";");
           // Console.WriteLine("INVOKED");

        }

        public void readCsv(string fileName, string delimiters)
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

        public void getValues()
        {


        }

        private void logtest_Click(object sender, EventArgs e)
        {
            Globals.pCol.writeLog( 0, "message", "user");

            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate
                {

//                    Console.WriteLine("INVOKED");

                }));
            }
        }
    }
}
