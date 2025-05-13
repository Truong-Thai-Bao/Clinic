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
        public PatientArrivalForm(DataTransferLayer.UserInfo currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
        }

        // Dùng để logout quat về menu 
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
            List<AppointmentDTO> appointments = new List<AppointmentDTO>();
            //string query = "SELECT * FROM Appointment";

            //using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            //using (SqlCommand cmd = new SqlCommand(query, conn))
            //{
            //    conn.Open();
            int stt = 1;
            //SqlDataReader reader = cmd.ExecuteReader();
            foreach(var app in appointments)
            {
                int isArrived = 0;
                object isArrivedValue = app.IsArrived;
                if (isArrivedValue != DBNull.Value)
                {
                    isArrived = Convert.ToInt32(isArrivedValue);
                }
                // Lấy trạng thái của lịch hẹn
                string status = AppointmentBUS.GetAppointmentStatus(
                        app.AppointmentDate,
                        app.AppointmentTime,
                        isArrived);

                ListViewItem item = new ListViewItem(app.PatientId.ToString());
                item.SubItems.Add(app.patient.Name.ToString());
                item.SubItems.Add(Convert.ToDateTime(app.patient.DateOfBirth).ToString("dd/MM/yyyy"));
                item.SubItems.Add(app.patient.Gender.ToString());
                item.SubItems.Add(app.patient.BloodGroup.ToString());
                item.SubItems.Add(app.patient.Contact.ToString());
                item.SubItems.Add(app.DoctorName).ToString();
                item.SubItems.Add(Convert.ToDateTime(app.AppointmentDate).ToString("dd/MM/yyyy"));
                item.SubItems.Add(app.AppointmentTime.ToString());
                item.SubItems.Add(app.Symptoms.ToString());
                item.SubItems.Add(status);

                lsvAppointmentList.Items.Add(item);
                stt++;
            }
                //while (reader.Read())
                //{
                //    int isArrived = 0;
                //    object isArrivedValue = reader["IsArrived"];
                //    if (isArrivedValue != DBNull.Value)
                //    {
                //        isArrived = Convert.ToInt32(isArrivedValue);
                //    }
                //    // Lấy trạng thái của lịch hẹn
                //    string status = AppointmentBUS.GetAppointmentStatus(
                //            reader.GetDateTime(reader.GetOrdinal("AppointmentDate")),
                //            reader.GetTimeSpan(reader.GetOrdinal("AppointmentTime")),
                //            isArrived);

                //    ListViewItem item = new ListViewItem(reader["AppointmentID"].ToString());
                //    item.SubItems.Add(reader["PatientName"].ToString());
                //    item.SubItems.Add(Convert.ToDateTime(reader["DateOfBirth"]).ToString("dd/MM/yyyy"));
                //    item.SubItems.Add(reader["Gender"].ToString());
                //    item.SubItems.Add(reader["BloodGroup"].ToString());
                //    item.SubItems.Add(reader["Contact"].ToString());
                //    item.SubItems.Add(reader["DoctorName"].ToString());
                //    item.SubItems.Add(Convert.ToDateTime(reader["AppointmentDate"]).ToString("dd/MM/yyyy"));
                //    item.SubItems.Add(reader["AppointmentTime"].ToString());
                //    item.SubItems.Add(reader["Symptoms"].ToString());
                //    item.SubItems.Add(status);

                //    lsvAppointmentList.Items.Add(item);
                //    stt++;
                //}
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
            string keyword = txtSearch.Text.Trim().ToLower();

            lsvAppointmentList.Items.Clear();

            string query = "SELECT * FROM Appointment WHERE 1=1";

            using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string patientName = reader["PatientName"].ToString();
                    string contact = reader["Contact"].ToString();

                    // Kiểm tra từ khóa tìm kiếm
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        if (!patientName.ToLower().Contains(keyword) && !contact.Contains(keyword))
                            continue;
                    }

                    int isArrived = Convert.ToInt32(reader["IsArrived"]);
                    string status = AppointmentBUS.GetAppointmentStatus(
                           reader.GetDateTime(reader.GetOrdinal("AppointmentDate")),
                           reader.GetTimeSpan(reader.GetOrdinal("AppointmentTime")),
                           isArrived);

                    ListViewItem item = new ListViewItem(reader["AppointmentID"].ToString());
                    item.SubItems.Add(patientName);
                    item.SubItems.Add(Convert.ToDateTime(reader["DateOfBirth"]).ToString("dd/MM/yyyy"));
                    item.SubItems.Add(reader["Gender"].ToString());
                    item.SubItems.Add(reader["BloodGroup"].ToString());
                    item.SubItems.Add(contact);
                    item.SubItems.Add(reader["DoctorName"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(reader["AppointmentDate"]).ToString("dd/MM/yyyy"));
                    item.SubItems.Add(reader["AppointmentTime"].ToString());
                    item.SubItems.Add(reader["Symptoms"].ToString());
                    item.SubItems.Add(status);

                    lsvAppointmentList.Items.Add(item);
                }
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
