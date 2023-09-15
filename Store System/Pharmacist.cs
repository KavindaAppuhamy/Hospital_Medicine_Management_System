using Store_System.Dispenser;
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
    public partial class Pharmacist : Form
    {
        public Pharmacist()
        {
            InitializeComponent();
            paneleDesign();
        }
        private void paneleDesign()
        {
            subMenuPanel.Visible = false;
        }
        private void hideSubmenu()
        {
            if (subMenuPanel.Visible == true)
                subMenuPanel.Visible = false;
        }
        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;

        }
        private void Pharmacist_Load(object sender, EventArgs e)
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
            chiledpanel2.Controls.Add(childForm);
            chiledpanel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnDashBord_Click(object sender, EventArgs e)
        {
            openChildForm(new DashBoard());
        }

        private void btnViewMedicine_Click(object sender, EventArgs e)
        {
            openChildForm(new ViewMed());
        }

        private void btnMedValidity_Click(object sender, EventArgs e)
        {
            openChildForm(new ValidityCheck());
        }

        private void btn_Issue_Click(object sender, EventArgs e)
        {
            openChildForm(new Issue());
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signin sn = new Signin();
            sn.ShowDialog();
        }

        private void btn_viewBill_Click(object sender, EventArgs e)
        {
            openChildForm(new ViewBills());

        }

        private void btn_billProcess_Click(object sender, EventArgs e)
        {
            ShowSubMenu(subMenuPanel);
        }

        private void btn_viewSales_Click(object sender, EventArgs e)
        {
            openChildForm(new View_Sales());
        }
    }
}
