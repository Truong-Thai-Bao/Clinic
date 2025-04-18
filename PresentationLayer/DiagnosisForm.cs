﻿using BusinessLayer;
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

namespace PresentationLayer
{
    public partial class DiagnosisForm : Form
    {
        private List<Medicine> medicines = new List<Medicine>();
        SqlConnection sqlCon = new SqlConnection(DBCommon.connString);
        public DiagnosisForm()
        {
            InitializeComponent();
            LoadPatients();
            symptomDataGridView.DefaultCellStyle.ForeColor = Color.Black;
            medicineDataGridView.DefaultCellStyle.ForeColor = Color.Black;
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
                using (SqlConnection conn = new SqlConnection(DBCommon.connString))
                {
                    string query = @"SELECT PatientId, [Name] 
                             FROM Patient 
                             WHERE DoctorId = @DoctorId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DoctorId", Global.UserInfo.DoctorId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Patient");

                    cbPatients.DataSource = ds.Tables["Patient"];
                    cbPatients.DisplayMember = "Name";
                    cbPatients.ValueMember = "PatientId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load bệnh nhân: " + ex.Message);
            }
        }

        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm form = new MenuForm();
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

            //// Lấy số lượng thuốc nhập từ TextBox (txtNumMes)
            //int dose = 0;
            //int.TryParse(txtNumMes.Text.Trim(), out dose);

            //// Xác định số lượng cho từng thời điểm:
            //int qMorning = chkMorning.Checked ? dose : 0;
            //int qNoon = chkNoon.Checked ? dose : 0;
            //int qEvening = chkEvening.Checked ? dose : 0;
            //int qNight = chkNight.Checked ? dose : 0;

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
            //medicineDataGridView.Rows[rowIndex].Cells["MedicineName"].Value = medName;
            //medicineDataGridView.Rows[rowIndex].Cells["MorningDose"].Value = qMorning;
            //medicineDataGridView.Rows[rowIndex].Cells["NoonDose"].Value = qNoon;
            //medicineDataGridView.Rows[rowIndex].Cells["EveningDose"].Value = qEvening;
            //medicineDataGridView.Rows[rowIndex].Cells["NightDose"].Value = qNight;
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
            using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // Lưu thông tin Diagnosis
                    string query = @"INSERT INTO Diagnosis (PatientId, DoctorId, AddedDate, AddedBy,Dianosis)
                             VALUES (@PatientId, @DoctorId, @AddedDate, @AddedBy,@Dianosis);
                             SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(query, conn, transaction);
                    cmd.Parameters.AddWithValue("@PatientId", cbPatients.SelectedValue);
                    cmd.Parameters.AddWithValue("@DoctorId", Global.UserInfo.DoctorId);
                    cmd.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@AddedBy", Global.UserInfo.UserId);
                    cmd.Parameters.AddWithValue("@Dianosis", txtDianosis.Text.Trim());

                    int diagnosisId = Convert.ToInt32(cmd.ExecuteScalar());

                    if (diagnosisId > 0)
                    {
                        // Duyệt qua tất cả các dòng trong DataGridView (bỏ qua dòng mới)
                        for (int i = 0; i < medicineDataGridView.Rows.Count; i++)
                        {
                            if (medicineDataGridView.Rows[i].IsNewRow)
                                continue;

                            string medName = medicineDataGridView.Rows[i].Cells["MedicineName"].Value?.ToString();
                            if (string.IsNullOrEmpty(medName))
                                continue;

                            int morning = Convert.ToInt32(medicineDataGridView.Rows[i].Cells["MorningDose"].Value ?? 0);
                            int noon = Convert.ToInt32(medicineDataGridView.Rows[i].Cells["NoonDose"].Value ?? 0);
                            int evening = Convert.ToInt32(medicineDataGridView.Rows[i].Cells["EveningDose"].Value ?? 0);
                            int night = Convert.ToInt32(medicineDataGridView.Rows[i].Cells["NightDose"].Value ?? 0);

                            // Chú ý: Sửa INSERT vào bảng Prescription
                            query = @"INSERT INTO Prescription 
                              (MedicineName, DiagnosisId, MorningDose, NoonDose, EveningDose, NightDose, PatientId, AddedDate, AddedBy)
                              VALUES 
                              (@MedicineName, @DiagnosisId, @MorningDose, @NoonDose, @EveningDose, @NightDose, @PatientId, @AddedDate, @AddedBy);";
                            cmd = new SqlCommand(query, conn, transaction);
                            cmd.Parameters.AddWithValue("@MedicineName", medName);
                            cmd.Parameters.AddWithValue("@DiagnosisId", diagnosisId);
                            cmd.Parameters.AddWithValue("@MorningDose", morning);
                            cmd.Parameters.AddWithValue("@NoonDose", noon);
                            cmd.Parameters.AddWithValue("@EveningDose", evening);
                            cmd.Parameters.AddWithValue("@NightDose", night);
                            cmd.Parameters.AddWithValue("@PatientId", cbPatients.SelectedValue);
                            cmd.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@AddedBy", Global.UserInfo.UserId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    MessageBox.Show("Lưu thành công!");
                    LoadPatients();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
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
                string query = "SELECT MedicineId, MedicineName FROM Medicine";
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

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {

        }
    }
}
