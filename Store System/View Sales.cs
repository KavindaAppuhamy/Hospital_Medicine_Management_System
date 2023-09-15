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
    public partial class View_Sales : Form
    {
        public string billno { get; set; }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0RQOAPG;Initial Catalog=pharmacy;Integrated Security=True");
        public View_Sales()
        {
            InitializeComponent();
        }

        private void View_Sales_Load(object sender, EventArgs e)
        {
            txt_billNo2.Text = billno;
        }

        private void btn_findBill_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select Bill.Bill_No, Bill.Bill_Date, Bill.Bill_Amount, Bill.Dis_Amount, Bill.Net_Pay, fullbill.fbName, fullbill.unitP, fullbill.qty, fullbill.amt, fullbill.billNo from Bill inner join fullbill on Bill.Bill_No=fullbill.billNo where Bill.Bill_No = '"+txt_billNo2.Text+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet3", dt);
            reportViewer1.LocalReport.ReportPath = @"D:\GAD Project\Store System\PrintBills.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
