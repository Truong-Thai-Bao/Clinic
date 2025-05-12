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
    public class SymptomDL :DBCommon
    {
        public List<Symptom> GetSymptomsByPatientId(int id)
        {
			try
			{
                using (SqlConnection conn = new SqlConnection(DBCommon.connString))
                {
                    conn.Open();
                    string query = @"SELECT Name FROM Symptom WHERE PatientId = @PatientId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PatientId", id);
                    List<Symptom> symptoms = new List<Symptom>();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        symptoms.Add(new Symptom()
                        {
                            Name = reader["Name"].ToString(),
                        });
                    }
                    return symptoms;
                }
            }
            catch (Exception ex)
			{

				throw ex;
			}
        }

        public void SaveSymptom(Symptom symptom)
        {
            string query = "Insert into Symptom(Name,PatientId,AddedDate,AddedBy) values(@Name,@PatientId,@AddedDate,@AddedBy)";
            try
            {
                using (SqlConnection conn = new SqlConnection(DBCommon.connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", symptom.Name);
                    cmd.Parameters.AddWithValue("@PatientId", symptom.PatientId);
                    cmd.Parameters.AddWithValue("@AddedDate", symptom.AddedDate);
                    cmd.Parameters.AddWithValue("@AddedBy", symptom.AddedBy);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
