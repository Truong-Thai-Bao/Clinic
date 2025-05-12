using DataTransferLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PrescriptionDL : DBCommon
    {
        //Lấy danh sách tất cả đơn thuốc
        public List<PrescriptionDTO> GetPrescriptionsByPatientId(int patientId)
        {
            List<PrescriptionDTO> prescriptions = new List<PrescriptionDTO>();
            using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            {
                string query = @"SELECT * FROM Prescription WHERE PatientId = @PatientId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PatientId", patientId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    prescriptions.Add(new PrescriptionDTO
                    {
                        PrescriptionID = Convert.ToInt32(reader["PrescriptionId"]),
                        PatientId = Convert.ToInt32(reader["PatientId"]),
                        MedicineId = Convert.ToInt32(reader["MedicineId"]),
                        //MedicineName = reader["MedicineName"].ToString(),
                        MorningDose = reader["MorningDose"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MorningDose"]),
                        NoonDose = reader["NoonDose"] == DBNull.Value ? 0 : Convert.ToInt32(reader["NoonDose"]),
                        Afternoon = reader["Afternoon"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Afternoon"]),
                        Day = reader["Day"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Day"]),
                        AddedDate = (DateTime)reader["AddedDate"]
                    });
                }
                conn.Close();
            }
            return prescriptions;
        }

        // Theme đơn thuốc mới
        public void AddPrescription(PrescriptionDTO prescription)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBCommon.connString))
                {
                    string query = @"INSERT INTO Prescription (PatientId, MedicineId, MorningDose, NoonDose, Afternoon, Day, AddedDate) 
                                 VALUES (@PatientId, @MedicineId, @MorningDose, @NoonDose, @Afternoon, @Day, @AddedDate)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PatientId", prescription.PatientId);
                    cmd.Parameters.AddWithValue("@MedicineId", prescription.MedicineId);
                    cmd.Parameters.AddWithValue("@MorningDose", prescription.MorningDose);
                    cmd.Parameters.AddWithValue("@NoonDose", prescription.NoonDose);
                    cmd.Parameters.AddWithValue("@Afternoon", prescription.Afternoon);
                    cmd.Parameters.AddWithValue("@Day", prescription.Day);
                    cmd.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm đơn thuốc: " + ex.Message);
            }
        }
    }
}
