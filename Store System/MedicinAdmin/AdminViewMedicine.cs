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
    public partial class frm_adminView : Form
    {
        public frm_adminView()
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

        private void frm_adminView_Load(object sender, EventArgs e)
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Guna.UI2.WinForms.MessageDialog.Show("Are you Sure?", "Delete Confirmation !", Guna.UI2.WinForms.MessageDialogButtons.YesNo, Guna.UI2.WinForms.MessageDialogIcon.Warning, Guna.UI2.WinForms.MessageDialogStyle.Light) == DialogResult.Yes)
            {
                String query = "Delete from medicine where srNo ='" + medicineSRNo + "'";
                int line = obj.Add_Update_Delete(query);
                if (line == 1)
                {
                   // MessageBox.Show("Deleted Successfuly", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Guna.UI2.WinForms.MessageDialog.Show("Deleted Successfuly", "info", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Information, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else
                {
                    //MessageBox.Show("Can't Delete ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Can't Delete ", "ERROR", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                frm_adminView_Load (this, null);
            }
        }


    }
}
