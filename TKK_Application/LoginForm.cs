﻿using System;
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
        public LoginForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            // InitializeComponent();
            passBox.Text = "";
            passBox.PasswordChar = '*';
            passBox.MaxLength = 4;
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
            catch (Exception ex)
            {
                return false;
            }

        }

        private void Login()
        {
            Console.WriteLine("logging in...");

            Console.WriteLine(Globals.database_loc);

            string database_loc = Globals.database_loc;
            string Db_Password = Globals.db_passwd;
            bool check_connection = test_connection(database_loc, Db_Password);

            if (check_connection)
            {
                //string Db_Password = "0000";
                string conString = "Provider=Microsoft.ACE.OLEDB.12.0; Jet OLEDB:Database Password=" + Db_Password + "; Persist Security Info = False; Data Source=" + database_loc + ";";

                OleDbConnection con = new OleDbConnection(conString);

                //String sql = "SELECT * FROM Login";
                OleDbDataAdapter test = new OleDbDataAdapter("Select Count(*) From Login where user='" + userBox.Text + "' and password='" + passBox.Text + "'", con);
                DataTable logins = new DataTable();
                test.Fill(logins);


                if ((userBox.Text == "") || (passBox.Text == ""))
                {
                    MessageBox.Show("Pogreška prilikom logina. Upiši korisničko ime i lozinku!", "Login error");
                }
                else
                {
                    if (logins.Rows[0][0].ToString() == "1")
                    {
                        Console.WriteLine("yast");
                        //this.Close();
                        this.Hide();
                        TKK Tkk_admin = new TKK();
                        Tkk_admin.Show();
                       // Application.Run(new TKK());
                    }
                    else
                    {
                        MessageBox.Show("Pogreška prilikom logina. Pogrešno korisničko ime ili lozinka!", "Login error");
                    }
                }

            }
            else
            {
                MessageBox.Show("Nije moguće otvoriti bazu podataka, ne postoji databaza na zadanoj lokaciji ili je u postavkama zadana pogrešna lozinka.");

            }
        }
    
    }
}