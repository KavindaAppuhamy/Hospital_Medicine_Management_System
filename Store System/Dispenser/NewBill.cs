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
    public partial class NewBill : Form
    {
        public NewBill()
        {
            InitializeComponent();
        }
        PSConnection obj = new PSConnection();
        private void NewBill_Load(object sender, EventArgs e)
        {
            string query = "Select medi_name from medicine order by medi_name asc";
            DataSet ds = obj.getData(query);
        }
    }
}
