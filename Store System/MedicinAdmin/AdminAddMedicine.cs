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
    public partial class frm_adminadd : Form
    {
        public frm_adminadd()
        {
            InitializeComponent();
        }

        PSConnection obj = new PSConnection();
        private void frm_adminadd_Load(object sender, EventArgs e)
        {

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtSrNo.Text=="" && txtPname.Text=="" && txtManufacturer.Text=="" && txtQuantity.Text=="" && txtPricePU.Text=="" )
                {
                    Guna.UI2.WinForms.MessageDialog.Show("Please Fill All", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txtSrNo.Text == "" )
                {
                    Guna.UI2.WinForms.MessageDialog.Show("SrNo cannot be blank", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (!Regex.IsMatch(txtSrNo.Text, "^[0-9]+$"))
                {
                    //MessageBox.Show("SR No cannot have Letters or Symbols", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("SR No cannot have Letters or Symbols", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txtPname.Text == "")
                {
                    Guna.UI2.WinForms.MessageDialog.Show("P Name cannot be blank", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (!Regex.IsMatch(txtPname.Text, "[^A-Za-z0-9]"))
                {
                    //MessageBox.Show("Pharmaceutical Name cannot have Symbols", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Pharmaceutical Name cannot have Symbols", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txtManufacturer.Text == "")
                {
                    Guna.UI2.WinForms.MessageDialog.Show("Manufacturer cannot be blank", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (!Regex.IsMatch(txtManufacturer.Text, @"^[a-zA-Z]+$"))
                {
                    //MessageBox.Show("Manufacturer Name cannot have Symbols", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Manufacturer Name cannot have Symbols", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txtManufacturer.Text.Any(char.IsDigit))
                {
                    //MessageBox.Show("Manufacturer cannot have numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Manufacturer cannot have numbers", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txtQuantity.Text == "")
                {
                    Guna.UI2.WinForms.MessageDialog.Show("Quantity cannot be blank", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (!Regex.IsMatch(txtQuantity.Text, "^[0-9]+$"))
                {
                    //MessageBox.Show("Quantity cannot have Letters or Symbols", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Quantity cannot have Letters or Symbols", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txtPricePU.Text == "")
                {
                    Guna.UI2.WinForms.MessageDialog.Show("Price Per Unit cannot be blank", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (!Regex.IsMatch(txtPricePU.Text, "^[0-9]+$"))
                {
                    //MessageBox.Show("Price cannot have Letters or Symbols", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Price cannot have Letters or Symbols", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }

                else
                {
                    string CheckSRNo = "select srNo from medicine where srNo='"+txtSrNo.Text+"'";
                    DataSet ds = obj.getData(CheckSRNo);
                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        //MessageBox.Show("Already exist SRNo", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Guna.UI2.WinForms.MessageDialog.Show("Already exist SRNo", "info", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Information, Guna.UI2.WinForms.MessageDialogStyle.Light);
                    }
                    else
                    {
                        string query = "Insert into medicine values('" + txtSrNo.Text + "','" + txtPname.Text + "','" + txtManufacturer.Text + "','" + dtp_dateM.Text + "','" + dtp_dateE.Text + "','" + txtQuantity.Text + "','" + txtPricePU.Text + "','" + dtp_dateEntry.Text + "')";
                        int line = obj.Add_Update_Delete(query);
                        if (line == 1)
                        {
                           // MessageBox.Show("Added Successfuly", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Guna.UI2.WinForms.MessageDialog.Show("Added Successfuly", "info", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Information, Guna.UI2.WinForms.MessageDialogStyle.Light);
                        }
                        else
                        {
                            //MessageBox.Show("Can't Add ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Guna.UI2.WinForms.MessageDialog.Show("Can't Add", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                        }
                    }
                 
                }
            }
            catch(Exception)
            {
                //MessageBox.Show("Check Again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Guna.UI2.WinForms.MessageDialog.Show("Check Again", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSrNo.Clear();
            txtPname.Clear();
            txtManufacturer.Clear();
            dtp_dateM.ResetText();
            dtp_dateE.ResetText();
            txtQuantity.Clear();
            txtPricePU.Clear();
            dtp_dateEntry.ResetText();
        }
    }
}
