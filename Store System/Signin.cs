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
    public partial class Signin : Form
    {
        public Signin()
        {
            InitializeComponent();
        }
        SqlConnection con;

        private void Signin_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-0RQOAPG;Initial Catalog=pharmacy;Integrated Security=True");
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_role.SelectedItem == null || txt_username.Text == null || txt_password.Text == null)
                {
                    //MessageBox.Show("Please Fill All", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Please Fill All", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (cmb_role.SelectedItem == null)
                {
                    //MessageBox.Show("Please Select Role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Please Select Role", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (string.IsNullOrEmpty(txt_username.Text))
                {
                    //MessageBox.Show("Username cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Username cannot be blank", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else if (txt_password.Text.Length == 0)
                {
                    //MessageBox.Show("Please Enter your Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Guna.UI2.WinForms.MessageDialog.Show("Please Enter your Password", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("select*from users where userRole='"+cmb_role.SelectedItem+"' and username='" + txt_username.Text + "' and pass='" + txt_password.Text + "' ",con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    string cmbItemValue = cmb_role.SelectedItem.ToString();
                    if(dt.Rows.Count>0)
                    {
                        for (int i=0; i<dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["userRole"].ToString() == cmbItemValue)
                            {
                                /*MessageBox.Show("You are Login as\t"+dt.Rows[i][2],"success");*/
                                if (cmb_role.SelectedIndex == 0)
                                {                                   
                                    MainMenu mm = new MainMenu();
                                    mm.ShowDialog();
                                    this.Hide();
                                }
                                else if (cmb_role.SelectedIndex == 1)
                                {                                    
                                    Pharmacist pn = new Pharmacist();
                                    pn.ShowDialog();
                                    this.Hide();
                                }                             
                            }
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Incorrect Email or Password","error" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Guna.UI2.WinForms.MessageDialog.Show("Incorrect Username or Password", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
                    }
                }
                
            }
            catch(SqlException)
            {
                //MessageBox.Show("Database Error", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Guna.UI2.WinForms.MessageDialog.Show("Database Error", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
            }
            catch(Exception)
            {
                //MessageBox.Show("Check again", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Guna.UI2.WinForms.MessageDialog.Show("Check again", "Error", Guna.UI2.WinForms.MessageDialogButtons.OK, Guna.UI2.WinForms.MessageDialogIcon.Error, Guna.UI2.WinForms.MessageDialogStyle.Light);
            }   
        }
        private void check_pass_CheckedChanged_1(object sender, EventArgs e)
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
        private void btn_clear_Click(object sender, EventArgs e)
        {
            cmb_role.SelectedIndex = -1;
            txt_username.Clear();
            txt_password.Clear();
        }
        private void cmb_role_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
