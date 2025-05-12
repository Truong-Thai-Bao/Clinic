using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DataTransferLayer;
namespace PresentationLayer
{
    public partial class MenuForm : Form
    {
        private DataTransferLayer.UserInfo currentUser;
        public MenuForm(DataTransferLayer.UserInfo userInfo)
        {
            InitializeComponent();
            currentUser = userInfo;
        }

        private void pictureBoxDoctors_Click(object sender, EventArgs e)
        {
            if (currentUser.UserType != 1)
            {
                MessageBox.Show("Chỉ có admin mới có quyền truy cập chức năng này!");
            }
            else
            {
                this.Hide();
                DoctorForm doctorForm = new DoctorForm(currentUser);
                doctorForm.Show();

            }    
        }

        private void pictureBoxPatients_Click(object sender, EventArgs e)
        {
            if (currentUser.UserType != 1)
            {
                MessageBox.Show("Chỉ có admin mới có quyền truy cập chức năng này!");
            }
            else
            {
                this.Hide();
                PatientArrivalForm patientArrivalForm = new PatientArrivalForm(currentUser);
                patientArrivalForm.Show();
            }
        }

        private void pictureBoxDiagnosis_Click(object sender, EventArgs e)
        {

            if (currentUser.UserType  != 2)
            {
                MessageBox.Show("Chỉ có Bác sĩ mới có quyền truy cập chức năng này!");
            }
            else
            {

                this.Hide();
                DiagnosisForm diagnosisForm = new DiagnosisForm(currentUser);
                diagnosisForm.Show();
            }
        }

        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBoxMedicines_Click(object sender, EventArgs e)
        {
            if(Global.UserInfo.UserType != 1) { 
                
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AppointmentForm appointmentForm = new AppointmentForm(currentUser);
            appointmentForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RevenueStatistics revenueStatistics = new RevenueStatistics();
            revenueStatistics.Show();
        }
    }
}
