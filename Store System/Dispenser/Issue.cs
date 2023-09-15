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
using System.Text.RegularExpressions;

namespace Store_System.Dispenser
{
    public partial class Issue : Form
    {
        public Issue()
        {
            InitializeComponent();
        }
        PSConnection obj = new PSConnection();
        private void Issue_Load(object sender, EventArgs e)
        {
            LoadBillNo();
            //dt_billDate.ResetText();
            cmb_Pname.Items.Clear();
            string query = "Select medi_name from medicine order by medi_name asc";
            DataSet ds = obj.getData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cmb_Pname.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        public void LoadBillNo()
        {
            try
            {
                string query = "Select Bill_No from Bill order by Bill_No desc";
                DataSet ds = obj.getData(query);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txt_billNo.Text = (int.Parse(ds.Tables[0].Rows[0][0].ToString()) + 1).ToString();
                }
                else
                {
                    txt_billNo.Text = "1";
                }
            }
            catch(Exception ex)
            {
                Guna.UI2.WinForms.MessageDialog.Show(ex.Message, Guna.UI2.WinForms.MessageDialogStyle.Light);
            }
        }

        protected int n, totalAmount=0;
        protected Int64 quantity, issueqty;
        private void btnAddtoBill_Click(object sender, EventArgs e)
        { 
            try
            {
                if (cmb_Pname.Text == "")
                {
                    Guna.UI2.WinForms.MessageDialog.Show("Product Name is Empty", Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txtPricePU.Text == "")
                {
                    Guna.UI2.WinForms.MessageDialog.Show("Unit Price is Empty", Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txtQty.Text == "")
                {
                    Guna.UI2.WinForms.MessageDialog.Show("Quantity is Empty", Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txt_billNo.Text == "")
                {
                    Guna.UI2.WinForms.MessageDialog.Show("Bill No is Empty", Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txt_billNo.Text == "" && cmb_Pname.Text == "" && txtPricePU.Text == "" && txtQty.Text == "")
                {
                    Guna.UI2.WinForms.MessageDialog.Show("All are Empty", Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else
                {
                    /*(txt_Sn.Text =="")
                    {

                    }*/
                    string query = "select qty from medicine where medi_name = '" + cmb_Pname.SelectedItem + "'";
                    DataSet ds = obj.getData(query);
                    quantity = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                    issueqty = quantity - Int64.Parse(txtQty.Text);

                    if (issueqty >= 0)
                    {
                        n = guna2DataGridView1.Rows.Add();
                        guna2DataGridView1.Rows[n].Cells[1].Value = cmb_Pname.Text;
                        guna2DataGridView1.Rows[n].Cells[2].Value = txtPricePU.Text;
                        guna2DataGridView1.Rows[n].Cells[3].Value = txtQty.Text;
                        guna2DataGridView1.Rows[n].Cells[4].Value = txt_amt.Text;
                        guna2DataGridView1.Rows[n].Cells[5].Value = txt_billNo.Text;
                        guna2DataGridView1.Rows[n].Cells[6].Value = dt_billDate.Value.ToString("MM/dd/yyyy");

                        totalAmount = totalAmount + int.Parse(txt_amt.Text);
                        txt_TotBillAmt.Text = totalAmount.ToString();

                        string query1 = "update medicine set qty = '" + issueqty + "' where medi_name = '" + cmb_Pname.SelectedItem + "' ";
                        int line = obj.Add_Update_Delete(query1);
                        if (line == 1)
                        {
                            Guna.UI2.WinForms.MessageDialog.Show("Added Successfuly", "info", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Information, Guna.UI2.WinForms.MessageDialogStyle.Light);
                        }
                        else
                        {
                            Guna.UI2.WinForms.MessageDialog.Show("Can't Add ", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                        }
                       
                    }
                    else
                    {
                        Guna.UI2.WinForms.MessageDialog.Show("Medicine is Out of Stock.\n Only " + quantity + " Left ", "Warning !", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Warning, Guna.UI2.WinForms.MessageDialogStyle.Light);
                    }
                   
                    guna2DataGridView1.Refresh();
                    cmb_Pname.Focus();
                    Issue_Load(this, null);
                    clearAll();
                }
            }
            catch(Exception)
            {
                Guna.UI2.WinForms.MessageDialog.Show("Check again", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
            }
         

        }
        int valueAmount;
        String valueId;
        protected Int64 qty;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                valueAmount = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                valueId = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                qty = Int64.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            catch (NullReferenceException)
            {
                Guna.UI2.WinForms.MessageDialog.Show("Can't Remove", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
            }
        }

        private void cmb_Pname_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQty.Clear();
            string name = cmb_Pname.GetItemText(cmb_Pname.SelectedItem);
            cmb_Pname.Text = name;

            string query = "Select medi_name, Uprice from medicine where medi_name='" + name + "' ";
            DataSet ds = obj.getData(query);

            cmb_Pname.Text = ds.Tables[0].Rows[0][0].ToString();
            txtPricePU.Text = ds.Tables[0].Rows[0][1].ToString();       
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (txtQty.Text != "")
            {
                /*Int64 unitPrice = Int64.Parse(txtPricePU.Text);
                Int64 qty = Int64.Parse(txtQty.Text);
                Int64 totalAmount = Int64.Parse(txtPricePU.Text) * Int64.Parse(txtQty.Text);*/
                txt_amt.Text =( Int64.Parse(txtPricePU.Text) * Int64.Parse(txtQty.Text)).ToString();
            }
            else
            {
                txt_amt.Clear();
            }
        }

        private void guna2DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (valueId != null)
            {
                try
                {
                    guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
                }
                catch
                {

                }
                finally
                {  
                    string query = "select qty from medicine where medi_name = '" + valueId + "'";
                    DataSet ds = obj.getData(query);
                    quantity = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                    issueqty = quantity + qty;

                    string query3 = "update medicine set qty = '" + issueqty + "' where medi_name = '" + valueId + "' ";
                    int line = obj.Add_Update_Delete(query3);
                    if (line == 1)
                    {
                        Guna.UI2.WinForms.MessageDialog.Show("Medicine Removed from Bill.", "Infomation", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Information, Guna.UI2.WinForms.MessageDialogStyle.Light);
                    }
                    else
                    {
                        Guna.UI2.WinForms.MessageDialog.Show("Can't Remove ", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                    }

                    totalAmount = totalAmount - valueAmount;
                    txt_TotBillAmt.Text = totalAmount.ToString();
                }
                Issue_Load(this, null);
            }
        }
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        private void txt_discount_TextChanged(object sender, EventArgs e)
        { 
            if(txt_discount.Text != "")
            {
                txt_netPay.Text = (Int64.Parse(txt_TotBillAmt.Text) - Int64.Parse(txt_discount.Text)).ToString();
            }
            else
            {
                txt_netPay.Clear();
            }
           
        }
        private void clearAll()
        {
            cmb_Pname.SelectedIndex = -1;
            txtPricePU.Clear();
            txtQty.Clear();
            txt_amt.Clear();
        }
        private void clearBill()
        {
            dt_billDate.ResetText();
            guna2DataGridView1.Rows.Clear();
            txt_TotBillAmt.Clear();
            txt_discount.Clear();
            txt_netPay.Text ="";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2DataGridView1.Rows.Count < 1)
                {
                    Guna.UI2.WinForms.MessageDialog.Show("Add Minimum One Product to Bill", Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
               /* else if (cmb_Pname.Text == "" || txtPricePU.Text=="" || txtQty.Text=="" || txt_amt.Text=="" || txt_TotBillAmt.Text=="" || txt_discount.Text=="" || txt_netPay.Text=="")
                {
                    Guna.UI2.WinForms.MessageDialog.Show("Fill All", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }*/
                else if(txt_discount.Text == "")
                {
                    Guna.UI2.WinForms.MessageDialog.Show("Disscount amount cannot be blank", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if(!Regex.IsMatch(txt_discount.Text, "^[0-9]+$"))
                {
                    Guna.UI2.WinForms.MessageDialog.Show("Disscount amount cannot have Letters or Symbols", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else
                {
                    string query2 = "Insert into Bill(Bill_No,Bill_Date,Bill_Amount,Dis_Amount,Net_Pay)values('" + txt_billNo.Text + "','" + dt_billDate.Value.ToString("MM/dd/yyyy") + "','" + txt_TotBillAmt .Text+ "','" + txt_discount.Text+ "','" +txt_netPay.Text + "')";
                    int line2 = obj.Add_Update_Delete(query2);
                    if (line2 == 1)
                    {
                       // MessageBox.Show("Bill Saved", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //MessageBox.Show("Can't Save", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    for (int i = 0; i < guna2DataGridView1.Rows.Count-1 ; i++)
                    {
                        string query3 = "Insert into fullbill(fbName,unitP,qty,amt,billNo,billDate) values('" + guna2DataGridView1.Rows[n].Cells[1].Value + "','" + guna2DataGridView1.Rows[n].Cells[2].Value + "','" + guna2DataGridView1.Rows[n].Cells[3].Value + "','" + guna2DataGridView1.Rows[n].Cells[4].Value + "','" + guna2DataGridView1.Rows[n].Cells[5].Value + "','" + guna2DataGridView1.Rows[n].Cells[6].Value + "')";
                        int line3=obj.Add_Update_Delete(query3);
                        if (line3 == 1)
                        {
                            Guna.UI2.WinForms.MessageDialog.Show("Bill Saved", "info", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Information, Guna.UI2.WinForms.MessageDialogStyle.Light);
                        }
                        else
                        {
                            Guna.UI2.WinForms.MessageDialog.Show("Can't Save", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                        }    
                    }
                    clearAll();
                    clearBill();
                    View_Sales ps = new View_Sales();
                    ps.billno = txt_billNo.Text;
                    ps.ShowDialog();
                    LoadBillNo();
                    guna2DataGridView1.ClearSelection();
                }
               
            }
            catch(Exception)
            {
                Guna.UI2.WinForms.MessageDialog.Show("Check again", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
            }          
            
        }

        private void txt_TotBillAmt_TextChanged(object sender, EventArgs e)
        {

        }
        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void txt_discount_Leave(object sender, EventArgs e)
        {

        }

    }
}
