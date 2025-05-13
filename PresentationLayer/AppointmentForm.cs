using DataLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using DataLayer;
using BusinessLayer;
using DataTransferLayer;

namespace PresentationLayer
{
    public partial class AppointmentForm : Form
    {
        private DataTransferLayer.UserInfo currentUser;
        private DoctorBL DoctorBL = new DoctorBL();
        private PatientBL PatientBL = new PatientBL();
        private AppointmentBL AppointmentBL = new AppointmentBL();
        private SymptomBL symptomBL;
        public AppointmentForm(DataTransferLayer.UserInfo currentUser)
        {
            InitializeComponent();
            LoadDoctors();
            lblPCodeNum.Text = DateTime.Now.ToString("ddMMhhmmss");
            this.currentUser = currentUser;
            this.symptomBL = new SymptomBL();
        }

        // Dùng để chuyển đến form MenuForm (Back Button)
        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm menuForm = new MenuForm(currentUser);
            menuForm.Show();
        }

        // Dùng để load danh sách bác sĩ
        private void LoadDoctors()
        {
            try
            {
                var doctors = DoctorBL.GetAllDoctors();
                cbSelectDoctor.DisplayMember = "DocName";
                cbSelectDoctor.ValueMember = "DoctorId";
                cbSelectDoctor.DataSource = doctors;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Đã xảy ra lỗi khi tải danh sách bác sĩ: "+ex.Message);
            }
        }

        // Dùng để reset các trường thông tin
        private void Reset()
        {
            txtPatientName.Text = "";
            txtContact.Text = "";
            dtpAge.CustomFormat = " ";
            dtpAge.Format = DateTimePickerFormat.Custom;
            txtOtherSymptom.Text = "";
            dtpAppointmentDate.CustomFormat = " ";
            dtpAppointmentDate.Format = DateTimePickerFormat.Custom;
            cbAppointmentTime.Text = "";
            lsvSymptom.Items.Clear();
            txtPatientName.Focus();
            txtOtherSymptom.ReadOnly = true;
            txtOtherSymptom.Enabled = false;
            txtAddress.Text = "";
            cbGender.SelectedIndex = -1;
            cbBloodGroup.SelectedIndex = -1;
            cbSelectDoctor.SelectedIndex = -1;
            cbSymptom.SelectedIndex = -1;
            cbAppointmentTime.SelectedIndex = -1;
        }

        // Dùng để thêm triệu chứng vào danh sách triệu chứng
        private void lsvtSymptom_DoubleClick(object sender, EventArgs e)
        {
            if (lsvSymptom.SelectedItems.Count > 0)
            {
                var result = MessageBox.Show("Bạn có chắc muốn xóa triệu chứng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    lsvSymptom.Items.Remove(lsvSymptom.SelectedItems[0]);

                    // Cập nhật lại số thứ tự (STT)
                    for (int i = 0; i < lsvSymptom.Items.Count; i++)
                    {
                        lsvSymptom.Items[i].Text = (i + 1).ToString();
                    }
                }
            }
        }

        // Dùng để thêm triệu chứng vào danh sách triệu chứng khác
        private void cbSymptom_SelectedValueChanged(object sender, EventArgs e)
        {
            txtOtherSymptom.Text = "";
            txtOtherSymptom.ReadOnly = true;
            txtOtherSymptom.Enabled = false;
            if (cbSymptom.Text == "Khác")
            {
                txtOtherSymptom.ReadOnly = false;
                txtOtherSymptom.Enabled = true;
            }
        }

        // Dùng để đặt lịch hẹn
        private void btnBook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPatientName.Text) ||
                string.IsNullOrEmpty(txtContact.Text) ||
                string.IsNullOrEmpty(dtpAge.Text) ||
                string.IsNullOrEmpty(cbGender.Text) ||
                string.IsNullOrEmpty(cbSelectDoctor.Text) ||
                string.IsNullOrEmpty(dtpAppointmentDate.Text) ||
                string.IsNullOrEmpty(cbAppointmentTime.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lsvSymptom.Items.Count == 0)
            {
                MessageBox.Show("Chưa có triệu chứng nào được thêm!");
                return;
            }

            // Lấy triệu chứng từ danh sách triệu chứng
            string symptoms = "";
            foreach (ListViewItem item in lsvSymptom.Items)
            {
                symptoms += item.SubItems[1].Text + ", ";
            }
            symptoms = symptoms.TrimEnd(',', ' ');

            
            try
            {
                // Tạo và lưu thông tin bệnh nhân
                PatientDTO patient = new PatientDTO();
                {
                    patient.Name = txtPatientName.Text.Trim();
                    patient.Contact = txtContact.Text.Trim();
                    patient.DateOfBirth = dtpAge.Value.Date;
                    patient.Gender = cbGender.Text.Trim();
                    patient.BloodGroup = cbBloodGroup.Text.Trim();
                    patient.Address = txtAddress.Text.Trim();
                    patient.DoctorId = (int)cbSelectDoctor.SelectedValue;
                    patient.PCode = lblPCodeNum.Text.Trim();
                };
                int patientId = PatientBL.AddPatient(patient);

                Symptom symptom = new Symptom();
                {
                    symptom.PatientId = patientId;
                    symptom.Name = symptoms;
                    symptom.AddedDate = DateTime.Now;
                    symptom.AddedBy = currentUser.UserId;
                }
                symptomBL.InsertSymtom(symptom);
                //MessageBox.Show("hi");
                // Tạo và lưu thông tin lịch hẹn
                AppointmentDTO appointment = new AppointmentDTO();
                {
                    appointment.PatientId = patientId;
                    appointment.DoctorName = cbSelectDoctor.Text.Trim();
                    appointment.AppointmentDate = dtpAppointmentDate.Value.Date;
                    appointment.AppointmentTime = TimeSpan.Parse(cbAppointmentTime.SelectedItem.ToString() + ":00");
                    appointment.Symptoms = symptoms;
                    appointment.Status = "Chưa khám";
                    appointment.IsArrived = false;
                };
                AppointmentBL.AddAppointment(appointment);

                // Tạo và lưu thông tin đơn thuốc
                PrescriptionDTO prescription = new PrescriptionDTO();
                {
                    prescription.PatientId = patientId;
                };

                int stt = lsvAppointment.Items.Count + 1;
                ListViewItem appointmentItem = new ListViewItem(stt.ToString());
                appointmentItem.SubItems.Add(txtPatientName.Text.Trim());
                appointmentItem.SubItems.Add(dtpAge.Text);
                appointmentItem.SubItems.Add(cbGender.Text);
                appointmentItem.SubItems.Add(cbBloodGroup.Text);
                appointmentItem.SubItems.Add(txtContact.Text.Trim());
                appointmentItem.SubItems.Add(cbSelectDoctor.Text);
                appointmentItem.SubItems.Add(dtpAppointmentDate.Value.ToString("dd-MM-yyyy"));
                appointmentItem.SubItems.Add(cbAppointmentTime.Text);
                appointmentItem.SubItems.Add(symptoms);
                lsvAppointment.Items.Add(appointmentItem);

                MessageBox.Show("Đặt lịch hẹn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi đặt lịch hẹn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Dùng để xóa triệu chứng trong danh sách triệu chứng
        private void lsvAppointment_DoubleClick(object sender, EventArgs e)
        {
            if (lsvAppointment.SelectedItems.Count > 0)
            {
                var result = MessageBox.Show("Bạn có chắc muốn xóa triệu chứng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    lsvAppointment.Items.Remove(lsvAppointment.SelectedItems[0]);

                    // Cập nhật lại số thứ tự (STT)
                    for (int i = 0; i < lsvAppointment.Items.Count; i++)
                    {
                        lsvAppointment.Items[i].Text = (i + 1).ToString();
                    }
                }
            }
        }

        // Dùng để tạo danh sách thời gian hẹn
        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            TimeSpan startTime = new TimeSpan(6, 30, 0); // 06:30
            TimeSpan endTime = new TimeSpan(18, 0, 0);   // 18:00
            TimeSpan interval = new TimeSpan(0, 30, 0);  // mỗi 30 phút

            for (TimeSpan time = startTime; time <= endTime; time += interval)
            {
                cbAppointmentTime.Items.Add(time.ToString(@"hh\:mm"));
            }

            cbAppointmentTime.DropDownStyle = ComboBoxStyle.DropDownList; // Không cho nhập tay
        }

        // Dùng để xóa lịch hẹn
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lsvAppointment.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch hẹn để xoá.");
                return;
            }

            int appointmentId = int.Parse(lsvAppointment.SelectedItems[0].Text);

            var result = MessageBox.Show("Xác nhận xoá lịch hẹn?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    AppointmentBL.DeleteAppointment(appointmentId);
                    lsvAppointment.Items.Remove(lsvAppointment.SelectedItems[0]);
                    for (int i = 0; i < lsvAppointment.Items.Count; i++)
                    {
                        lsvAppointment.Items[i].Text = (i + 1).ToString();
                    }
                    MessageBox.Show("Xoá lịch hẹn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi xoá lịch hẹn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Dùng để set lại ID khi sửa lịch hẹn
        private string editingAppointmentID = null;

        // Dùng để sửa lịch hẹn
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lsvAppointment.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lịch hẹn để sửa.");
                return;
            }

            if (editingAppointmentID == null)
            {
                MessageBox.Show("Không có lịch hẹn nào đang được chỉnh sửa.");
                return;
            }

            string symptoms = "";
            foreach (ListViewItem item in lsvSymptom.Items)
            {
                symptoms += item.SubItems[1].Text + ", ";
            }
            symptoms = symptoms.TrimEnd(',', ' ');

            try
            {
                AppointmentDTO appointment = new AppointmentDTO
                {
                    AppointmentID = int.Parse(editingAppointmentID),
                    PatientId = int.Parse(lsvAppointment.SelectedItems[0].Text),
                    DoctorName = cbSelectDoctor.Text.Trim(),
                    AppointmentDate = dtpAppointmentDate.Value.Date,
                    AppointmentTime = TimeSpan.Parse(cbAppointmentTime.SelectedItem.ToString() + ":00"),
                    Symptoms = symptoms,
                    Status = "Chưa khám",
                    IsArrived = false
                };

                PatientDTO patient = new PatientDTO()
                {
                    PatientId = int.Parse(lsvAppointment.SelectedItems[0].Text),
                    Name = txtPatientName.Text.Trim(),
                    Contact = txtContact.Text.Trim(),
                    DateOfBirth = dtpAge.Value.Date,
                    Gender = cbGender.Text.Trim(),
                    BloodGroup = cbBloodGroup.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    DoctorId = Convert.ToInt32(cbSelectDoctor.SelectedValue),
                    PCode = lblPCodeNum.Text.Trim()
                };
                AppointmentBL.UpdateAppointment(appointment, patient);
                // Cập nhật lại ListView
                ListViewItem selectedItem = lsvAppointment.SelectedItems[0];
                selectedItem.SubItems[1].Text = txtPatientName.Text.Trim();
                selectedItem.SubItems[2].Text = dtpAge.Text;
                selectedItem.SubItems[3].Text = cbGender.Text;
                selectedItem.SubItems[4].Text = cbBloodGroup.Text;
                selectedItem.SubItems[5].Text = txtContact.Text.Trim();
                selectedItem.SubItems[6].Text = cbSelectDoctor.Text;
                selectedItem.SubItems[7].Text = dtpAppointmentDate.Value.ToString("dd-MM-yyyy");
                selectedItem.SubItems[8].Text = cbAppointmentTime.Text;
                selectedItem.SubItems[9].Text = symptoms;
                // Cập nhật lại số thứ tự (STT)
                for (int i = 0; i < lsvAppointment.Items.Count; i++)
                {
                    lsvAppointment.Items[i].Text = (i + 1).ToString();
                }
                // Cập nhật lại danh sách triệu chứng
                lsvSymptom.Items.Clear();
                foreach (ListViewItem item in lsvSymptom.Items)
                {
                    ListViewItem newItem = new ListViewItem(item.Text);
                    newItem.SubItems.Add(item.SubItems[1].Text);
                    lsvSymptom.Items.Add(newItem);
                }
                MessageBox.Show("Cập nhật lịch hẹn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
                editingAppointmentID = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật lịch hẹn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Dùng để thêm triệu chứng vào danh sách triệu chứng
        private void btnAddSymptom_Click_1(object sender, EventArgs e)
        {
            if (cbSymptom.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn triệu chứng!");
                cbSymptom.Focus();
            }
            else if (cbSymptom.Text == "Khác" && txtOtherSymptom.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập triệu chứng khác!");
                txtOtherSymptom.Focus();
            }
            else
            {
                string name = cbSymptom.Text;
                if (cbSymptom.Text == "Khác")
                {
                    name = txtOtherSymptom.Text;
                }
                bool exists = false;
                foreach (ListViewItem item in lsvSymptom.Items)
                {
                    if (item.SubItems[1].Text.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    int stt = lsvSymptom.Items.Count + 1;
                    ListViewItem newItem = new ListViewItem(stt.ToString());
                    newItem.SubItems.Add(name);
                    lsvSymptom.Items.Add(newItem);
                }
            }
        }

        // Dùng để chuyển đến form AppointmentListForm
        private void btnAppointmentList_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AppointmentListForm appointmentListForm = new AppointmentListForm(currentUser);
            appointmentListForm.Show();
        }

        private void lsvAppointment_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = lsvAppointment.SelectedItems[0];

            editingAppointmentID = item.SubItems[0].Text;

            txtPatientName.Text = item.SubItems[1].Text;
            dtpAge.Value = DateTime.ParseExact(item.SubItems[2].Text, "dd/MM/yyyy", null);
            cbGender.Text = item.SubItems[3].Text;
            cbBloodGroup.Text = item.SubItems[4].Text;
            txtContact.Text = item.SubItems[5].Text;
            cbSelectDoctor.Text = item.SubItems[6].Text;
            DateTime dob;
            if (DateTime.TryParse(item.SubItems[2].Text, out dob))
            {
                dtpAge.Value = dob;
            }
            else
            {
                MessageBox.Show("Ngày sinh không hợp lệ: " + item.SubItems[2].Text);
            }

            cbAppointmentTime.Text = item.SubItems[8].Text.Substring(0, 5); // Cắt bớt :00 nếu cần
            cbSymptom.Text = item.SubItems[9].Text;
        }

        private void btnGetPrescription_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoctorPrescriptionForm form = new DoctorPrescriptionForm(currentUser);
            form.Show();
        }
    }
}
