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
        private AppointmentBL appointmentBL = new AppointmentBL();
        private DoctorBL doctorBL = new DoctorBL();

        public AppointmentListForm(DataTransferLayer.UserInfo currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
        }

        // Dùng để load danh sách bác sĩ vào combobox
        private void LoadDoctorFilter()
        {
           try
            {
                cbDoctorFilter.Items.Clear();
                cbDoctorFilter.Items.Add("Tất cả");

                var doctorNames = doctorBL.GetDoctorNames();
                foreach (var doctorName in doctorNames)
                {
                    cbDoctorFilter.Items.Add(doctorName);
                }
                cbDoctorFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bác sĩ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                DataTable dt = appointmentBL.GetAllAppointments();
                int stt = 1;
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
                        :"");
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
                    stt++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách lịch hẹn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Dùng để lọc danh sách lịch hẹn theo bác sĩ và ngày || Tìm kiếm lịch hẹn bằng Tên bệnh nhân hoặc SĐT
        private void FilterAppointments()
        {
            string doctor = cbDoctorFilter.Text;
            DateTime? selectedDate = chkFilterByDate.Checked ? dtpDateFilter.Value.Date : (DateTime?)null;
            //DateTime selectedDate = dtpDateFilter.Value.Date;
            string keyword = txtSearch.Text.Trim().ToLower();

            bool filterDoctor = chkFilterByDoctor.Checked && doctor != "Tất cả";
            //bool filterDate = chkFilterByDate.Checked;

            lsvAppointmentList.Items.Clear();
            try
            {
                DataTable dt = appointmentBL.FilterAppointments(
                    filterDoctor ? doctor : null,
                    selectedDate,
                    keyword);

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
                    try
                    {
                        appointmentBL.DeleteAppointment(int.Parse(appointmentId));
                        MessageBox.Show("Xoá lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAppointments();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xoá lịch hẹn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
                try
                {
                    appointmentBL.DeleteAppointment(int.Parse(id));
                    MessageBox.Show("Xoá lịch hẹn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAppointments();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xoá lịch hẹn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
