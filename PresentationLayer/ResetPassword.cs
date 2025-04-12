using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class ResetPassword : Form
    {
        private string generatedOTP = "";
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {

        }

        private void btnOTP_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản.");
                return;
            }

            Random rand = new Random();
            generatedOTP = rand.Next(100000, 999999).ToString();

            MessageBox.Show("Mã xác nhận của bạn là: " + generatedOTP);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string otp = txtOTP.Text.Trim();
            string newPass = txtNewPassword.Text;

            if (otp != generatedOTP)
            {
                MessageBox.Show("Mã xác nhận không đúng!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(DataLayer.DBCommon.connString))
            {
                string sql = "UPDATE UserInfo SET UserPassword = @pass WHERE Username = @user";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pass", newPass);
                cmd.Parameters.AddWithValue("@user", username);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Đặt lại mật khẩu thành công!");
                    this.Close();
                    Form1 form = new Form1();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản.");
                }
            }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
