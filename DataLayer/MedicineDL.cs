using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferLayer;

namespace DataLayer
{
    public class MedicineDL
    {
        public List<MedicineDTO> GetAllMedicines()
        {
            List<MedicineDTO> medicines = new List<MedicineDTO>();
            using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            {
                string query = "SELECT MedicineId, MedicineName, Price, Type FROM Medicine";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    medicines.Add(new MedicineDTO
                    {
                        MedicineId = Convert.ToInt32(reader["MedicineId"]),
                        MedicineName = reader["MedicineName"].ToString(),
                        Price = (decimal)reader["Price"],
                        Type = reader["Type"].ToString()
                    });
                }
                conn.Close();
            }
            return medicines;
        }

        public List<MedicineDTO> GetMedicinesByPatientId(int patientId)
        {
            List<MedicineDTO> medicines = new List<MedicineDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DBCommon.connString))
                {
                    string query = @"SELECT m.MedicineId, m.MedicineName, m.Price, m.Type FROM Medicine m " +
                                   "INNER JOIN Prescription p ON m.MedicineId = p.MedicineId " +
                                   "WHERE p.PatientId = @PatientId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PatientId", patientId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        medicines.Add(new MedicineDTO
                        {
                            MedicineId = Convert.ToInt32(reader["MedicineId"]),
                            MedicineName = reader["MedicineName"].ToString(),
                            Price = (decimal)reader["Price"],
                            Type = reader["Type"].ToString()
                        });
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                Console.WriteLine("Lỗi khi lấy danh sách thuốc: " + ex.Message);
                return new List<MedicineDTO>();
            }
            return medicines;
        }
    }
}
