using DataLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
            LoadDoctors();
            lblPCodeNum.Text = DateTime.Now.ToString("ddMMhhmmss");
        }

        // Dùng để chuyển đến form MenuForm (Back Button)
        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
        }

        // Dùng để load danh sách bác sĩ
        private void LoadDoctors()
        {
            using (SqlConnection sqlCon = new SqlConnection(DBCommon.connString))
            {
                try
                {
                    string query = "SELECT DoctorId, DocName FROM Doctor";
                    SqlDataAdapter da = new SqlDataAdapter(query, sqlCon);
                    sqlCon.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Doctor");
                    cbSelectDoctor.DisplayMember = "DocName";
                    cbSelectDoctor.ValueMember = "DoctorId";
                    cbSelectDoctor.DataSource = ds.Tables["Doctor"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Đã xảy ra lỗi!");
                }
            }
        }

        // Dùng để reset các trường thông tin
        private void Reset()
        {
            txtPatientName.Text = "";
            txtContact.Text = "";
            cbBloodGroup.Text = "";
            dtpAge.Format = DateTimePickerFormat.Short;
            cbGender.Text = "";
            cbSymptom.Text = "";
            txtOtherSymptom.Text = "";
            cbSelectDoctor.Text = "";
            dtpAppointmentDate.Format = DateTimePickerFormat.Short;
            cbAppointmentTime.Text = "";
            lsvSymptom.Items.Clear();
            txtPatientName.Focus();
            txtOtherSymptom.ReadOnly = true;
            txtOtherSymptom.Enabled = false;
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
            }
            if (lsvSymptom.Items.Count == 0)
            {
                MessageBox.Show("Chưa có triệu chứng nào được thêm!");
                return;
            }

            // Tạo chuỗi triệu chứng từ ListView triệu chứng
            string symptoms = "";
            foreach (ListViewItem item in lsvSymptom.Items)
            {
                symptoms += item.SubItems[1].Text + ", ";
            }
            symptoms = symptoms.TrimEnd(',', ' ');

            // Thêm vào ListView hiển thị lịch hẹn
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

            using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            {
                conn.Open();

                //Thêm bệnh nhân và lấy ID
                string insertPatientQuery = @"
                INSERT INTO Patient (Name, Contact, DateOfBirth, Gender, BloodGroup, DoctorId, Address, PCode)
                VALUES (@Name, @Contact, @DateOfBirth, @Gender, @BloodGroup, @DoctorId, @Address, @PCode);
                SELECT SCOPE_IDENTITY();";

                int patientId;

                using (SqlCommand cmd = new SqlCommand(insertPatientQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", txtPatientName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                    cmd.Parameters.AddWithValue("@DateOfBirth", dtpAge.Value.Date);
                    cmd.Parameters.AddWithValue("@Gender", cbGender.Text);
                    cmd.Parameters.AddWithValue("@BloodGroup", cbBloodGroup.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@DoctorId", cbSelectDoctor.SelectedValue);
                    cmd.Parameters.AddWithValue("@PCode", lblPCodeNum.Text.Trim());

                    patientId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                //Thêm lịch hẹn
                string insertAppointmentQuery = @"
                INSERT INTO Appointment
                (PatientId, DoctorName, AppointmentDate, AppointmentTime, Symptoms, Status, IsArrived)
                VALUES
                (@PatientId, @DoctorName, @AppointmentDate, @AppointmentTime, @Symptoms, @Status, @IsArrived);";

                using (SqlCommand cmd = new SqlCommand(insertAppointmentQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientId", patientId);
                    cmd.Parameters.AddWithValue("@DoctorName", cbSelectDoctor.Text);
                    cmd.Parameters.AddWithValue("@AppointmentDate", dtpAppointmentDate.Value.Date);
                    cmd.Parameters.AddWithValue("@AppointmentTime", TimeSpan.Parse(cbAppointmentTime.SelectedItem.ToString() + ":00"));
                    cmd.Parameters.AddWithValue("@Symptoms", symptoms);
                    cmd.Parameters.AddWithValue("@Status", "Chưa khám");
                    cmd.Parameters.AddWithValue("@IsArrived", false);

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                MessageBox.Show("Đặt lịch hẹn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Reset();

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

            string id = lsvAppointment.SelectedItems[0].Text;

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

            string query = @"UPDATE Appointment 
                     SET PatientName = @PatientName,
                         DateOfBirth = @DateOfBirth,
                         Gender = @Gender,
                         BloodGroup = @BloodGroup,
                         Contact = @Contact,
                         DoctorName = @DoctorName,
                         AppointmentDate = @AppointmentDate,
                         AppointmentTime = @AppointmentTime,
                         Symptoms = @Symptoms
                     WHERE AppointmentID = @AppointmentID";

            using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@PatientName", txtPatientName.Text.Trim());
                cmd.Parameters.AddWithValue("@DateOfBirth", dtpAge.Value.Date);
                cmd.Parameters.AddWithValue("@Gender", cbGender.Text);
                cmd.Parameters.AddWithValue("@BloodGroup", cbBloodGroup.Text);
                cmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                cmd.Parameters.AddWithValue("@DoctorName", cbSelectDoctor.Text);
                cmd.Parameters.AddWithValue("@AppointmentDate", dtpAppointmentDate.Value.Date);
                cmd.Parameters.AddWithValue("@AppointmentTime", TimeSpan.Parse(cbAppointmentTime.Text));
                cmd.Parameters.AddWithValue("@Symptoms", lsvSymptom.Text.Trim());
                cmd.Parameters.AddWithValue("@AppointmentID", editingAppointmentID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cập nhật thành công!");

            // Cập nhật lại danh sách lịch hẹn

            editingAppointmentID = null;
            Reset();
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
            AppointmentListForm appointmentListForm = new AppointmentListForm();
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
            DoctorPrescriptionForm form = new DoctorPrescriptionForm();
            form.Show();
        }
    }
}
