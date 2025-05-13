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
using DataTransferLayer;

namespace PresentationLayer
{
    public partial class DoctorForm : Form
    {
        private UserInfo currentUser;
        private DoctorBL doctorBL = new DoctorBL();

        public DoctorForm(UserInfo currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;

            txtUserName.Visible = false;
            txtPassword.Visible = false;
            chkFiveLoginPermission.Checked = true;
            LoadDoctors();
        }

        private void LoadDoctors()
        {
            try
            {
                var doctors = doctorBL.GetAllDoctorsFromView();
                doctorDataGridView.DataSource = doctors;
                if (doctorDataGridView.Columns["DoctorId"] != null)
                {
                    doctorDataGridView.Columns["DoctorId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách bác sĩ: " + ex.Message);
            }
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
            MenuForm menuForm = new MenuForm(currentUser);
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
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //Chỉ cho phép int
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //Chỉ cho phép int
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
            if (e.RowIndex > 0)
            {
                var doctor = doctorDataGridView.Rows[e.RowIndex].DataBoundItem as DoctorDTO;
                if (doctor != null)
                {
                    txtDocId.Text = doctor.DoctorId.ToString();
                    txtUserLoginId.Text = doctor.LoginUserId.ToString();
                    txtDocName.Text = doctor.DocName;
                    txtAge.Text = doctor.Age.ToString();
                    txtYOE.Text = doctor.YearOfExperience.ToString();
                    txtContact.Text = doctor.Contact;
                    txtAddress.Text = doctor.Address;
                    chkFiveLoginPermission.Checked = doctor.LoginUserId > 0 ? true : false;
                    HideShowUsernamePassword();
                    txtUserName.Text = doctor.UserName;
                    txtPassword.Text = doctor.UserPassword;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDocName.Text) || string.IsNullOrWhiteSpace(txtYOE.Text) ||
                string.IsNullOrWhiteSpace(txtAge.Text) || string.IsNullOrWhiteSpace(txtContact.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkFiveLoginPermission.Checked && (string.IsNullOrWhiteSpace(txtUserName.Text)
                || string.IsNullOrWhiteSpace(txtPassword.Text)))
            {
                MessageBox.Show("Vui lòng nhập Username & Password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var doctor = new DoctorDTO
                {
                    DocName = txtDocName.Text.Trim(),
                    Age = Convert.ToInt32(txtAge.Text.Trim()),
                    YearOfExperience = Convert.ToInt32(txtYOE.Text.Trim()),
                    Contact = txtContact.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                };

                doctorBL.AddDoctor(
                    doctor,
                    chkFiveLoginPermission.Checked ? txtUserName.Text.Trim() : null,
                    chkFiveLoginPermission.Checked ? txtPassword.Text.Trim() : null,
                    2, //2 = Doctor
                    currentUser.UserId
                );

                MessageBox.Show("Lưu thành công!", "Thành công", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDoctors();
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu bác sĩ: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtDocId.Text) || txtDocId.Text.Trim() == "0")
            {
                MessageBox.Show("Vui lòng chọn bác sĩ cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDocName.Text) || string.IsNullOrWhiteSpace(txtYOE.Text) ||
                string.IsNullOrWhiteSpace(txtAge.Text) || string.IsNullOrWhiteSpace(txtContact.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkFiveLoginPermission.Checked && (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text)))
            {
                MessageBox.Show("Vui lòng nhập Username và Password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var doctor = new DoctorDTO
                {
                    DoctorId = int.Parse(txtDocId.Text.Trim()),
                    DocName = txtDocName.Text.Trim(),
                    Age = int.Parse(txtAge.Text.Trim()),
                    YearOfExperience = int.Parse(txtYOE.Text.Trim()),
                    Contact = txtContact.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    LoginUserId = string.IsNullOrWhiteSpace(txtUserLoginId.Text) ? 0 : int.Parse(txtUserLoginId.Text.Trim())
                };

                doctorBL.UpdateDoctor(
                    doctor,
                    chkFiveLoginPermission.Checked ? txtUserName.Text.Trim() : null,
                    chkFiveLoginPermission.Checked ? txtPassword.Text.Trim() : null,
                    currentUser.UserId,
                    chkFiveLoginPermission.Checked
                );

                MessageBox.Show("Sửa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDoctors();
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa bác sĩ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDocId.Text) || txtDocId.Text.Trim() == "0")
            {
                MessageBox.Show("Vui lòng chọn bác sĩ cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int doctorId = int.Parse(txtDocId.Text.Trim());
                if (doctorBL.CheckDiagnosisExists(doctorId))
                {
                    MessageBox.Show("Đã có chẩn đoán của bác sĩ này, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int loginUserId = string.IsNullOrWhiteSpace(txtUserLoginId.Text) ? 0 : int.Parse(txtUserLoginId.Text.Trim());
                doctorBL.DeleteDoctor(doctorId, loginUserId);

                MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDoctors();
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa bác sĩ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
