using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferLayer;
namespace DataLayer
{
    public class DiagnosisDL : DBCommon
    {
        public int SaveDiagnosisDL(Diagnosis diagnosis)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                try
                {
                    // Lưu thông tin Diagnosis
                    string query = @"INSERT INTO Diagnosis (PatientId, DoctorId, AddedDate, AddedBy,Diagnosis)
                            OUTPUT INSERTED.DiagnosisId
                             VALUES (@PatientId, @DoctorId, @AddedDate, @AddedBy,@Diagnosis)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PatientId", diagnosis.PatientId);
                    cmd.Parameters.AddWithValue("@DoctorId", diagnosis.DoctorId);
                    cmd.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@AddedBy", diagnosis.AddedBy);

                    //// Tạo chuỗi chẩn đoán từ ListView triệu chứng
                    //string diagnosises = "";
                    //foreach (ListViewItem item in lsvDiagnosis.Items)
                    //{
                    //    diagnosises += item.SubItems[1].Text + ", ";
                    //}
                    //diagnosises = diagnosises.TrimEnd(',', ' ');
                    cmd.Parameters.AddWithValue("@Diagnosis", diagnosis.DiagnosisName);
                    return (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public string GetDiagnosisByPatientId(int patientId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"SELECT Diagnosis FROM Diagnosis WHERE PatientId = @PatientId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PatientId", patientId);
                conn.Open();
                return (string)cmd.ExecuteScalar();
            }
        }
    }
}
