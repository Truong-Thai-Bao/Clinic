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
    public class AppointmentDL : DBCommon
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
                        }
                        return filteredDt;
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lọc lịch hẹn: {ex.Message}");
            }
        }

        public DataTable FilterAppointmentByKeyword(string keyword)
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

                    SqlCommand cmd = new SqlCommand(query, conn);
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
                        }
                        return filteredDt;
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lọc lịch hẹn: {ex.Message}");
            }
        }

        public int AddAppointment(AppointmentDTO appointment)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"
                    INSERT INTO Appointment
                    (PatientId, DoctorName, AppointmentDate, AppointmentTime, Symptoms, Status, IsArrived)
                    OUTPUT INSERTED.AppointmentID
                    VALUES
                    (@PatientId, @DoctorName, @AppointmentDate, @AppointmentTime, @Symptoms, @Status, @IsArrived)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                    cmd.Parameters.AddWithValue("@DoctorName", appointment.DoctorName);
                    cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    cmd.Parameters.AddWithValue("@AppointmentTime", appointment.AppointmentTime);
                    cmd.Parameters.AddWithValue("@Symptoms", appointment.Symptoms ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", appointment.Status ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsArrived", appointment.IsArrived);
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void DeleteAppointment(int appointmentID)
        {
            if (appointmentID <= 0)
            {
                throw new ArgumentException("AppointmentID không hợp lệ");
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    int patientId;
                    // Lấy PatientId từ Appointment
                    string selectQuery = "SELECT PatientId FROM Appointment WHERE AppointmentID = @AppointmentID";
                    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conn, transaction))
                    {
                        selectCmd.Parameters.AddWithValue("@AppointmentID", appointmentID);
                        object result = selectCmd.ExecuteScalar();
                        if (result == null)
                        {
                            throw new Exception($"Không tìm thấy lịch hẹn với AppointmentID = {appointmentID}");
                        }
                        patientId = Convert.ToInt32(result);
                    }

                    // Xóa Symptom
                    string symptomQuery = "DELETE FROM Symptom WHERE PatientId = @PatientId";
                    using (SqlCommand symptomCmd = new SqlCommand(symptomQuery, conn, transaction))
                    {
                        symptomCmd.Parameters.AddWithValue("@PatientId", patientId);
                        symptomCmd.ExecuteNonQuery();
                    }

                    // Xóa Appointment
                    string appointmentQuery = "DELETE FROM Appointment WHERE AppointmentID = @AppointmentID";
                    using (SqlCommand appointmentCmd = new SqlCommand(appointmentQuery, conn, transaction))
                    {
                        appointmentCmd.Parameters.AddWithValue("@AppointmentID", appointmentID);
                        int rowsAffected = appointmentCmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            throw new Exception($"Không thể xóa lịch hẹn với AppointmentID = {appointmentID}");
                        }
                    }

                    // Xóa Patient
                    string patientQuery = "DELETE FROM Patient WHERE PatientId = @PatientId";
                    using (SqlCommand patientCmd = new SqlCommand(patientQuery, conn, transaction))
                    {
                        patientCmd.Parameters.AddWithValue("@PatientId", patientId);
                        int rowsAffected = patientCmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            throw new Exception($"Không thể xóa bệnh nhân với PatientId = {patientId}");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception($"Lỗi khi xóa lịch hẹn và thông tin liên quan: {ex.Message}");
                }
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
