using Store_System.MedicinAdmin;
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
    public partial class MainMenu : Form
    {
        bool mousedown;
        public MainMenu()
        {
            InitializeComponent();
            
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            btnDashBord.PerformClick();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            chiledpanel.Controls.Add(childForm);
            chiledpanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnDashBord_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_adminDashboard());
        }

        private void btnAddmedicine_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_adminadd());
        }

        private void btnViewMedicine_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_adminView());
        }

        private void btnMedValidity_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_adminValidity());
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Signin sn = new Signin();
            sn.Show();
            this.Hide();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_adminUpdate());
        }

        private void btn_Issue_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_adminIssue());
        }
    }
}
