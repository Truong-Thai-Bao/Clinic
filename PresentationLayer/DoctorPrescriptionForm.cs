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

        private PatientBL patientBL = new PatientBL();
        private PrescriptionBL prescriptionBL = new PrescriptionBL();
        private MedicineBL medicineBL = new MedicineBL();
        private DoctorBL doctorBL = new DoctorBL();

        PatientDL patient = new PatientDL();

        SqlConnection sqlCon = new SqlConnection(DBCommon.connString);
        int _patientId = 0;

        // Khai báo các thành phần giao diện
        private PrintPreviewDialog printPreviewPrescription = new PrintPreviewDialog();
        private PrintPreviewDialog printPreviewInvoice = new PrintPreviewDialog();
        private PrintDocument printPrescription = new PrintDocument();
        private PrintDocument printInvoice = new PrintDocument();

        public DoctorPrescriptionForm()
        {
            InitializeComponent();
            LoadPatients();

            printPrescription.PrintPage += new PrintPageEventHandler(printDocumentPrescription_PrintPage);
            printInvoice.PrintPage += new PrintPageEventHandler(printDocumentInvoice_PrintPage);
        }

        private void LoadPatients()
        {
            try
            {
                var patients = PatientBL.GetAllPatientIdAndPCode();
                cbPatientCode.DisplayMember = "PCode";
                cbPatientCode.ValueMember = "PatientId";
                cbPatientCode.DataSource = patients;

                //Debug
                MessageBox.Show("Số lượng bệnh nhân: " + cbPatientCode.Items.Count);
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
            MessageBox.Show($"Đang xem đơn thuốc cho bệnh nhân ID: {_patientId}", "Debug");
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
            MessageBox.Show($"Đang xem hóa đơn cho bệnh nhân ID: {_patientId}", "Debug");

            PatientDTO patientInfo = patientBL.GetPatientInfo(_patientId);
            if (patientInfo == null)
            {
                MessageBox.Show("Không tìm thấy thông tin bệnh nhân.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<PrescriptionDTO> prescriptions = prescriptionBL.GetPrescriptionsByPatientId(_patientId);
            if (prescriptions == null || prescriptions.Count == 0)
            {
                MessageBox.Show("Không tìm thấy đơn thuốc cho bệnh nhân này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<MedicineDTO> medicines = medicineBL.GetMedicinesByPatientId(_patientId);
            if (medicines == null || medicines.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin thuốc cho bệnh nhân này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //_patientId = Convert.ToInt32(cbPatientCode.SelectedValue);
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

            // Debug: Kiểm tra dữ liệu
            MessageBox.Show($"Patient ID: {_patientId}\nPrescriptions Count: {prescriptions.Count}", "Debug");

            e.Graphics.DrawString("ĐƠN THUỐC", new Font("Centuary", 22, FontStyle.Bold), Brushes.Red, new Point(300, 40));

            e.Graphics.DrawString("Tên bệnh nhân: " + patientInfo.Name, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 105));
            e.Graphics.DrawString("Số điện thoại: " + patientInfo.Contact, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 125));
            e.Graphics.DrawString("Địa chỉ: " + patientInfo.Address, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 145));
            e.Graphics.DrawString("Tuổi: " + patientInfo.Age, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(400, 105));
            e.Graphics.DrawString("Giới tính: " + patientInfo.Gender, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(530, 105));
            e.Graphics.DrawString("Nhóm máu: " + patientInfo.BloodGroup, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 165));
            e.Graphics.DrawString("Mã BN: " + patientInfo.PCode, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 185));
            e.Graphics.DrawString("Bác sĩ điều trị: " + doctor.DocName, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 205));

            int currentY = 245;
            foreach (var pres in prescriptions)
            {
                // In tên thuốc
                e.Graphics.DrawString(pres.MedicineName, new Font("Arial", 16, FontStyle.Italic), Brushes.Black, new Point(120, currentY));
                currentY += 25;
                // In liều dùng
                e.Graphics.DrawString("Sáng: " + pres.MorningDose +
                                        "   Trưa: " + pres.NoonDose +
                                        "   Chiều: " + pres.AfternoonDose,
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
                // Lấy danh sách thuốc
                List<MedicineDTO> medicines = medicineBL.GetMedicinesByPatientId(_patientId);
                if (medicines == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin thuốc.");
                    return;
                }

                // Tính tiền
                decimal totalMedicinePrice = 0;
                int startY = 205;

                // Debug: Kiểm tra dữ liệu
                MessageBox.Show($"Patient ID: {_patientId}\nPrescriptions Count: {prescriptions.Count}\nMedicines Count: {medicines.Count}", "Debug");

                e.Graphics.DrawString("HÓA ĐƠN THANH TOÁN", new Font("Arial", 22, FontStyle.Bold), Brushes.Red, new Point(250, 40));
                e.Graphics.DrawString("Tên bệnh nhân: " + patientInfo.Name, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 105));
                e.Graphics.DrawString("Số điện thoại: " + patientInfo.Contact, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 125));
                e.Graphics.DrawString("Địa chỉ: " + patientInfo.Address, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 145));
                e.Graphics.DrawString("Tuổi: " + patientInfo.Age, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 165));
                e.Graphics.DrawString("Bác sĩ điều trị: " + doctor.DocName, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, 185));

                e.Graphics.DrawString("Tên thuốc", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(120, startY));

                foreach (var pres in prescriptions)
                {
                    var medicine = medicines.FirstOrDefault(m => m.MedicineName == pres.MedicineName);
                    if (medicine != null)
                    {
                        totalMedicinePrice += medicine.Price;
                        string line = $"{pres.MedicineName} - {medicine.Type} - {medicine.Price:N0} VNĐ";
                        e.Graphics.DrawString(line, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, startY += 25));
                    }
                }

                // Tiền khám (cố định)
                decimal consultationFee = 50000;

                startY += 10;
                e.Graphics.DrawString("Tiền thuốc : " + totalMedicinePrice.ToString("N0") + " VNĐ", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, startY));
                startY += 25;
                e.Graphics.DrawString("Tiền khám : " + consultationFee.ToString("N0") + " VNĐ", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(120, startY));
                startY += 25;

                //Tổng tiền
                decimal totalAmount = totalMedicinePrice + consultationFee;
                e.Graphics.DrawString("Tổng tiền : " + totalAmount.ToString("N0") + " VNĐ", new Font("Arial", 14, FontStyle.Bold), Brushes.Red, new Point(120, startY));
            }
        }
    }
}