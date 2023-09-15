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
    public partial class ValidityCheck : Form
    {
        public ValidityCheck()
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
    }
}
