using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BusinessLayer
{
    public class AppointmentBUS
    {
        // Dùng để lấy trạng thái của lịch hẹn
        public static string GetAppointmentStatus(DateTime date, TimeSpan time, int isArrived)
        {
            DateTime now = DateTime.Now;
            DateTime appointmentDateTime = date.Date + time;

            if (isArrived == 2) return "Hủy hẹn";
            if (isArrived == 1) return "Đã đến";
            if (now < appointmentDateTime) return "Chưa đến";
            if (now.Date == date.Date && now.TimeOfDay > time) return "Chưa đến";
            return "Quá hạn";
        }

        // Dùng để xác nhận bệnh nhân đã đến
        public static void MarkAppointmentAsArrived(string appointmentId)
        {
            using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            using (SqlCommand cmd = new SqlCommand("UPDATE Appointment SET IsArrived = 1 WHERE AppointmentID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", appointmentId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Dùng để hủy lịch hẹn
        public static void CancelAppointment(string appointmentId)
        {
            string query = "UPDATE Appointment SET IsArrived = 2 WHERE AppointmentID = @id";
            using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", appointmentId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
