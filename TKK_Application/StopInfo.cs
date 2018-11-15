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
    public partial class StopInfo : Form
    {
        public bool setTimer;

        public StopInfo(string text, bool timerEnable)
        {
            InitializeComponent();
            setTimer = timerEnable;
            this.CenterToScreen();
            this.infoLabel.Text = text;
            if (timerEnable)
            {
                closeTimer.Interval = Int32.Parse(Globals.stopTimerInt);
                closeTimer.Start();
            }
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (setTimer)
            {
                this.closeTimer.Stop();
            }
            this.Close();
        }

        private void closeTimer_Tick(object sender, EventArgs e)
        {
            this.closeTimer.Stop();
            this.Close();
        }
    }
}
