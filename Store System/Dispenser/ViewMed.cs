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

namespace Store_System.Dispenser
{
    public partial class ViewMed : Form
    {
        public ViewMed()
        {
            InitializeComponent();
        }
        PSConnection obj = new PSConnection();

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = "Select*From medicine where medi_name like '" + txtSearch.Text + "%' ";
            DataSet ds = obj.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void ViewMed_Load(object sender, EventArgs e)
        {
            string query = "Select*From medicine";
            DataSet ds = obj.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
        String medicineSRNo;

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                medicineSRNo = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception)
            {
                //MessageBox.Show("Check Again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Guna.UI2.WinForms.MessageDialog.Show("Check Again", "ERROR", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
            }
        }
    }
}
