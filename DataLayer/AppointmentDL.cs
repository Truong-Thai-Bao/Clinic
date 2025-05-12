using DataTransferLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AppointmentDL:DBCommon
    {
        public DataTable GetAllAppointment()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = @"
                        SELECT a.AppointmentID, a.PatientId, a.DoctorName, a.AppointmentDate, a.AppointmentTime, 
                               a.Symptoms, a.Status, a.IsArrived, 
                               p.Name AS PatientName, p.DateOfBirth, p.Gender, p.BloodGroup, p.Contact
                        FROM Appointment a
                        INNER JOIN Patient p ON a.PatientId = p.PatientId";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    conn.Open();
                    adapter.Fill(dt);
                    return dt;

                    string patientQuery = "SELECT * FROM Patient";
                    SqlCommand patientCmd = new SqlCommand(patientQuery, conn);
                    SqlDataAdapter patientAdapter = new SqlDataAdapter(patientCmd);
                    DataTable patientDt = new DataTable();
                    conn.Open();
                    patientAdapter.Fill(patientDt);
                    return patientDt;
                }
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
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = @"
                        SELECT a.AppointmentID, a.PatientId, a.DoctorName, a.AppointmentDate, a.AppointmentTime, 
                               a.Symptoms, a.Status, a.IsArrived, 
                               p.Name AS PatientName, p.DateOfBirth, p.Gender, p.BloodGroup, p.Contact
                        FROM Appointment a
                        INNER JOIN Patient p ON a.PatientId = p.PatientId
                        WHERE 1=1";
                    if (!string.IsNullOrEmpty(doctorName) && doctorName != "Tất cả")
                    {
                        query += " AND a.DoctorName = @DoctorName";
                    }
                    if (date.HasValue)
                    {
                        query += " AND CAST (a.AppointmentDate AS DATE) = @AppointmentDate";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (!string.IsNullOrEmpty(doctorName) && doctorName != "Tất cả")
                    {
                        cmd.Parameters.AddWithValue("@DoctorName", doctorName);
                    }
                    if (date.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@AppointmentDate", date.Value);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Lọc theo từ khóa (tên bệnh nhân hoặc liên lạc)
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        keyword = keyword.ToLower();
                        DataTable filteredDt = dt.Clone();
                        foreach (DataRow row in dt.Rows)
                        {
                            string patientName = row["PatientName"].ToString().ToLower();
                            string contact = row["Contact"].ToString().ToLower();
                            if (patientName.Contains(keyword) || contact.Contains(keyword))
                            {
                                filteredDt.ImportRow(row);
                            }
                            return filteredDt;
                        }
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lọc lịch hẹn: {ex.Message}");
            }
        }
        public void AddAppointment(AppointmentDTO appointment)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"
                    INSERT INTO Appointment
                    (PatientId, DoctorName, AppointmentDate, AppointmentTime, Symptoms, Status, IsArrived)
                    VALUES
                    (@PatientId, @DoctorName, @AppointmentDate, @AppointmentTime, @Symptoms, @Status, @IsArrived)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PatientID", appointment.PatientId);
                    cmd.Parameters.AddWithValue("@DoctorName", appointment.DoctorName);
                    cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    cmd.Parameters.AddWithValue("@AppointmentTime", appointment.AppointmentTime);
                    cmd.Parameters.AddWithValue("@Symptoms", appointment.Symptoms);
                    cmd.Parameters.AddWithValue("@Status", appointment.Status);
                    cmd.Parameters.AddWithValue("@IsArrived", appointment.IsArrived);
                    conn.Open();
                    cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAppointment(int appointmentID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "DELETE FROM Appointment WHERE AppointmentID = @AppointmentID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AppointmentID", appointmentID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa lịch hẹn: {ex.Message}");
            }
        }

        public void UpdateAppointment(AppointmentDTO appointment, PatientDTO patient)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = @"
                    UPDATE Appointment
                    SET DoctorName = @DoctorName,
                        AppointmentDate = @AppointmentDate,
                        AppointmentTime = @AppointmentTime,
                        Symptoms = @Symptoms
                    WHERE AppointmentID = @AppointmentID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DoctorName", appointment.DoctorName);
                    cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    cmd.Parameters.AddWithValue("@AppointmentTime", appointment.AppointmentTime);
                    cmd.Parameters.AddWithValue("@Symptoms", appointment.Symptoms);
                    cmd.Parameters.AddWithValue("@AppointmentID", appointment.AppointmentID);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    string patientQuery = @"
                    UPDATE Patient
                    SET Name = @Name,
                        DateOfBirth = @DateOfBirth,
                        Gender = @Gender,
                        Contact = @Contact,
                        Address = @Address,
                        BloodGroup = @BloodGroup
                    WHERE PatientId = @PatientId";
                    SqlCommand patientCmd = new SqlCommand(patientQuery, conn);
                    patientCmd.Parameters.AddWithValue("@Name", patient.Name);
                    patientCmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                    patientCmd.Parameters.AddWithValue("@Gender", patient.Gender);
                    patientCmd.Parameters.AddWithValue("@Contact", patient.Contact);
                    patientCmd.Parameters.AddWithValue("@BloodGroup", patient.BloodGroup);
                    patientCmd.Parameters.AddWithValue("@PatientId", patient.PatientId);
                    patientCmd.Parameters.AddWithValue("@Address", patient.Address);
                    patientCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật lịch hẹn hoặc bệnh nhân: {ex.Message}");
            }
        }
        
    }
}
