using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataTransferLayer;


namespace DataLayer
{
    public class PatientDL:DBCommon
    {
        public static DataTable GettAllPatientIdAndCode()
        {
            using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            {
                conn.Open();
                string query = "SELECT PatientId, PCode FROM Patient";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public PatientDTO GetPatientByPatientId(int patientId)
        {
            using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            {
                string query = "SELECT * FROM View_Patient WHERE PatientId = @PatientId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PatientId", patientId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new PatientDTO
                    {
                        PatientId = (int)reader["PatientId"],
                        PCode = reader["PCode"].ToString(),
                        Name = reader["Name"].ToString(),
                        Address = reader["Address"].ToString(),
                        Contact = reader["Contact"].ToString(),
                        Age = DateTime.Now.Year - Convert.ToDateTime(reader["DateOfBirth"]).Year,
                        Gender = reader["Gender"].ToString(),
                        BloodGroup = reader["BloodGroup"].ToString(),
                        DoctorId = (int)reader["DoctorId"]
                    };
                }
                return null;
            }
        }

        public int AddPatient(PatientDTO patient)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = @"
                INSERT INTO Patient (Name, Contact, DateOfBirth, Gender, BloodGroup, DoctorId, Address, PCode)
                VALUES (@Name, @Contact, @DateOfBirth, @Gender, @BloodGroup, @DoctorId, @Address, @PCode);
                SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", patient.Name);
                    cmd.Parameters.AddWithValue("@Contact", patient.Contact);
                    cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                    cmd.Parameters.AddWithValue("Gender", patient.Gender);
                    cmd.Parameters.AddWithValue("@BloodGroup", patient.BloodGroup);
                    cmd.Parameters.AddWithValue("@DoctorId", patient.DoctorId);
                    cmd.Parameters.AddWithValue("@Address", patient.Address);
                    cmd.Parameters.AddWithValue("@PCode", patient.PCode);
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm bệnh nhân: {ex.Message}\nDoctorId: {patient.DoctorId}");
            }

        }
    }
}
