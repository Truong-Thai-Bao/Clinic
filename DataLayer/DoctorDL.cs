using DataTransferLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DoctorDL : DBCommon
    {
        // Lấy danh sách tên bác sĩ
        public List<string> GetDoctorNames()
        {
            List<string> doctorNames = new List<string>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "SELECT DISTINCT DocName FROM Doctor";
                    SqlCommand command = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        doctorNames.Add(reader["DocName"].ToString());
                    }
                }
                return doctorNames;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách bác sĩ: {ex.Message}");
            }
        }
        //Lấy danh sách tất cả bác sĩ
        public List<DoctorDTO> GetAllDoctors()
        {
            List<DoctorDTO> doctors = new List<DoctorDTO>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT DoctorId, DocName, Age, YearOfExperience, Contact, Address FROM Doctor";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    doctors.Add(new DoctorDTO
                    {
                        DoctorId = (int)reader["DoctorId"],
                        DocName = reader["DocName"].ToString(),
                        Age = (int)reader["Age"],
                        YearOfExperience = (int)reader["YearOfExperience"],
                        Contact = reader["Contact"].ToString(),
                        Address = reader["Address"].ToString()
                    });
                }
            }
            return doctors;
        }
        // Lấy danh sách tất cả bác sĩ từ View_Doctor
        public List<DoctorDTO> GetDoctosFromDoctorView()
        {
            List<DoctorDTO> doctors = new List<DoctorDTO>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM View_Doctor";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    doctors.Add(new DoctorDTO
                    {
                        DoctorId = (int)reader["DoctorId"],
                        DocName = reader["DocName"].ToString(),
                        Age = (int)reader["Age"],
                        YearOfExperience = (int)reader["YearOfExperience"],
                        Contact = reader["Contact"].ToString(),
                        Address = reader["Address"].ToString(),
                        LoginUserId = (int)reader["LoginUserId"],
                        UserName = reader["Username"].ToString(),
                        UserPassword = reader["UserPassword"].ToString()
                    });
                }
            }
            return doctors;
        }

        //Lấy thông tin bác sĩ theo ID
        public DoctorDTO GetDoctorById(int doctorId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT DoctorId, DocName FROM Doctor WHERE DoctorId = @DoctorId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DoctorId", doctorId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new DoctorDTO
                    {
                        DoctorId = (int)reader["DoctorId"],
                        DocName = reader["DocName"].ToString()
                    };
                }
                return null;
            }
        }

        //Thêm bác sĩ mới
        public void AddDoctor(DoctorDTO doctor, string username, string password, int userType, int addedBy)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    int userLoginId = 0;
                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    {
                        string userQuery = @"INSERT INTO UserInfo (Username, UserPassword, UserType, AddedDate,
                            AddedBy)
                            VALUES (@Username, @UserPassword, @UserType, @AddedDate, @AdeddBy);
                            SELECT SCOPE_IDENTITY();";
                        using (SqlCommand userCmd = new SqlCommand(userQuery, conn, transaction))
                        {
                            userCmd.Parameters.AddWithValue("@Username", username);
                            userCmd.Parameters.AddWithValue("@UserPassword", password);
                            userCmd.Parameters.AddWithValue("@UserType", userType); // 2 = Doctor
                            userCmd.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                            userCmd.Parameters.AddWithValue("@AdeddBy", addedBy);

                            userLoginId = Convert.ToInt32(userCmd.ExecuteScalar());
                        }
                    }
                    string doctorQuery = @"
                        INSERT INTO Doctor (DocName, Age, YearOfExperience, Contact, Address,
                        AddedDate, AddedBy, LoginUserId)
                        VALUES (@DocName, @Age, @YearOfExperience, @Contact, @Address, 
                        @AddedDate, @AddedBy, @LoginUserId)";
                    using (SqlCommand doctorCmd = new SqlCommand(doctorQuery, conn, transaction))
                    {
                        doctorCmd.Parameters.AddWithValue("@DocName", doctor.DocName);
                        doctorCmd.Parameters.AddWithValue("@Age", doctor.Age);
                        doctorCmd.Parameters.AddWithValue("@YearOfExperience", doctor.YearOfExperience);
                        doctorCmd.Parameters.AddWithValue("@Contact", doctor.Contact);
                        doctorCmd.Parameters.AddWithValue("@Address", doctor.Address);
                        doctorCmd.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                        doctorCmd.Parameters.AddWithValue("@AddedBy", addedBy);
                        doctorCmd.Parameters.AddWithValue("@LoginUserId", userLoginId);

                        doctorCmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception($"Lỗi khi thêm bác sĩ: {ex.Message}");
                }
            }
        }

        //Cập nhật thông tin bác sĩ
        public void UpdateDoctor(DoctorDTO doctor, string username, string password, int updatedBy, bool hasLoginPermission)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    int loginUserId = doctor.LoginUserId;
                    if (hasLoginPermission)
                    {
                        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                        {
                            if (loginUserId > 0)
                            {
                                string userQuery = @"
                                UPDATE UserInfo
                                SET Username = @Username, UserPassword = @UserPassword,
                                    UpdatedDate = @UpdatedDate, UpdatedBy = @UpdatedBy
                                WHERE LoginUserId = @LoginUserId";
                                using (SqlCommand userCmd = new SqlCommand(userQuery, conn, transaction))
                                {
                                    userCmd.Parameters.AddWithValue("@Username", username);
                                    userCmd.Parameters.AddWithValue("@UserPassword", password);
                                    userCmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
                                    userCmd.Parameters.AddWithValue("@UpdatedBy", updatedBy);
                                    userCmd.Parameters.AddWithValue("@LoginUserId", loginUserId);

                                    userCmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                //Thêm mới UserInfor
                                string userQuery = @"
                                INSERT INTO UserInfo (Username, UserPassword, UserType,
                                    AddedDate, AddedBy)
                                VALUES (@Username, @UserPassword, @UserType,
                                    @AddedDate, @AdeddBy);
                                SELECT SCOPE_IDENTITY();";
                                using (SqlCommand userCmd = new SqlCommand(userQuery, conn, transaction))
                                {
                                    userCmd.Parameters.AddWithValue("@Username", username);
                                    userCmd.Parameters.AddWithValue("@UserPassword", password);
                                    userCmd.Parameters.AddWithValue("@UserType", 2); // 2 = Doctor
                                    userCmd.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                                    userCmd.Parameters.AddWithValue("@AdeddBy", updatedBy);

                                    loginUserId = Convert.ToInt32(userCmd.ExecuteScalar());
                                }
                            }
                        }
                    }
                    else if (loginUserId > 0)
                    {
                        //Xóa UserInfor nếu không có quyền đăng nhập
                        string deleteUserQuery = "DELETE FROM UserInfo WHERE LoginUserId = @LoginUserId";
                        using (SqlCommand deleteUserCmd = new SqlCommand(deleteUserQuery, conn, transaction))
                        {
                            deleteUserCmd.Parameters.AddWithValue("@LoginUserId", loginUserId);
                            deleteUserCmd.ExecuteNonQuery();
                        }
                        loginUserId = 0;
                    }
                    // Cập nhật thông tin bác sĩ
                    string doctorQuery = @"
                        UPDATE Doctor
                        SET DocName = @DocName, Age = @Age, YearOfExperience = @YearOfExperience,
                            Contact = @Contact, Address = @Address, UpdatedDate = @UpdatedDate,
                            UpdatedBy = @UpdatedBy, LoginUserId = @LoginUserId
                        WHERE DoctorId = @DoctorId";
                    using (SqlCommand doctorCmd = new SqlCommand(doctorQuery, conn, transaction))
                    {
                        doctorCmd.Parameters.AddWithValue("@DocName", doctor.DocName);
                        doctorCmd.Parameters.AddWithValue("@Age", doctor.Age);
                        doctorCmd.Parameters.AddWithValue("@YearOfExperience", doctor.YearOfExperience);
                        doctorCmd.Parameters.AddWithValue("@Contact", doctor.Contact);
                        doctorCmd.Parameters.AddWithValue("@Address", doctor.Address);
                        doctorCmd.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
                        doctorCmd.Parameters.AddWithValue("@UpdatedBy", updatedBy);
                        doctorCmd.Parameters.AddWithValue("@LoginUserId", loginUserId);
                        doctorCmd.Parameters.AddWithValue("@DoctorId", doctor.DoctorId);

                        doctorCmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception($"Lỗi khi cập nhật bác sĩ: {ex.Message}");
                }
            }
        }

        //Kiểm tra xem bác sĩ có chẩn đoán nào trong bản Diagnosis không
        public bool CheckDiagnosisExists(int doctorId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "SELECT COUNT(*) FROM Diagnosis WHERE DoctorId = @DoctorId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DoctorId", doctorId);
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        return (count > 0); // Trả về true nếu có chẩn đoán nào đó, false nếu không có
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra bác sĩ có chẩn đoán nào không: {ex.Message}");
            }

        }

        //Xóa bác sĩ
        public void DeleteDoctor(int doctorId, int loginUserId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    //Xóa bác sĩ
                    string deleteDoctorQuery = "DELETE FROM Doctor WHERE DoctorId = @DoctorId";
                    using (SqlCommand deleteDoctorCmd = new SqlCommand(deleteDoctorQuery, conn, transaction))
                    {
                        deleteDoctorCmd.Parameters.AddWithValue("@DoctorId", doctorId);
                        deleteDoctorCmd.ExecuteNonQuery();
                    }

                    //Xóa UserInfo nếu có
                    if (loginUserId > 0)
                    {
                        string deleteUserQuery = "DELETE FROM UserLogin WHERE LoginUserId = @LoginUserId";
                        using (SqlCommand deleteUserCmd = new SqlCommand(deleteUserQuery, conn, transaction))
                        {
                            deleteUserCmd.Parameters.AddWithValue("@LoginUserId", loginUserId);
                            deleteUserCmd.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception($"Lỗi khi xóa bác sĩ: {ex.Message}");
                }
            }
        }
    }
}
