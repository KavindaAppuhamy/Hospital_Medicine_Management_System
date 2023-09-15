using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Store_System
{
    class PSConnection
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
       
        
        public PSConnection()
        {
            con = new SqlConnection("Data Source=DESKTOP-0RQOAPG;Initial Catalog=pharmacy;Integrated Security=True");
        }

        public int Add_Update_Delete(string q)
        {
            con.Open();
            cmd = new SqlCommand(q, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataSet getData(string q)
        {
            con.Open();
            da = new SqlDataAdapter(q, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }


        public void getData2(string q)
        {
            con.Open();
            cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            con.Close();

        }
    }
}
