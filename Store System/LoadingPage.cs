using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_System
{
    public partial class LoadingPage : Form
    {
        public LoadingPage()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            guna2Panel2.Width += 3;
            if(guna2Panel2.Width >= 700)
            {
                timer1.Stop();
                StartPage sp = new StartPage();
                sp.Show();
                this.Hide();
            }
        }
    }
}
