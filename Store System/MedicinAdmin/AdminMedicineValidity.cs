using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Store_System.MedicinAdmin
{
    public partial class frm_adminValidity : Form
    {
        public frm_adminValidity()
        {
            InitializeComponent();
        }
        PSConnection obj = new PSConnection();

        private void txtCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtCheck.SelectedIndex == 0)
            {
                string query = "SELECT * FROM medicine WHERE Exdate >= getdate()";
                DataSet ds = obj.getData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];
                CheckLabel.Text = "Valid Medicines.";
                CheckLabel.ForeColor = Color.Teal;
            }
            else if (txtCheck.SelectedIndex == 1)
            { 
                string query = "SELECT * FROM medicine WHERE DATEDIFF(Month,GETDATE(),Exdate)=6;";
                DataSet ds = obj.getData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];
                CheckLabel.Text = "Expire Soon Medicine";
                CheckLabel.ForeColor = Color.PaleGoldenrod;               
            }
            else if (txtCheck.SelectedIndex == 2)
            {
                
                string query = "SELECT * FROM medicine WHERE Exdate <= getdate()";
                DataSet ds = obj.getData(query);         
                guna2DataGridView1.DataSource = ds.Tables[0];
                CheckLabel.Text = "Expired Medicines";
                CheckLabel.ForeColor = Color.LightCoral;          
            }
            else if (txtCheck.SelectedIndex == 3)
            {
                string query = "SELECT * FROM medicine";
                DataSet ds = obj.getData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];
                CheckLabel.Text = "All Medicines";
                CheckLabel.ForeColor = Color.MediumTurquoise; 
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if(txtCheck.SelectedIndex == -1)
            {
                Guna.UI2.WinForms.MessageDialog.Show("Please Select Validity Type", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
            }
            else if(txtCheck.SelectedIndex == 0)
            {
                Valid_Medi vm = new Valid_Medi();
                vm.ShowDialog();
            }
            else if(txtCheck.SelectedIndex == 1)
            {
                Expire_Soon_medi es = new Expire_Soon_medi();
                es.ShowDialog();
            }
            else if(txtCheck.SelectedIndex == 2)
            {
                Expiered_Medi em = new Expiered_Medi();
                em.ShowDialog();
            }
            else if(txtCheck.SelectedIndex == 3)
            {
                PrintMedicines pm = new PrintMedicines();
                pm.ShowDialog();
            }
           
        }
    }
}
