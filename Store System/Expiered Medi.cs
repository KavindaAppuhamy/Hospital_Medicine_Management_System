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
    public partial class Expiered_Medi : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0RQOAPG;Initial Catalog=pharmacy;Integrated Security=True");
        public Expiered_Medi()
        {
            InitializeComponent();
        }

        private void Expiered_Medi_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM medicine WHERE Exdate <= getdate()", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet4", dt);
            reportViewer1.LocalReport.ReportPath = @"D:\GAD Project\Store System\Report medi.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
