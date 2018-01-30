using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TKK_Application
{
    public partial class TKK : Form
    {
        private Parametri_skenera param_skenera;
        public TKK()
        {
            InitializeComponent();
        }

        private void postavkeSkeneraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            param_skenera = new Parametri_skenera();
            param_skenera.Show();
        }
    }
}
