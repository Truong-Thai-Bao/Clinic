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

        public DataTable GetAppointmentsByKeyword(string keyword)
        {
            try
            {
                return appointmentDL.FilterAppointmentByKeyword(keyword);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lọc lịch hẹn: {ex.Message}");
            }
        }
        public int AddAppointment(AppointmentDTO appointment)
        {
            try
            {
                return appointmentDL.AddAppointment(appointment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm lịch hẹn: {ex.Message}");
            }
        }

        public void UpdateAppointment(AppointmentDTO appointment, PatientDTO patient)
        {
            try
            {
                appointmentDL.UpdateAppointment(appointment, patient);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật lịch hẹn: {ex.Message}");
            }
        }

        public void DeleteAppointment(int appointmentId)
        {
            try
            {
                appointmentDL.DeleteAppointment(appointmentId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa lịch hẹn: {ex.Message}");
            }
        }
        public int GetAppointment(int patientId,string  doctorName)
        {
            try
            {
                return appointmentDL.GetAppId(patientId, doctorName);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void UpdateStatusById(int appointmentId)
        {
            try
            {
                appointmentDL.UpdateStatus(appointmentId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
