using BusinessLayer;
using DataLayer;
using DataTransferLayer;
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
using static BusinessLayer.AppointmentBUS;

namespace PresentationLayer
{
    public partial class PatientArrivalForm : Form
    {
        private DataTransferLayer.UserInfo currentUser;
        private AppointmentBL appointmentBL = new AppointmentBL();
        public PatientArrivalForm(DataTransferLayer.UserInfo currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
        }

        // Dùng để logout quay về menu 
        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm menuForm = new MenuForm(currentUser);
            menuForm.Show();
        }

        private void PatientArrivalForm_Load(object sender, EventArgs e)
        {
            btnNewAdmission.Enabled = false;
            rdoNo.Checked = false;
            rdoYes.Checked = false;

            LoadAppointments();
        }

        // Dùng để xử lý sự kiện khi người dùng chọn "Có" trong RadioButton
        private void rdoYes_CheckedChanged(object sender, EventArgs e)
        {
            grbSearch.Enabled = true;

            btnNewAdmission.Enabled = false;
        }

        // Dùng để xử lý sự kiện khi người dùng chọn "Không" trong RadioButton
        private void rdoNo_CheckedChanged(object sender, EventArgs e)
        {
            grbSearch.Enabled = false;

            btnNewAdmission.Enabled = true;
        }

        // Dùng để load danh sách lịch hẹn
        private void LoadAppointments()
        {
            lsvAppointmentList.Items.Clear();
            DataTable dt = appointmentBL.GetAllAppointments();
            foreach (DataRow row in dt.Rows)
            {
                var item = new ListViewItem(row["AppointmentID"].ToString());
                item.SubItems.Add(row["PatientName"].ToString());
                item.SubItems.Add(Convert.ToDateTime(row["DateOfBirth"]).ToString("dd/MM/yyyy"));
                item.SubItems.Add(row["Gender"].ToString());
                item.SubItems.Add(row["BloodGroup"].ToString());
                item.SubItems.Add(row["Contact"].ToString());
                item.SubItems.Add(row["DoctorName"].ToString());
                item.SubItems.Add(Convert.ToDateTime(row["AppointmentDate"]).ToString("dd/MM/yyyy"));
                item.SubItems.Add(row["AppointmentTime"].ToString());
                item.SubItems.Add(row["Symptoms"].ToString());
                bool isArrived = Convert.ToBoolean(row["IsArrived"]);
                item.SubItems.Add(AppointmentBUS.GetAppointmentStatus(
                    Convert.ToDateTime(row["AppointmentDate"]),
                    TimeSpan.Parse(row["AppointmentTime"].ToString()),
                    isArrived ? 1 : 0));
                lsvAppointmentList.Items.Add(item);
            }
        }

        // Dùng để xử lý sự kiện khi người dùng nhấn nút "Tiếp nhận mới"
        private void btnNewAdmission_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientForm patientForm = new PatientForm(currentUser);
            patientForm.Show();
        }

        // Dùng để lọc danh sách lịch hẹn theo bác sĩ và ngày || Tìm kiếm lịch hẹn bằng Tên bệnh nhân hoặc SĐT
        private void FilterAppointments()
        {
            lsvAppointmentList.Items.Clear();
            try
            {
                string keyword = txtSearch.Text.Trim().ToLower();
                DataTable dt = appointmentBL.GetAppointmentsByKeyword(keyword);

                foreach (DataRow row in dt.Rows)
                {
                    int isArrived = Convert.ToInt32(row["IsArrived"] ?? 0);
                    string status = AppointmentBUS.GetAppointmentStatus(
                          Convert.ToDateTime(row["AppointmentDate"]),
                          TimeSpan.Parse(row["AppointmentTime"].ToString()),
                          isArrived);

                    ListViewItem item = new ListViewItem(row["AppointmentID"].ToString());
                    item.SubItems.Add(row["PatientName"].ToString());
                    item.SubItems.Add(row["DateOfBirth"] != DBNull.Value
                        ? Convert.ToDateTime(row["DateOfBirth"]).ToString("dd/MM/yyyy")
                        : "");
                    item.SubItems.Add(row["Gender"].ToString());
                    item.SubItems.Add(row["BloodGroup"].ToString());
                    item.SubItems.Add(row["Contact"].ToString());
                    item.SubItems.Add(row["DoctorName"].ToString());
                    item.SubItems.Add(row["AppointmentDate"] != DBNull.Value
                        ? Convert.ToDateTime(row["AppointmentDate"]).ToString("dd/MM/yyyy")
                        : "");
                    item.SubItems.Add(row["AppointmentTime"].ToString());
                    item.SubItems.Add(row["Symptoms"].ToString());
                    item.SubItems.Add(status);

                    lsvAppointmentList.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc danh sách lịch hẹn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Dùng để xử lý sự kiện khi người dùng thay đổi nội dung trong ô tìm kiếm
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterAppointments();
        }

        // Dùng để xử lý sự kiện khi người dùng nhấn nút "Xác nhận"
        private void btnConfirmation_Click(object sender, EventArgs e)
        {
            if (lsvAppointmentList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lịch hẹn để xác nhận.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID lịch hẹn được chọn
            string appointmentId = lsvAppointmentList.SelectedItems[0].SubItems[0].Text;

            // Gọi hàm cập nhật
            AppointmentBUS.MarkAppointmentAsArrived(appointmentId);

            MessageBox.Show("Đã xác nhận bệnh nhân đã đến.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refresh lại danh sách
            LoadAppointments();
        }

        // Dùng để xử lý sự kiện khi người dùng nhấn nút "Hủy"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lsvAppointmentList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lịch hẹn để hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID lịch hẹn được chọn
            string appointmentId = lsvAppointmentList.SelectedItems[0].SubItems[0].Text;

            // Gọi hàm cập nhật
            AppointmentBUS.CancelAppointment(appointmentId);

            MessageBox.Show("Xác nhận đã hủy hẹn.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refresh lại danh sách
            LoadAppointments();
        }
    }
}
