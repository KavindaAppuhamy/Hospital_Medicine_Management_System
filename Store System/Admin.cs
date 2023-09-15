using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Store_System
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        PSConnection obj = new PSConnection();
        Random rand = new Random();
        int otp;
        private void Admin_Load(object sender, EventArgs e)
        {
            userId();
        }

        void userId()
        {
            try
            {
                string query = "select Userid from Users order by Userid desc";
                DataSet ds = obj.getData(query);
                if (ds.Tables[0].Rows.Count>0)
                {
                    txt_userId.Text = (int.Parse(ds.Tables[0].Rows[0][0].ToString()) + 1).ToString();
                }
                else
                {
                    txt_userId.Text = "1";
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                Guna.UI2.WinForms.MessageDialog.Show(ex.Message);
            }
        }
        private void btn_sendOtp_Click(object sender, EventArgs e)
        {
            otp = rand.Next(10000, 100000);
            try
            {

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("pharmacyatom@gmail.com");
                msg.To.Add(txt_email.Text);
                msg.Subject = "OTP Code";
                msg.Body =otp.ToString();

                SmtpClient smt = new SmtpClient();
                smt.Host = "smtp.gmail.com";
                System.Net.NetworkCredential ntcd = new NetworkCredential();
                ntcd.UserName = "pharmacyatom@gmail.com";
                ntcd.Password = "ilnagltixwvcmjno";
                smt.Credentials = ntcd;
                smt.EnableSsl = true;
                smt.Port = 587;
                smt.Send(msg);

                //MessageBox.Show("Your Mail is sended");
                Guna.UI2.WinForms.MessageDialog.Show("Your Mail is sended");

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                Guna.UI2.WinForms.MessageDialog.Show(ex.Message);
            }
        }
        private void btn_register_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_role.SelectedItem == null || txt_name.Text == null || txt_phnnum.Text == null || txt_email.Text == null || txt_username.Text==null || txt_password.Text==null || txt_confirmpw.Text==null || txt_otp.Text==null)
                {
                    //MessageBox.Show("Please Fill All", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Please Fill All", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if(cmb_role.SelectedItem == null)
                {
                    //MessageBox.Show("Please Select Role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Please Select Role", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if(string.IsNullOrEmpty(txt_name.Text))
                {
                    //MessageBox.Show("Name cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Name cannot be blank", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);

                }
                else if(txt_name.Text.Any(char.IsDigit))
                {
                    //MessageBox.Show("Name cannot have numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Name cannot have numbers", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if(! Regex.IsMatch(txt_name.Text, @"^[a-zA-Z]+$"))
                {
                    //MessageBox.Show("Name cannot have Symbols", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Name cannot have Symbols", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (!Regex.IsMatch(txt_phnnum.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                {
                    //MessageBox.Show("Phone No must have 10 numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Phone No must have 10 numbers", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (!Regex.IsMatch(txt_email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    //MessageBox.Show("Enter a valid email. Ex:name@gmail.com", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Enter a valid email.Ex:name@gmail.com", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if(string.IsNullOrEmpty(txt_username.Text))
                {
                    //MessageBox.Show("Username cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Username cannot be blank", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txt_password.Text.Length == 0)
                {
                   //MessageBox.Show("Please Enter your Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Please Enter your Password", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txt_confirmpw.Text.Length == 0)
                {
                    //MessageBox.Show("Please Confirm your Correct Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Please Confirm your Correct Password", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txt_password.Text != txt_confirmpw.Text)
                {
                    //MessageBox.Show("Confirm Password must same as the Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Confirm Password must same as the Password", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if(string.IsNullOrEmpty(txt_otp.Text))
                {
                    //MessageBox.Show("OTP cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("OTP cannot be blank", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if(otp.ToString() != (txt_otp.Text))
                {
                    //MessageBox.Show("Incorrect OTP");
                    Guna.UI2.WinForms.MessageDialog.Show("Incorrect OTP", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else
                {
                    string query = "Insert into users values('" + txt_userId.Text + "','" + cmb_role.SelectedItem + "','" + txt_name.Text + "','" + txt_phnnum.Text + "','" + txt_email.Text + "','" + txt_username.Text + "','" + txt_password.Text + "','" + txt_confirmpw.Text + "','" + txt_otp.Text + "')";
                    int line = obj.Add_Update_Delete(query);
                    if (line == 1)
                    {
                        //MessageBox.Show("Registered Successfuly", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Guna.UI2.WinForms.MessageDialog.Show("Registered Successfuly", "info", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Information, Guna.UI2.WinForms.MessageDialogStyle.Light);
                    }
                    else
                    {
                        //MessageBox.Show("UnSuccessfuly Registered", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Guna.UI2.WinForms.MessageDialog.Show("UnSuccessfuly Registered", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                    }            
                }
            }
            catch(Exception)
            {
                //MessageBox.Show("Check Again", "ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
                Guna.UI2.WinForms.MessageDialog.Show("Check Again", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
            }
        }
        private void check_pass_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pass.Checked)
            {
                txt_password.PasswordChar = '\0';
            }
            else
            {
                txt_password.PasswordChar = '•';
            }
        }

        private void check_Cpass_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Cpass.Checked)
            {
                txt_confirmpw.PasswordChar = '\0';
            }
            else
            {
                txt_confirmpw.PasswordChar = '•';
            }
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartPage ns = new StartPage();
            ns.Show();
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            cmb_role.SelectedIndex = -1;
            txt_name.Clear();
            txt_phnnum.Clear();
            txt_email.Clear();
            txt_username.Clear();
            txt_password.Clear();
            txt_confirmpw.Clear();
            txt_otp.Clear();
        }
        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
