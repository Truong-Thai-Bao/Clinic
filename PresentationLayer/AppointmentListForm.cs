using BusinessLayer;
using DataLayer;
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
    public partial class AppointmentListForm : Form
    {
        private DataTransferLayer.UserInfo currentUser;
        public AppointmentListForm(DataTransferLayer.UserInfo currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
        }

        // Dùng để load danh sách bác sĩ vào combobox
        private void LoadDoctorFilter()
        {
            cbDoctorFilter.Items.Clear();
            cbDoctorFilter.Items.Add("Tất cả");

            string query = "SELECT DISTINCT DoctorName FROM Appointment";
            using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbDoctorFilter.Items.Add(reader["DoctorName"].ToString());
                }
            }
            cbDoctorFilter.SelectedIndex = 0;
        }

        // Dùng để lọc danh sách lịch hẹn theo bác sĩ và ngày
        private void cbDoctorFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterAppointments();
        }

        // Dùng để lọc danh sách lịch hẹn theo ngày
        private void dtpDateFilter_ValueChanged(object sender, EventArgs e)
        {
            FilterAppointments();
        }

        // Dùng để load danh sách lịch hẹn
        private void LoadAppointments()
        {
            lsvAppointmentList.Items.Clear();
            string query = "SELECT * FROM Appointment";

            using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int stt = 1;
                while (reader.Read())
                {
                    int isArrived = 0;
                    object isArrivedValue = reader["IsArrived"];
                    if (isArrivedValue != DBNull.Value)
                    {
                        isArrived = Convert.ToInt32(isArrivedValue);
                    }
                    // Lấy trạng thái của lịch hẹn
                    string status = AppointmentBUS.GetAppointmentStatus(
                           reader.GetDateTime(reader.GetOrdinal("AppointmentDate")),
                           reader.GetTimeSpan(reader.GetOrdinal("AppointmentTime")),
                           isArrived);

                    ListViewItem item = new ListViewItem(reader["AppointmentID"].ToString());
                    item.SubItems.Add(reader["PatientName"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(reader["DateOfBirth"]).ToString("dd/MM/yyyy"));
                    item.SubItems.Add(reader["Gender"].ToString());
                    item.SubItems.Add(reader["BloodGroup"].ToString());
                    item.SubItems.Add(reader["Contact"].ToString());
                    item.SubItems.Add(reader["DoctorName"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(reader["AppointmentDate"]).ToString("dd/MM/yyyy"));
                    item.SubItems.Add(reader["AppointmentTime"].ToString());
                    item.SubItems.Add(reader["Symptoms"].ToString());
                    item.SubItems.Add(status);

                    lsvAppointmentList.Items.Add(item);
                    stt++;
                }
            }
        }

        // Dùng để lọc danh sách lịch hẹn theo bác sĩ và ngày || Tìm kiếm lịch hẹn bằng Tên bệnh nhân hoặc SĐT
        private void FilterAppointments()
        {
            string doctor = cbDoctorFilter.Text;
            DateTime selectedDate = dtpDateFilter.Value.Date;
            string keyword = txtSearch.Text.Trim().ToLower();

            bool filterDoctor = chkFilterByDoctor.Checked && doctor != "Tất cả";
            bool filterDate = chkFilterByDate.Checked;

            lsvAppointmentList.Items.Clear();

            string query = "SELECT * FROM Appointment WHERE 1=1";

            if (filterDoctor)
                query += " AND DoctorName = @DoctorName";
            if (filterDate)
                query += " AND AppointmentDate = @Date";

            using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (filterDoctor)
                    cmd.Parameters.AddWithValue("@DoctorName", doctor);
                if (filterDate)
                    cmd.Parameters.AddWithValue("@Date", selectedDate);

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

        // Dùng để load danh sách lịch hẹn khi form được mở
        private void AppointmentListForm_Load(object sender, EventArgs e)
        {
            // Load danh sách lịch hẹn và bác sĩ
            LoadDoctorFilter();
            LoadAppointments();

            // Đặt hiển thị mặc định cho các điều kiện lọc
            dtpDateFilter.Visible = false;
            cbDoctorFilter.Visible = false;

            // Đặt hiển thị mặc định cho combobox bác sĩ
            cbDoctorFilter.Enabled = false;
            dtpDateFilter.Enabled = false;
        }

        //  Dùng để thoát khỏi form
        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            AppointmentForm appointmentForm = new AppointmentForm(currentUser);
            appointmentForm.Show();
        }

        // Dùng để xóa lịch hẹn khi nhấn đúp chuột vào item trong danh sách
        private void lsvAppointmentList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsvAppointmentList.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lsvAppointmentList.SelectedItems[0];
                string appointmentId = selectedItem.SubItems[0].Text;

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xoá lịch hẹn này?",
                    "Xác nhận xoá",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    DeleteAppointment(appointmentId);
                    LoadAppointments(); // Load lại danh sách
                }
            }
        }

        // Dùng để xóa lịch hẹn khỏi CSDL
        private void DeleteAppointment(string appointmentId)
        {
            string query = "DELETE FROM Appointment WHERE AppointmentID = @AppointmentID";

            using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Dùng để ẩn/hiện các điều kiện lọc (Lọc theo bác sĩ)
        private void chkFilterByDoctor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFilterByDoctor.Checked)
            {
                cbDoctorFilter.Visible = true;
                cbDoctorFilter.Enabled = true;

            }
            else
            {
                cbDoctorFilter.Visible = false;
                cbDoctorFilter.Enabled = false;
            }
            FilterAppointments();
        }

        // Dùng để ẩn/hiện các điều kiện lọc (Lọc theo ngày hẹn)
        private void chkFilterByDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFilterByDate.Checked)
            {
                dtpDateFilter.Visible = true;
                dtpDateFilter.Enabled = true;
            }
            else
            {
                dtpDateFilter.Visible = false;
                dtpDateFilter.Enabled = false;
            }
            FilterAppointments();
        }

        // Dùng để tìm kiếm lịch hẹn theo tên bệnh nhân hoặc SĐT
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterAppointments();
        }

        // Dùng để set lại ID khi sửa lịch hẹn
        private string editingAppointmentID = null;

        // Dùng để xóa lịch hẹn
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lsvAppointmentList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch hẹn để xoá.");
                return;
            }

            string id = lsvAppointmentList.SelectedItems[0].Text;

            var result = MessageBox.Show("Xác nhận xoá lịch hẹn?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(DBCommon.connString))
                {
                    string query = "DELETE FROM Appointment WHERE AppointmentID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LoadAppointments();
        }
    }
}
