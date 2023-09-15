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
    public partial class StartPage : Form
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void btn_admin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin obj = new Admin();
            obj.ShowDialog();
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signin obj1 = new Signin();
            obj1.ShowDialog();
            
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StartPage_Load(object sender, EventArgs e)
        {

        }
    }
}
