using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTransferLayer;

namespace PresentationLayer
{
    public partial class DiagnosisForm : Form
    {
        private DataTransferLayer.UserInfo currentUser;
        private DiagnosisBL diagnosisBL;
        private PatientBL patientBL;
        private PrescriptionBL prescriptionBL;
        private List<MedicineDTO> medicines = new List<MedicineDTO>();
        SqlConnection sqlCon = new SqlConnection(DBCommon.connString);
        private static int count = 0;
        public DiagnosisForm(DataTransferLayer.UserInfo currentUser)
        {
            InitializeComponent();
            symptomDataGridView.DefaultCellStyle.ForeColor = Color.Black;
            medicineDataGridView.DefaultCellStyle.ForeColor = Color.Black;
            patientBL = new PatientBL();
            this.currentUser = currentUser;
            this.diagnosisBL = new DiagnosisBL();
            this.prescriptionBL = new PrescriptionBL();
            CalculateTotalPills();
            LoadPatients();
        }

        //Tính tuổi từ ngày sinh
        private int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;

            // Nếu chưa đến sinh nhật năm nay thì trừ đi 1
            if (birthDate.Date > today.AddYears(-age))
                age--;

            return age;
        }

        private void LoadPatients()
        {
            try
            {
                List<PatientDTO> patients = patientBL.GetPatientByDoctorId(currentUser.DoctorId);
                cbPatients.DataSource = patients;
                cbPatients.DisplayMember = "Name";
                cbPatients.ValueMember = "PatientId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load bệnh nhân: " + ex.Message);
            }
        }

        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm form = new MenuForm(currentUser);
            form.Show();
        }

        private void cbPatients_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbPatients.SelectedIndex >= 0)
            {
                LoadPatientInfos();
            }
        }

        private void LoadPatientInfos()
        {
            int patientId = Convert.ToInt32(cbPatients.SelectedValue);
            LoadSymptoms(patientId);
            if (patientId > 0)
            {
                SqlConnection conn = new SqlConnection(DBCommon.connString);

                #region Load Patients
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Patient WHERE PatientId = @PatientId", conn);
                cmd.Parameters.AddWithValue("@PatientId", patientId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtBlood.Text = String.Format("{0}", reader["BloodGroup"]);
                        DateTime dateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                        txtAge.Text = CalculateAge(dateOfBirth).ToString();
                        txtGender.Text = String.Format("{0}", reader["Gender"]);
                        txtContact.Text = String.Format("{0}", reader["Contact"]);
                        txtPatientCode.Text = String.Format("{0}", reader["PCode"]);
                    }
                }
                conn.Close();
                #endregion
            }
        }

        private void medicineDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow item in this.medicineDataGridView.SelectedRows)
            {
                medicineDataGridView.Rows.RemoveAt(item.Index); //Remove Medicine
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbMedicine.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên thuốc!");
                cbMedicine.Focus();
                return;
            }

            // Lấy tên thuốc từ ComboBox
            string medName = cbMedicine.Text.Trim();
            int medId = Convert.ToInt32(cbMedicine.SelectedValue);
            int notEnter = 0;

            // Xác định số lượng cho từng thời điểm:
            int qMorning = int.TryParse(txtMorning.Text, out notEnter) ? notEnter : 0;
            int qNoon = int.TryParse(txtNoon.Text, out notEnter) ? notEnter : 0;
            int qAfternoon = int.TryParse(txtAfternoon.Text, out notEnter) ? notEnter : 0;
            int day = int.TryParse(txtDay.Text, out notEnter) ? notEnter : 1;

            // Kiểm tra xem thuốc này đã có trong DataGridView chưa
            int rowIndex = -1;
            for (int i = 0; i < medicineDataGridView.Rows.Count; i++)
            {
                // Ở đây, so sánh với biến medName, chứ không phải "Name"
                if (medicineDataGridView.Rows[i].Cells["MedicineName"].Value?.ToString() == medName)
                {
                    rowIndex = i;
                    break;
                }
            }
            if (rowIndex < 0)
            {
                rowIndex = medicineDataGridView.Rows.Add();
            }

            // Cập nhật thông tin vào các ô của hàng đó
            medicineDataGridView.Rows[rowIndex].Cells["Serial"].Value = medicineDataGridView.Rows.Count - 1;
            medicineDataGridView.Rows[rowIndex].Cells["MedicineName"].Value = medName;
            medicineDataGridView.Rows[rowIndex].Cells["MorningDose"].Value = qMorning;
            medicineDataGridView.Rows[rowIndex].Cells["NoonDose"].Value = qNoon;
            medicineDataGridView.Rows[rowIndex].Cells["AfternoonDose"].Value = qAfternoon;
            medicineDataGridView.Rows[rowIndex].Cells["day"].Value = day;
            medicineDataGridView.Rows[rowIndex].Cells["MedicineId"].Value = medId;
            medicineDataGridView.Rows[rowIndex].Cells["Type"].Value = lbType.Text.Trim();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
                
            if (cbPatients.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân!");
                return;
            }
            if (medicineDataGridView.Rows.Count <= 1)
            {
                MessageBox.Show("Vui lòng nhập tên thuốc!");
                return;
            }
            if (lsvDiagnosis.Items.Count==0)
            {
                MessageBox.Show("Vui lòng thêm chẩn đoán!");
                return;
            }
            if (string.IsNullOrEmpty(txtMorning.Text.Trim()) &&
                string.IsNullOrEmpty(txtNoon.Text.Trim()) &&
                string.IsNullOrEmpty(txtAfternoon.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập số lượng thuốc!");
                return;
            }
            try
            {
                // Lưu thông tin Diagnosis
                // Tạo chuỗi chẩn đoán từ ListView triệu chứng
                string diagnosises = "";
                foreach (ListViewItem item in lsvDiagnosis.Items)
                {
                    diagnosises += item.SubItems[1].Text + ", ";
                }
                diagnosises = diagnosises.TrimEnd(',', ' ');
                Diagnosis diagnosis = new Diagnosis
                {
                    PatientId = Convert.ToInt32(cbPatients.SelectedValue),
                    DoctorId = currentUser.DoctorId,
                    AddedDate = DateTime.Now,
                    AddedBy = currentUser.UserId,
                    DiagnosisName = diagnosises
                };
                
                int diagnosisId =  diagnosisBL.SaveDiagnosisBL(diagnosis);



                // Duyệt qua tất cả các dòng trong DataGridView (bỏ qua dòng mới)
                for (int i = 0; i < medicineDataGridView.Rows.Count; i++)
                {
                    if (medicineDataGridView.Rows[i].IsNewRow)
                        continue;

                    int medId = Convert.ToInt32(medicineDataGridView.Rows[i].Cells["MedicineId"].Value);

                    int morning = Convert.ToInt32(medicineDataGridView.Rows[i].Cells["MorningDose"].Value ?? 0);
                    int noon = Convert.ToInt32(medicineDataGridView.Rows[i].Cells["NoonDose"].Value ?? 0);
                    int afternoon = Convert.ToInt32(medicineDataGridView.Rows[i].Cells["AfternoonDose"].Value ?? 0);
                    int day = Convert.ToInt32(medicineDataGridView.Rows[i].Cells["day"].Value ?? 0);

                    prescriptionBL.AddPrescription(new PrescriptionDTO
                    {
                        PatientId = Convert.ToInt32(cbPatients.SelectedValue),
                        MedicineId = medId,
                        MorningDose = morning,
                        NoonDose = noon,
                        AfternoonDose = afternoon,
                        Day = day,
                        AddedDate = DateTime.Now,
                        DiagnosisId = diagnosisId,
                        AddedBy = currentUser.UserId
                    });
                }
                MessageBox.Show("Lưu thành công!");
                lsvDiagnosis.Items.Clear();
                medicineDataGridView.Rows.Clear();
                LoadPatients();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
        }

        private void txtNumMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số (0-9) và phím điều khiển (Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }
        private void LoadMedicineComboBox()
        {
            using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            {
                conn.Open();
                string query = "SELECT MedicineId, MedicineName,Type FROM Medicine";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbMedicine.DataSource = dt;
                cbMedicine.DisplayMember = "MedicineName";
                cbMedicine.ValueMember = "MedicineId";
                cbMedicine.SelectedIndex = -1; // Không chọn gì mặc định
            }
        }

        private void LoadSymptoms(int patientId)
        {
            using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            {
                conn.Open();
                string query = @"SELECT Name FROM Symptom WHERE PatientId = @PatientId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PatientId", patientId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                symptomDataGridView.DataSource = dt;
            }
        }

        private void DiagnosisForm_Load(object sender, EventArgs e)
        {
            medicineDataGridView.DefaultCellStyle.ForeColor = Color.Black;
            medicineDataGridView.DefaultCellStyle.BackColor = Color.White;
            LoadMedicineComboBox();
            LoadPatients();
        }


        //Hiển thị lên label 
        private void CalculateTotalPills()
        {
            // Lấy số lượng từ các TextBox (mặc định = 0 nếu không nhập hoặc nhập sai)
            int morning = int.TryParse(txtMorning.Text, out int m) ? m : 0;
            int noon = int.TryParse(txtNoon.Text, out int n) ? n : 0;
            int afternoon = int.TryParse(txtAfternoon.Text, out int a) ? a : 0;
            int days = int.TryParse(txtDay.Text, out int d) ? d : 0;

            // Tính tổng số viên: (Sáng + Trưa + Chiều) * Số ngày
            int totalPills = (morning + noon + afternoon) * days;

            // Hiển thị kết quả lên Label
            lbNum.Text = $"{totalPills}";
        }
        private void txtDay_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPills();
        }
        private void txtMorning_TextChanged(object sender, EventArgs e) => CalculateTotalPills();
        private void txtNoon_TextChanged(object sender, EventArgs e) => CalculateTotalPills();
        private void txtAfternoon_TextChanged(object sender, EventArgs e) => CalculateTotalPills();


        private void cbMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMedicine.SelectedIndex != -1 && cbMedicine.SelectedItem is DataRowView row)
            {
                lbType.Text = row["Type"].ToString();
            }
            else
            {
                lbType.Text = string.Empty;
            }
        }

        private void btnAddDiagnosis_Click(object sender, EventArgs e)
        {
            if(txtDiagnosis.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập chẩn đoán!");
                txtDiagnosis.Focus();
                return;
            }
            // Thêm chẩn đoán vào ListView
            bool exists = false;
            foreach (ListViewItem item in lsvDiagnosis.Items)
            {
                if (item.SubItems[1].Text.Equals(txtDiagnosis.Text, StringComparison.OrdinalIgnoreCase))
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                int stt = lsvDiagnosis.Items.Count + 1;
                ListViewItem listItem = new ListViewItem(stt.ToString());
                listItem.SubItems.Add(txtDiagnosis.Text.Trim());
                lsvDiagnosis.Items.Add(listItem);
                txtDiagnosis.Clear();
            }
            else
            {
                MessageBox.Show("Chẩn đoán đã tồn tại trong danh sách!");
                txtDiagnosis.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(medicineDataGridView.SelectedRows.Count > 0)
            {
                MessageBox.Show(medicineDataGridView.SelectedRows.ToString());
                foreach(DataGridViewRow row in medicineDataGridView.SelectedRows)
                {
                    medicineDataGridView.Rows.Remove(row);
                }
                medicineDataGridView.Refresh();
            }
        }

        private void medicineDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             if(e.RowIndex<0) { return; }

            if (medicineDataGridView.Columns[e.ColumnIndex].Name.ToString()=="Delete")
                medicineDataGridView.Rows.RemoveAt(e.RowIndex);
        }

        private void cbPatients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
