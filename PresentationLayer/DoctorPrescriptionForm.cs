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
                    SqlDataAdapter da = new SqlDataAdapter(query, sqlCon);
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
            //if(printPreviewDialog1.ShowDialog() == DialogResult.OK && _patientId > 0)
            //{
            //    printDocument1.Print();
            //}
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
            Patient patient = new Patient();
            List <Medicine> medicines = new List<Medicine>();

            _patientId = Convert.ToInt32(cbPatientCode.SelectedValue);
            if (_patientId > 0)
            {
                sqlCon = BusinessLayer.CmnMethods.OpenConnectionString(sqlCon);
                string query = string.Format(@"SELECT * FROM View_Patient WHERE PatientId = {0}", _patientId);
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sqlCon.Close();

                patient = this.GetPatientInfo(dt);

                sqlCon = BusinessLayer.CmnMethods.OpenConnectionString(sqlCon);
                query = string.Format(@"SELECT * FROM Medicine WHERE PatientId = {0}", _patientId);
                sda = new SqlDataAdapter(query, sqlCon);
                dt = new DataTable();
                sda.Fill(dt);
                sqlCon.Close();

                medicines = this.GetMedicinesInfo(dt);

                e.Graphics.DrawString("==Hồ sơ bệnh nhân==", new Font("Centuary", 22, FontStyle.Bold), Brushes.Red, new Point(200, 40));

                e.Graphics.DrawString("Tên bệnh nhân: " + patient.PatientName, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 105));
                e.Graphics.DrawString("Giới tính: " + patient.Gender, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 125));
                e.Graphics.DrawString("Tuổi: " + patient.Age, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 145));
                e.Graphics.DrawString("Nhóm máu: " + patient.BloodGroup, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 165));
                e.Graphics.DrawString("Mã BN: " + patient.PCode, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 185));
                e.Graphics.DrawString("Số điện thoại: " + patient.Contact, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 205));
                e.Graphics.DrawString("Địa chỉ: " + patient.Address, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 225));
                e.Graphics.DrawString("Bác sĩ điều trị: " + patient.DoctorName, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 245));

                e.Graphics.DrawString("Thuốc: ", new Font("Centuary", 14, FontStyle.Regular), Brushes.Black, new Point(120, 285));

                int rowGap = 20,
                    lastPoint = 285;
                foreach (var medicine in medicines)
                {
                    lastPoint += rowGap;
                    e.Graphics.DrawString(medicine.MedicineName, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, lastPoint));
                }
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
                                   Age = Convert.ToInt32(rw["Age"]),
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

        private void DoctorPrescriptionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
