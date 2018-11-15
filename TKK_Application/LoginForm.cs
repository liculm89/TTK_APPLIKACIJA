using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
//using System.Windows.Forms.;

namespace TKK_Application
{
    public partial class LoginForm : Form
    {

        public static UserForm UForm;

        public static settingsEditor settingsEdit = new settingsEditor();
        public static ProcessLogger loggerWindow = new ProcessLogger();
            
        public LoginForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.KeyPreview = true;
            passBox.Text = "";
            passBox.PasswordChar = '*';
            passBox.MaxLength = 4;
            try
            {
                Globals.IOCtrl.resetOutputs();
            }
            catch(Exception ex)
            {
                Console.WriteLine("No device loaded : " + ex.ToString());
                Globals.pCol.writeLog(1, "No device loaded", "");
            }
            
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            Login();  
        }


        private bool test_connection(string db, string passwd)
        {
            try
            {
                string conString = "Provider=Microsoft.ACE.OLEDB.12.0; Jet OLEDB:Database Password=" + passwd + "; Persist Security Info = False; Data Source=" + db + ";";
                OleDbConnection con = new OleDbConnection(conString);
                con.Open();

                if (con.State.ToString() == "Open")
                {
                    con.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private void Login()
        {

            string database_loc = Globals.database_loc;
            string Db_Password = Globals.db_passwd;
            bool check_connection = test_connection(database_loc, Db_Password);

            if (check_connection)
            {
                string conString = "Provider=Microsoft.ACE.OLEDB.12.0; Jet OLEDB:Database Password=" + Db_Password + "; Persist Security Info = False; Data Source=" + database_loc + ";";
                OleDbConnection con = new OleDbConnection(conString);

                OleDbDataAdapter test = new OleDbDataAdapter("Select Count(*) From Login where user='" + userBox.Text + "' and password='" + passBox.Text + "'", con);
                DataTable logins = new DataTable();
                test.Fill(logins);
                string username = userBox.Text;

                if ((userBox.Text == "") || (passBox.Text == ""))
                {
                    MessageBox.Show("Pogreška prilikom logina. Upiši korisničko ime i lozinku!", "Login error");
                    Globals.pCol.writeLog(1, "Pogreška prilikom logina. Nevažeće korisničko ime ili lozinka.", "");

                }
                else
                {
                    if (logins.Rows[0][0].ToString() == "1")
                    {
                        this.Hide();
                        Globals.IOCtrl.stopTimer();
                        UForm = new UserForm(username);
                        UForm.Show();
                        UForm.FormClosing += userFormClosed;
                    }
                    else
                    {
                        MessageBox.Show("Pogreška prilikom logina. Pogrešno korisničko ime ili lozinka!", "Login error");
                        Globals.pCol.writeLog(1, "Pogreška prilikom logina. Nevažeće korisničko ime ili lozinka.", "");
                    }
                }

            }
            else
            {
                MessageBox.Show("Nije moguće otvoriti bazu podataka, ne postoji databaza na zadanoj lokaciji ili je u postavkama zadana pogrešna lozinka.");
                Globals.pCol.writeLog(1, "Nije moguće otvoriti bazu podataka, ne postoji databaza na zadanoj lokaciji ili je u postavkama zadana pogrešna lozinka.", "");
            }
        }
        private void userFormClosed(object sender, FormClosingEventArgs e)
        {
            this.Show();
            userBox.Text = "";
            passBox.Text = "";
            this.ActiveControl = userBox;

        }

        private void settingsBox_Click(object sender, EventArgs e)
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                loggerWindow.Close();
            }
            catch
            {

            }
            loggerWindow = new ProcessLogger();
            loggerWindow.Show();
        }
    }
}
