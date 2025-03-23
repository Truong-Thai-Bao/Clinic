using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DataLayer;
namespace PresentationLayer
 
{
    public partial class Form1 : Form
    {

        SqlConnection sqlCon = new SqlConnection(DBCommon.connString);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text.Trim() ==""|| txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Username & Password!");
                txtUserName.Focus();
            }
            else
            {
                sqlCon = BusinessLayer.CmnMethods.OpenConnectionString(sqlCon);
                string query = string.Format(@"Select * From View_UserInfo Where Username = '{0}' 
                                                                    and Password ='{1}'", txtUserName.Text.Trim(),txtPassword.Text.Trim());
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    this.Hide();
                    MenuForm form = new MenuForm();
                    form.Show();

                    CmnMethods.GetUserInfo(dt);
                }
                else
                {
                    MessageBox.Show("Username hoặc Password không đúng!");
                    txtUserName.Focus();
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
                sqlCon = BusinessLayer.CmnMethods.OpenConnectionString(sqlCon);
                string query = @"INSERT INTO UserInfo (Username, UserPassword, UserType, AddedDate, AddedBy) VALUES (@Username, @UserPassword, @UserType, @AddedDate, @AddedBy)";
                SqlCommand command = new SqlCommand(query, sqlCon);
                command.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                command.Parameters.AddWithValue("@UserPassword", txtPassword.Text.Trim());
                command.Parameters.AddWithValue("@UserType", 1); //1 means Admin
                command.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                command.Parameters.AddWithValue("@AddedBy", Global.UserInfo.UserId);
                command.ExecuteNonQuery();
                MessageBox.Show("Đăng ký thành công! Mời bạn đăng nhập.");
                sqlCon.Close();
            }
        }
    }
}
