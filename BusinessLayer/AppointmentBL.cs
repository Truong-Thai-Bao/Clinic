using DataLayer;
using DataTransferLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataTransferLayer;

namespace BusinessLayer
{
    public class AppointmentBL
    {
        private AppointmentDL appointmentDL = new AppointmentDL();

        public  DataTable GetAllAppointments()
        {
            try
            {
                return appointmentDL.GetAllAppointment();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách lịch hẹn: {ex.Message}");
            }
        }

        public DataTable FilterAppointments(string doctorName, DateTime? date, string keyword)
        {
            try
            {
                return appointmentDL.FilterAppointments(doctorName, date, keyword);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lọc lịch hẹn: {ex.Message}");
            }
        }
        public void AddAppointment(AppointmentDTO appointment)
        {
            appointmentDL.AddAppointment(appointment);
        }

        public void UpdateAppointment(AppointmentDTO appointment, PatientDTO patient)
        {
            appointmentDL.UpdateAppointment(appointment, patient);
        }

        public void DeleteAppointment(int appointmentId)
        {
            appointmentDL.DeleteAppointment(appointmentId);
        }
    }
}
