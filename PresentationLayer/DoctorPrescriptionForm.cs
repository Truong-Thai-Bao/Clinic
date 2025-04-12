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

namespace PresentationLayer
{
    public partial class DoctorPrescriptionForm : Form
    {
        Patient patient = new Patient();
        List<Medicine> medicines = new List<Medicine>();
        List<Prescription> prescriptions = new List<Prescription>();

        SqlConnection sqlCon = new SqlConnection(DBCommon.connString);
        int _patientId = 0;
        public DoctorPrescriptionForm()
        {
            InitializeComponent();
            LoadPatients();
        }

        private void LoadPatients()
        {
            using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            {
                try
                {
                    string query = "SELECT PatientId, PCode FROM Patient";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Patient");
                    cbPatientCode.DisplayMember = "PCode";
                    cbPatientCode.ValueMember = "PatientId";
                    cbPatientCode.DataSource = ds.Tables["Patient"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi!");
                }
            }
        }
        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm form = new MenuForm();
            form.Show();
        }

        private void btnViewPrescription_Click(object sender, EventArgs e)
        {
            _patientId = Convert.ToInt32(cbPatientCode.SelectedValue);
            if (_patientId > 0)
            {
                // Gán tài liệu cho PrintPreviewDialog
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân!");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            _patientId = Convert.ToInt32(cbPatientCode.SelectedValue);
            if (_patientId > 0)
            {
                //Patient
                sqlCon = BusinessLayer.CmnMethods.OpenConnectionString(sqlCon);
                string query = string.Format(@"SELECT * FROM View_Patient WHERE PatientId = {0}", _patientId);
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sqlCon.Close();

                patient = this.GetPatientInfo(dt);

                //Medicine
                sqlCon = BusinessLayer.CmnMethods.OpenConnectionString(sqlCon);
                query = string.Format(@"SELECT * FROM Medicine WHERE PatientId = {0}", _patientId);
                sda = new SqlDataAdapter(query, sqlCon);
                dt = new DataTable();
                sda.Fill(dt);
                sqlCon.Close();

                medicines = this.GetMedicinesInfo(dt);

                //Prescription
                sqlCon = BusinessLayer.CmnMethods.OpenConnectionString(sqlCon);
                query = string.Format(@"SELECT * FROM Prescription WHERE PatientId = {0}", _patientId);
                sda = new SqlDataAdapter(query, sqlCon);
                dt = new DataTable();
                sda.Fill(dt);
                sqlCon.Close();

                prescriptions = this.GetPrescriptionsInfo(dt);
                // Nếu không có đơn thuốc thì báo lỗi
                if (prescriptions == null)
                {
                    MessageBox.Show("Không tìm thấy đơn thuốc cho bệnh nhân này.");
                    return;
                }

                e.Graphics.DrawString("ĐƠN THUỐC", new Font("Centuary", 22, FontStyle.Bold), Brushes.Red, new Point(300, 40));

                e.Graphics.DrawString("Tên bệnh nhân: " + patient.PatientName, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 105));
                e.Graphics.DrawString("Số điện thoại: " + patient.Contact, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 125));
                e.Graphics.DrawString("Địa chỉ: " + patient.Address, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 145));
                e.Graphics.DrawString("Tuổi: " + patient.Age, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(400, 105));
                e.Graphics.DrawString("Giới tính: " + patient.Gender, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(530, 105));
                e.Graphics.DrawString("Nhóm máu: " + patient.BloodGroup, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 165));
                e.Graphics.DrawString("Mã BN: " + patient.PCode, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 185));
                e.Graphics.DrawString("Bác sĩ điều trị: " + patient.DoctorName, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 205));

                int currentY = 245;
                foreach (var pres in prescriptions)
                {
                    // In tên thuốc
                    e.Graphics.DrawString(pres.MedicineName, new Font("Arial", 16, FontStyle.Italic), Brushes.Black, new Point(120, currentY));
                    currentY += 25;
                    // In liều dùng
                    e.Graphics.DrawString("Sáng: " + pres.MorningDose +
                                            "   Trưa: " + pres.NoonDose +
                                            "   Chiều: " + pres.EveningDose +
                                            "   Tối: " + pres.NightDose,
                                            new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, currentY));
                    currentY += 35;
                }

                string soThuoc = "Số lượng thuốc được kê: " + prescriptions.Count.ToString() + " loại.";
                e.Graphics.DrawString(soThuoc,
                    new Font("Arial", 14, FontStyle.Regular),
                    Brushes.Black,
                    new Point(120, currentY = currentY + 20));
                currentY += 30;

                e.Graphics.DrawString("Lời dặn của bác sĩ: ", new Font("Arial", 14, FontStyle.Bold | FontStyle.Italic), Brushes.Black, new Point(120, currentY + 30));

                var firstPrescription = prescriptions.FirstOrDefault();
                if (firstPrescription != null)
                {
                    string henKham = "Hẹn khám sau 14 ngày (" +
                        firstPrescription.AddedDate.AddDays(14).ToString("dd/MM/yyyy") + ")";

                    e.Graphics.DrawString(henKham,
                        new Font("Arial", 14, FontStyle.Italic),
                        Brushes.Black,
                        new Point(300, currentY =  currentY + 30));
                    currentY += 30;
                }

                e.Graphics.DrawString("Ngày khám: " + DateTime.Now.ToString("dd/MM/yyyy"), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, currentY = currentY + 20));
            }
        }

        private Patient GetPatientInfo(DataTable dt)
        {
            Patient patient = (from rw in dt.AsEnumerable()
                                select new Patient()
                                {
                                    PatientName = Convert.ToString(rw["Name"]),
                                    Address = Convert.ToString(rw["Address"]),
                                    Contact = Convert.ToString(rw["Contact"]),
                                    Age = DateTime.Now.Year - Convert.ToDateTime(rw["DateOfBirth"]).Year,
                                    Gender = Convert.ToString(rw["Gender"]),
                                    BloodGroup = Convert.ToString(rw["BloodGroup"]),
                                    PCode = Convert.ToString(rw["PCode"]),
                                    DoctorName = Convert.ToString(rw["DoctorName"])
                                }).ToList().FirstOrDefault();
            return patient;
        }

        private List<Medicine> GetMedicinesInfo(DataTable dt)
        {
            List<Medicine> medicines = (from rw in dt.AsEnumerable()
                                        select new Medicine()
                                        {
                                            MedicineName = Convert.ToString(rw["MedicineName"]),
                                        }).ToList();
            return medicines;
        }

        public List<Prescription> GetPrescriptionsInfo(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
                return new List<Prescription>();

            try
            {
                return (from rw in dt.AsEnumerable()
                        select new Prescription()
                        {
                            PrescriptionId = Convert.ToInt32(rw["PrescriptionId"]),
                            DiagnosisId = Convert.ToInt32(rw["DiagnosisId"]),
                            PatientId = Convert.ToInt32(rw["PatientId"]),
                            MedicineName = Convert.ToString(rw["MedicineName"]),
                            MorningDose = string.IsNullOrEmpty(rw["MorningDose"].ToString()) ? 0 : Convert.ToInt32(rw["MorningDose"]),
                            NoonDose = string.IsNullOrEmpty(rw["NoonDose"].ToString()) ? 0 : Convert.ToInt32(rw["NoonDose"]),
                            EveningDose = string.IsNullOrEmpty(rw["EveningDose"].ToString()) ? 0 : Convert.ToInt32(rw["EveningDose"]),
                            NightDose = string.IsNullOrEmpty(rw["NightDose"].ToString()) ? 0 : Convert.ToInt32(rw["NightDose"]),
                            AddedDate = Convert.ToDateTime(rw["AddedDate"])
                        }).ToList();
            }
            catch
            {
                return new List<Prescription>();
            }
        }
    }
}