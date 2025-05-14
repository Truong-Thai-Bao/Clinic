using QRCoder;
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
using BusinessLayer;
using Microsoft.Data.SqlClient;
using DataTransferLayer;
using System.Drawing.Printing;

namespace PresentationLayer
{
    public partial class DoctorPrescriptionForm : Form
    {
        private DataTransferLayer.UserInfo currentUser;
        private DiagnosisBL diagnosisBL = new DiagnosisBL();
        private PatientBL patientBL = new PatientBL();
        private PrescriptionBL prescriptionBL = new PrescriptionBL();
        private MedicineBL medicineBL = new MedicineBL();
        private DoctorBL doctorBL = new DoctorBL();


        int _patientId = 0;
        PatientDL patient = new PatientDL();
        MedicineDL medicineDL = new MedicineDL();
        private List<MedicineDTO> medicines;

        SqlConnection sqlCon = new SqlConnection(DBCommon.connString);
        

        // Khai báo các thành phần giao diện
        private PrintPreviewDialog printPreviewPrescription = new PrintPreviewDialog();
        private PrintPreviewDialog printPreviewInvoice = new PrintPreviewDialog();
        private PrintDocument printPrescription = new PrintDocument();
        private PrintDocument printInvoice = new PrintDocument();

        public DoctorPrescriptionForm(UserInfo currentUser)
        {
            InitializeComponent();
            LoadPatients();
            this.currentUser = currentUser;
            printPrescription.PrintPage += new PrintPageEventHandler(printDocumentPrescription_PrintPage);
            printInvoice.PrintPage += new PrintPageEventHandler(printDocumentInvoice_PrintPage);
            medicines = medicineDL.GetMedicinesByPatientId(_patientId);
        }

        private void LoadPatients()
        {
            try
            {
                var patients = PatientBL.GetAllPatientIdAndPCode();
                cbPatientCode.DisplayMember = "PCode";
                cbPatientCode.ValueMember = "PatientId";
                cbPatientCode.DataSource = patients;
            }
            catch
            (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải danh sách bệnh nhân: " + ex.Message);
            }
        }
        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm form = new MenuForm(currentUser);
            form.Show();
        }

        private void btnViewPrescription_Click(object sender, EventArgs e)
        {
            if (cbPatientCode.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _patientId = Convert.ToInt32(cbPatientCode.SelectedValue);
            //MessageBox.Show($"Đang xem đơn thuốc cho bệnh nhân ID: {_patientId}", "Debug");
            PatientDTO patientDTO = patientBL.GetPatientInfo(_patientId);
            if (patientDTO == null)
            {
                MessageBox.Show("Không tìm thấy thông tin bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<PrescriptionDTO> prescriptions = prescriptionBL.GetPrescriptionsByPatientId(_patientId);
            if (prescriptions == null || prescriptions.Count == 0)
            {
                MessageBox.Show("Không tìm thấy đơn thuốc cho bệnh nhân này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            printPreviewPrescription.Document = printPrescription;
            printPreviewPrescription.ShowDialog();
            //if (_patientId > 0)
            //{
            //    // Gán tài liệu cho PrintPreviewDialog
            //    printPreviewPrescription.Document = printDocumentPrescription;
            //    printPreviewPrescription.ShowDialog();

            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn bệnh nhân!");
            //}
        }

        private void btnViewInvoice_Click(object sender, EventArgs e)
        {
            if (cbPatientCode.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _patientId = Convert.ToInt32(cbPatientCode.SelectedValue);
            PatientDTO patientDTO = patientBL.GetPatientInfo(_patientId);
            if (patientDTO == null)
            {
                MessageBox.Show("Không tìm thấy thông tin bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<PrescriptionDTO> prescriptions = prescriptionBL.GetPrescriptionsByPatientId(_patientId);
            if (prescriptions == null || prescriptions.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn cho bệnh nhân này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            printPreviewInvoice.Document = printInvoice;
            printPreviewInvoice.ShowDialog();

            //if (_patientId > 0)
            //{
            //    printPreviewInvoice.Document = printInvoice;
            //    printPreviewInvoice.ShowDialog();

            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn bệnh nhân!");
            //}
        }

        private void printDocumentPrescription_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_patientId <= 0) return;
            PatientDTO patientInfo = patientBL.GetPatientInfo(_patientId);
            if (patientInfo == null)
            {
                MessageBox.Show("Không tìm thấy thông tin bệnh nhân.");
                return;
            }

            DoctorDTO doctor = doctorBL.GetDoctorById(patientInfo.DoctorId);
            if (doctor == null)
            {
                MessageBox.Show("Không tìm thấy thông tin bác sĩ.");
                return;
            }

            List<PrescriptionDTO> prescriptions = prescriptionBL.GetPrescriptionsByPatientId(_patientId);
            if (prescriptions == null || prescriptions.Count == 0)
            {
                MessageBox.Show("Không tìm thấy đơn thuốc cho bệnh nhân này.");
                return;
            }
            string diagnosis = diagnosisBL.GetDiagnosisByPatientId(_patientId);

            e.Graphics.DrawString("ĐƠN THUỐC", new Font("Centuary", 22, FontStyle.Bold), Brushes.Red, new Point(300, 40));

            e.Graphics.DrawString("Tên bệnh nhân: " + patientInfo.Name, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 105));
            e.Graphics.DrawString("Số điện thoại: " + patientInfo.Contact, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 125));
            e.Graphics.DrawString("Địa chỉ: " + patientInfo.Address, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 145));
            e.Graphics.DrawString("Tuổi: " + patientInfo.Age, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(400, 105));
            e.Graphics.DrawString("Giới tính: " + patientInfo.Gender, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(530, 105));
            e.Graphics.DrawString("Nhóm máu: " + patientInfo.BloodGroup, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 165));
            e.Graphics.DrawString("Mã BN: " + patientInfo.PCode, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 185));
            e.Graphics.DrawString("Bác sĩ điều trị: " + doctor.DocName, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 205));
            e.Graphics.DrawString("Chẩn đoán: " + diagnosis, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 225));

            int currentY = 265;
            int i = 1;
            foreach (var pres in prescriptions)
            {
                // In tên thuốc
                e.Graphics.DrawString(i.ToString()+". " + pres.MedicineName, new Font("Arial", 12, FontStyle.Italic), Brushes.Black, new Point(120, currentY));
                currentY += 25;
                ++i;
                // In liều dùng
                e.Graphics.DrawString("Sáng: " + pres.MorningDose +
                                        "   Trưa: " + pres.NoonDose +
                                        "   Chiều: " + pres.AfternoonDose +
                                        + pres.Day + "x   Ngày =  " + (pres.MorningDose + pres.NoonDose + pres.AfternoonDose) * pres.Day +
                                        " "+ pres.Type,
                new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(120, currentY));
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
                    new Point(300, currentY = currentY + 30));
                currentY += 30;
            }

            e.Graphics.DrawString("Ngày khám: " + DateTime.Now.ToString("dd/MM/yyyy"), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, currentY = currentY + 20));


            e.Graphics.DrawString("Mã QR của bệnh nhân", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(500, currentY = currentY + 40));
            // In mã QR
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("Mã bệnh nhân: " + patientInfo.PCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Image qrCodeImage = qrCode.GetGraphic(5);
            e.Graphics.DrawImage(qrCodeImage, new Point(500, currentY = currentY + 20));
        }

        private void printDocumentInvoice_PrintPage(object sender, PrintPageEventArgs e)
        {
            {
                //int patientId = Convert.ToInt32(cbPatientCode.SelectedValue);
                if (_patientId <= 0) return;

                // In thông tin bệnh nhân
                PatientDTO patientInfo = patientBL.GetPatientInfo(_patientId);
                if (patientInfo == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin bệnh nhân.");
                    return;
                }

                // In thông tin đơn thuốc
                DoctorDTO doctor = doctorBL.GetDoctorById(patientInfo.DoctorId);
                if (doctor == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin bác sĩ.");
                    return;
                }

                List<PrescriptionDTO> prescriptions = prescriptionBL.GetPrescriptionsByPatientId(_patientId);
                if (prescriptions == null || prescriptions.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy đơn thuốc cho bệnh nhân này.");
                    return;
                }

                // Tính tiền
                decimal totalMedicinePrice = 0;
                int startY = 205;

                int startX = 80;
                int currentY = 205;
                Font titleFont = new Font("Arial", 22, FontStyle.Bold);
                Font headerFont = new Font("Arial", 14, FontStyle.Bold);
                Font contentFont = new Font("Arial", 13, FontStyle.Regular);
                Font totalFont = new Font("Arial", 14, FontStyle.Bold);

                // Tiêu đề
                e.Graphics.DrawString("HÓA ĐƠN THANH TOÁN", titleFont, Brushes.Red, new Point(startX + 170, currentY));
                currentY += 50;

                // Thông tin bệnh nhân
                e.Graphics.DrawString("Tên bệnh nhân: " + patientInfo.Name, contentFont, Brushes.Black, new Point(startX, currentY += 30));
                e.Graphics.DrawString("Số điện thoại: " + patientInfo.Contact, contentFont, Brushes.Black, new Point(startX, currentY += 25));
                e.Graphics.DrawString("Địa chỉ: " + patientInfo.Address, contentFont, Brushes.Black, new Point(startX, currentY += 25));
                e.Graphics.DrawString("Tuổi: " + patientInfo.Age, contentFont, Brushes.Black, new Point(startX, currentY += 25));
                e.Graphics.DrawString("Bác sĩ điều trị: " + doctor.DocName, contentFont, Brushes.Black, new Point(startX, currentY += 25));

                currentY += 30;
                e.Graphics.DrawString("Danh sách thuốc:", headerFont, Brushes.Black, new Point(startX, currentY));

                // Bảng thuốc
                currentY += 30;
                int i = 1;
                foreach (var pres in prescriptions)
                {
                    // Lấý giá thuốc từ bảng Medicine theo MedicineId
                    MedicineDTO medInfo = medicineBL.GetMedicineById(pres.MedicineId);
                    decimal medPrice = medInfo != null ? medInfo.Price : 0;

                    totalMedicinePrice += medPrice;
                    string line = $"{pres.MedicineName}-{pres.Price:N0} VNĐ";
                    e.Graphics.DrawString(line, contentFont, Brushes.Black, new Point(startX + 20, currentY));
                    
                    currentY += 25;
                    ++i;
                }

                // Tiền khám
                decimal consultationFee = 50000;
                currentY += 20;
                e.Graphics.DrawString("Tiền thuốc : " + totalMedicinePrice.ToString("N0") + " VNĐ", contentFont, Brushes.Black, new Point(startX, currentY));
                currentY += 25;
                e.Graphics.DrawString("Tiền khám : " + consultationFee.ToString("N0") + " VNĐ", contentFont, Brushes.Black, new Point(startX, currentY));
                currentY += 25;

                // Tổng tiền
                decimal totalAmount = totalMedicinePrice + consultationFee;
                e.Graphics.DrawString("TỔNG TIỀN : " + totalAmount.ToString("N0") + " VNĐ", totalFont, Brushes.Red, new Point(startX, currentY));

            }
        }
    }
}