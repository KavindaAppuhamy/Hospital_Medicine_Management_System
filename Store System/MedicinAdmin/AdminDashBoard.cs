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
    public partial class frm_adminDashboard : Form
    {
        Int64 count;
        public frm_adminDashboard()
        {
            InitializeComponent();
        }
        PSConnection obj = new PSConnection();

        private void frm_adminDashboard_Load(object sender, EventArgs e)
        {
            loadChart();
        }

        public void loadChart()
        {
            try 
            {
                string query = "Select count(medi_name) from medicine";
                DataSet ds = obj.getData(query);
                count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                this.chart1.Series["All Medicines"].Points.AddXY("Medicine Validity Chart", count);

                string query1 = "Select count(medi_name) from medicine where  Exdate >= getdate()";
                DataSet ds1 = obj.getData(query1);
                count = Int64.Parse(ds1.Tables[0].Rows[0][0].ToString());
                this.chart1.Series["Valid Medicine"].Points.AddXY("Medicine Validity Chart", count);

                string query2 = "Select count(medi_name) from medicine where  DATEDIFF(Month,GETDATE(),Exdate)=6";
                DataSet ds2 = obj.getData(query2);
                count = Int64.Parse(ds2.Tables[0].Rows[0][0].ToString());
                this.chart1.Series["Expire Soon Medicines"].Points.AddXY("Medicine Validity Chart", count);

                string query3 = "Select count(medi_name) from medicine where  Exdate <= getdate()";
                DataSet ds3 = obj.getData(query3);
                count = Int64.Parse(ds3.Tables[0].Rows[0][0].ToString());
                this.chart1.Series["Expired Medicine"].Points.AddXY("Medicine Validity Chart", count);

            }
            catch(SqlException)
            {
                //MessageBox.Show("Database Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Guna.UI2.WinForms.MessageDialog.Show("Database Error", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
            }
        }
    }
}
