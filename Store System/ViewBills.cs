using Microsoft.Reporting.WinForms;
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

namespace Store_System
{
    public partial class ViewBills : Form
    {
        public ViewBills()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0RQOAPG;Initial Catalog=pharmacy;Integrated Security=True");
        private void ViewBills_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pharmacyDataSet.Bill' table. You can move, or remove it, as needed.
            //this.BillTableAdapter.Fill(this.pharmacyDataSet.Bill);

            SqlCommand cmd = new SqlCommand("select*from Bill", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.ReportPath = @"D:\GAD Project\Store System\Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();  
        }
        
        private void btn_Viewbills_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select*from Bill where Bill_Date between '" + dt_from.Value.ToString("MM/dd/yyyy") + "' and '" + dt_to.Value.ToString("MM/dd/yyyy") + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.ReportPath = @"D:\GAD Project\Store System\Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
        }
        private void reportViewer1_Load(object sender, EventArgs e)
        {
           
        }

     
    }
}
