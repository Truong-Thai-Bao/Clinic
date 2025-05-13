using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DataLayer;
using DataTransferLayer;
namespace PresentationLayer
 
{
    public partial class Form1 : Form
    {
        private LoginBL loginBL;
        private UserInfoBL getUserInfoBL;
        SqlConnection sqlCon = new SqlConnection(DBCommon.connString);
        public Form1()
        {
            InitializeComponent();
            loginBL = new LoginBL();
            getUserInfoBL = new UserInfoBL();
        }


        private bool UserLogin(Account account)
        {
            try
            {
                return loginBL.Login(account);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string pass = txtPassword.Text.Trim();
            if (username ==""|| pass == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username & Password!");
                txtUserName.Focus();
            }
            else
            {
                Account account = new Account(username, pass);
                if (UserLogin(account))
                {
                    DataTransferLayer.UserInfo userInfo = getUserInfoBL.GetUserInfo(account);
                    this.DialogResult = DialogResult.OK;
                    this.Hide();
                    MenuForm menuForm = new MenuForm(userInfo);
                    menuForm.ShowDialog();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Tên người dùng hoặc mật khẩu không đúng", "Danger",
                        MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Retry)
                    {
                        txtPassword.Clear();
                        txtUserName.Focus();
                        txtPassword.Clear();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Username!");
                txtUserName.Focus();
            }
            else
            {
                Account account = new Account(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                getUserInfoBL.InsertInfo(account);

                MessageBox.Show("Đăng ký thành công! Mời bạn đăng nhập.");
                sqlCon.Close();
            }
        }

        private void lblForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ResetPassword resetPassword = new ResetPassword();
            resetPassword.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
