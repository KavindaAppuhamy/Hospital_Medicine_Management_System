using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Store_System.MedicinAdmin
{
    public partial class frm_adminUpdate : Form
    {
        public frm_adminUpdate()
        {
            InitializeComponent();
        }
        PSConnection obj = new PSConnection();

        Int64 totalQty;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_SrNo.Text == "" || txt_PName.Text == "" && txt_Manufacturer.Text == "" && txt_quantity.Text == "" && txt_AddQty.Text == "" && txt_PricePU.Text == "")
                {
                    //MessageBox.Show("Please Fill All", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Please Fill All", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txt_PName.Text == "")
                {
                    Guna.UI2.WinForms.MessageDialog.Show("P Name cannot be blank", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (!Regex.IsMatch(txt_PName.Text, "[^A-Za-z0-9]"))
                {
                    //MessageBox.Show("Pharmaceutical Name cannot have Symbols", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Pharmaceutical Name cannot have Symbols", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txt_Manufacturer.Text == "")
                {
                    Guna.UI2.WinForms.MessageDialog.Show("Manufacturer cannot be blank", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (!Regex.IsMatch(txt_Manufacturer.Text, @"^[a-zA-Z]+$"))
                {
                    //MessageBox.Show("Manufacturer Name cannot have Symbols", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Manufacturer Name cannot have Symbols", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txt_Manufacturer.Text.Any(char.IsDigit))
                {
                    //MessageBox.Show("Manufacturer cannot have numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Manufacturer cannot have numbers", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txt_quantity.Text == "")
                {
                    Guna.UI2.WinForms.MessageDialog.Show("Quantity cannot be blank", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (!Regex.IsMatch(txt_quantity.Text, "^[0-9]+$"))
                {
                    //MessageBox.Show("Quantity cannot have Letters or Symbols", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Quantity cannot have Letters or Symbols", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txt_AddQty.Text == "")
                {
                    Guna.UI2.WinForms.MessageDialog.Show("Add Quantity cannot be blank", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (!Regex.IsMatch(txt_AddQty.Text, "^[0-9]+$"))
                {
                    //MessageBox.Show("Quantity cannot have Letters or Symbols", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Add Quantity cannot have Letters or Symbols", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txt_PricePU.Text == "")
                {
                    Guna.UI2.WinForms.MessageDialog.Show("Price Per Unit cannot be blank", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (!Regex.IsMatch(txt_PricePU.Text, "^[0-9]+$"))
                {
                    //MessageBox.Show("Price cannot have Letters or Symbols", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Price cannot have Letters or Symbols", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }

                else
                {
                    totalQty = Int64.Parse(txt_quantity.Text) + Int64.Parse(txt_AddQty.Text);
                    string query = "Update medicine set medi_name ='" + txt_PName.Text + "', manufacturer ='" + txt_Manufacturer.Text + "', Mdate= '" + txt_UMdate.Text + "', Exdate= '" + txt_ExpiryDate.Text + "', qty= " + totalQty + ", Entrydate='" + date_Entry.Text + "' where srNo = '"+txt_SrNo.Text+"' ";
                    int line = obj.Add_Update_Delete(query);
                    if (line == 1)
                    {
                        //MessageBox.Show("Updated Successfuly", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Guna.UI2.WinForms.MessageDialog.Show("Updated Successfuly", "info", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Information, Guna.UI2.WinForms.MessageDialogStyle.Light);
                    }
                    else
                    {
                        //MessageBox.Show("Can't Update ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Guna.UI2.WinForms.MessageDialog.Show("Can't Update", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Check Again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Guna.UI2.WinForms.MessageDialog.Show("Check Again", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
            }
        }

        private void clearAll()
        {
            txt_SrNo.Clear();
            txt_PName.Clear();
            txt_Manufacturer.Clear();
            txt_UMdate.ResetText();
            txt_ExpiryDate.ResetText();
            txt_quantity.Clear();
            txt_AddQty.Clear();
            txt_PricePU.Clear();
            date_Entry.ResetText();

            if (txt_AddQty.Text != "0")
            {
                txt_AddQty.Text = "0";
            }
            else
            {
                txt_AddQty.Text = "0";
            }
        }
        private void btnUReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnSearch1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_SrNo.Text != "")
                {
                    string query = "Select*from medicine where srNo = '" + txt_SrNo.Text + "' ";
                    DataSet ds = obj.getData(query);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        /*txt_SrNo.Text = ds.Tables[0].Rows[0][3].ToString();*/
                        txt_PName.Text = ds.Tables[0].Rows[0][2].ToString();
                        txt_Manufacturer.Text = ds.Tables[0].Rows[0][3].ToString();
                        txt_UMdate.Text = ds.Tables[0].Rows[0][4].ToString();
                        txt_ExpiryDate.Text = ds.Tables[0].Rows[0][5].ToString();
                        txt_quantity.Text = ds.Tables[0].Rows[0][6].ToString();                 
                        txt_PricePU.Text = ds.Tables[0].Rows[0][7].ToString();
                        date_Entry.Text = ds.Tables[0].Rows[0][8].ToString();
                    }
                    else
                    {
                        //MessageBox.Show("No Medicine With SRNo : " + txt_SrNo.Text + " exitst.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Guna.UI2.WinForms.MessageDialog.Show("No Medicine With SRNo : " + txt_SrNo.Text + " exitst.", "info", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Information, Guna.UI2.WinForms.MessageDialogStyle.Light);
                    }
                }
                else
                {
                    clearAll();
                    //MessageBox.Show("Please Search and Add SRNo "+ " exitst.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Guna.UI2.WinForms.MessageDialog.Show("Please Search and Add SRNo ", "info", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Information, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Database Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Guna.UI2.WinForms.MessageDialog.Show("Database Error", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
            }
        }
    }

}

