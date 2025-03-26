using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class DoctorForm : Form
    {
        SqlConnection sqlCon = new SqlConnection(DBCommon.connString);
        public DoctorForm()
        {
            InitializeComponent();

            txtUserName.Visible = false;
            txtPassword.Visible = false;
            chkFiveLoginPermission.Checked = true;
            LoadDoctors();
        }

        private void LoadDoctors()
        {
            sqlCon = BusinessLayer.CmnMethods.OpenConnectionString(sqlCon);
            string query = "SELECT * FROM View_Doctor";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            var dataSet = new DataSet();
            sda.Fill(dataSet);
            doctorDataGridView.DataSource = dataSet.Tables[0];
            sqlCon.Close();

            doctorDataGridView.Columns[0].Visible = false;
        }

        private void Reset()
        {
            txtDocId.Text = 0.ToString();
            txtUserName.Text = 0.ToString();
            txtDocName.Text = "";
            txtYOE.Text = "";
            txtAge.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
        }

        private void DoctorForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
        }

        private void chkFiveLoginPermission_CheckedChanged(object sender, EventArgs e)
        {
            HideShowUsernamePassword();
        }

        private void HideShowUsernamePassword()
        {
            txtUserName.Visible = chkFiveLoginPermission.Checked;
            txtPassword.Visible = chkFiveLoginPermission.Checked;
        }

        private void txtYOE_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //Only allow int
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //Only allow int
        }

        private void doctorDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (doctorDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && !string.IsNullOrWhiteSpace(doctorDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
            {
                doctorDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { ForeColor = Color.Black };
            }
            else
            {
                doctorDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = doctorDataGridView.DefaultCellStyle;
            }
        }

        private void doctorDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDocId.Text = doctorDataGridView.Rows[e.RowIndex].Cells["DoctorId"].Value.ToString();
            txtUserLoginId.Text = doctorDataGridView.Rows[e.RowIndex].Cells["LoginUserId"].Value.ToString();
            txtDocName.Text = doctorDataGridView.Rows[e.RowIndex].Cells["DocName"].Value.ToString();
            txtAge.Text = doctorDataGridView.Rows[e.RowIndex].Cells["Age"].Value.ToString();
            txtYOE.Text = doctorDataGridView.Rows[e.RowIndex].Cells["YearOfExperience"].Value.ToString();
            txtContact.Text = doctorDataGridView.Rows[e.RowIndex].Cells["Contact"].Value.ToString();
            txtAddress.Text = doctorDataGridView.Rows[e.RowIndex].Cells["Address"].Value.ToString();

            int loginUserId = Convert.ToInt32(doctorDataGridView.Rows[e.RowIndex].Cells["LoginUserId"].Value.ToString());
            chkFiveLoginPermission.Checked = loginUserId > 0 ? true : false;
            HideShowUsernamePassword();
            txtUserName.Text = doctorDataGridView.Rows[e.RowIndex].Cells["Username"].Value.ToString();
            txtPassword.Text = doctorDataGridView.Rows[e.RowIndex].Cells["UserPassword"].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDocName.Text.Trim() == "" || txtYOE.Text.Trim() == "" || txtAge.Text.Trim() == "" || txtContact.Text.Trim() == "Category" || txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(DBCommon.connString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string query = "";
                        int userLoginId = 0;
                        bool hasError = false;
                        if (chkFiveLoginPermission.Checked)
                        {
                            if (txtUserName.Text.Trim() == "" || txtPassword.Text.Trim() == "")
                            {
                                MessageBox.Show("Vui lòng nhập Username & Password!");
                                hasError = true;
                            }
                            else
                            {
                                query = @"INSERT INTO UserInfo (Username,UserPassword,UserType,AddedDate,AddedBy) VALUES (@Username,@UserPassword,@UserType,@AddedDate,@AddedBy);
                                    SELECT SCOPE_IDENTITY();";

                                SqlCommand cmd = new SqlCommand(query, conn, transaction);
                                cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                                cmd.Parameters.AddWithValue("@UserPassword", txtPassword.Text.Trim());
                                cmd.Parameters.AddWithValue("@UserType", 2); //2 means Doctor
                                cmd.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                                cmd.Parameters.AddWithValue("@AddedBy", Global.UserInfo.UserId);

                                userLoginId = Convert.ToInt32(cmd.ExecuteScalar());
                            }
                        }
                        if (!hasError)
                        {
                            query = @"INSERT INTO Doctor (DocName, Age, YearOfExperience, Contact, Address, LoginUserId, AddedDate, AddedBy) VALUES (@DocName, @Age, @YearOfExperience, @Contact, @Address, @LoginUserId, @AddedDate, @AddedBy)";
                            SqlCommand cmd = new SqlCommand(query, conn, transaction);
                            cmd.Parameters.AddWithValue("@DocName", txtDocName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Age", txtAge.Text.Trim());
                            cmd.Parameters.AddWithValue("@YearOfExperience", txtYOE.Text.Trim());
                            cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                            cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                            cmd.Parameters.AddWithValue("@LoginUserId", userLoginId);
                            cmd.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@AddedBy", Global.UserInfo.UserId); //Login User ID;
                            cmd.ExecuteNonQuery();
                            transaction.Commit();

                            MessageBox.Show("Lưu thành công!");
                            LoadDoctors();
                            Reset();
                        }
                        else
                        {
                            transaction.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                        transaction.Rollback();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtDocId.Text.Trim() == "" || txtDocId.Text.Trim() == 0.ToString())
            {
                MessageBox.Show("Vui lòng chọn bác sĩ cần sửa!");
            }
            if (txtDocName.Text.Trim() == "" || txtYOE.Text.Trim() == "" || txtAge.Text.Trim() == "" || txtContact.Text.Trim() == "Category" || txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(DBCommon.connString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        string query = "";
                        bool hasError = false;
                        if (chkFiveLoginPermission.Checked)
                        {
                            if (txtUserName.Text.Trim() == "" || txtPassword.Text.Trim() == "")
                            {
                                MessageBox.Show("Vui lòng nhập Username & Password!");
                                hasError = true;
                            }
                            else
                            {
                                query = @"UPDATE UserInfo SET Username=@Username, UserPassword=@UserPassword WHERE UserId = @UserId";
                                SqlCommand cmd = new SqlCommand(query, conn, transaction);
                                cmd.Parameters.AddWithValue("@UserId", txtUserLoginId.Text.Trim());
                                cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                                cmd.Parameters.AddWithValue("@UserPassword", txtPassword.Text.Trim());
                                cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
                                cmd.Parameters.AddWithValue("@UpdatedBy", Global.UserInfo.UserId); 
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            if(txtUserLoginId.Text.Trim() == "" || txtUserLoginId.Text.Trim() == 0.ToString())
                            {
                                MessageBox.Show("ID đăng nhập người dùng không hợp lệ");
                                hasError = true;
                            }
                            else
                            {
                                query = @"DELETE FROM UserInfo WHERE UserId = @UserId";
                                SqlCommand cmd = new SqlCommand(query, conn, transaction);
                                cmd.Parameters.AddWithValue("@UserId", txtUserLoginId.Text.Trim());
                                cmd.ExecuteNonQuery();
                            }
                        }
                        if (!hasError)
                        {
                            query = @"UPDATE Doctor SET DocName=@DocName, Age=@Age, YearOfExperience=@YearOfExperience, Contact=@Contact, Address=@Address, LoginUserId=@LoginUserId, UpdatedDate=@UpdatedDate, UpdatedBy=@UpdatedBy WHERE DoctorId = @DoctorId";
                            SqlCommand cmd = new SqlCommand(query, conn, transaction);
                            cmd.Parameters.AddWithValue("@DoctorId", txtDocId.Text.Trim());
                            cmd.Parameters.AddWithValue("@DocName", txtDocName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Age", txtAge.Text.Trim());
                            cmd.Parameters.AddWithValue("@YearOfExperience", txtYOE.Text.Trim());
                            cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                            cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                            cmd.Parameters.AddWithValue("@LoginUserId", txtUserLoginId.Text.Trim());
                            cmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@UpdatedBy", Global.UserInfo.UserId);
                            cmd.ExecuteNonQuery();
                            transaction.Commit();

                            MessageBox.Show("Sửa thành công!");
                            LoadDoctors();
                            Reset();
                        }
                        else
                        {
                            transaction.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                            transaction.Rollback();
                        }
                    finally
                    {
                        conn.Close();
                    }   
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtDocId.Text.Trim() == "" || Convert.ToInt32(txtDocId.Text) == 0)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ cần xóa!");
            }
            else
            {
                sqlCon = BusinessLayer.CmnMethods.OpenConnectionString(sqlCon);
                string query = string.Format(@"SELECT * FROM Dianosis WHERE DoctorId = {0}", Convert.ToInt32(txtDocId.Text));
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                var dataSet = new DataSet();
                sda.Fill(dataSet);
                var doctors = dataSet.Tables[0];
                sqlCon.Close();

                if(doctors.Rows != null && doctors.Rows.Count > 0)
                {
                    MessageBox.Show("Đã có chẩn đoán của bác sĩ này");
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(DBCommon.connString))
                    {
                        conn.Open();
                        SqlTransaction transaction = conn.BeginTransaction();
                        try
                        {
                            query = string.Format(@"DELETE FROM Doctor WHERE DoctorId = {0}", Convert.ToInt32(txtDocId.Text));
                            SqlCommand cmd = new SqlCommand(query, conn, transaction);
                            cmd = new SqlCommand(query, conn, transaction);
                            cmd.ExecuteNonQuery();

                            query = @"DELETE FROM UserInfo WHERE UserId = @UserId";
                            cmd = new SqlCommand(query, conn, transaction);
                            cmd.Parameters.AddWithValue("@UserId", txtUserLoginId.Text.Trim());
                            cmd.ExecuteNonQuery();
                            transaction.Commit();

                            MessageBox.Show("Xóa thành công!");
                            LoadDoctors();
                            Reset();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                        transaction.Rollback();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}
}
