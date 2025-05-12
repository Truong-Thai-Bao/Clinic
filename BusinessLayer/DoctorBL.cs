using DataLayer;
using DataTransferLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DoctorBL
    {
        private DoctorDL doctorDL = new DoctorDL();

        //Lấy thông tin bác sĩ theo ID
        public DoctorDTO GetDoctorById(int doctorId)
        {
            return doctorDL.GetDoctorById(doctorId);
        }

        //Lấy danh sách tất cả bác sĩ
        public List<DoctorDTO> GetAllDoctors()
        {
            return doctorDL.GetAllDoctors();
        }

        //Lấy danh sách tất cả bác sĩ từ View_Doctor
        public List<DoctorDTO> GetAllDoctorsFromView()
        {
            return doctorDL.GetDoctosFromDoctorView();
        }

        //Lấy danh sách bác sĩ theo tên
        public List<string> GetDoctorNames()
        {
            return doctorDL.GetDoctorNames();
        }

        //Thêm bác sĩ mới
        public void AddDoctor(DoctorDTO doctor, string username, string password, int userType, int addedBy)
        {
            try
            {
                doctorDL.AddDoctor(doctor, username, password, userType, addedBy);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm bác sĩ: " + ex.Message);
            }
        }

        //Cập nhật thông tin bác sĩ
        public void UpdateDoctor(DoctorDTO doctor, string username, string password, int updatedBy, bool hasLoginPermission)
        {
            try
            {
                doctorDL.UpdateDoctor(doctor, username, password, updatedBy, hasLoginPermission);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật bác sĩ: " + ex.Message);
            }
        }

        //Kiểm tra xem bác sĩ có chẩn đoán nào không
        public bool CheckDiagnosisExists(int doctorId)
        {
            try
            {
                return doctorDL.CheckDiagnosisExists(doctorId);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra chẩn đoán: " + ex.Message);
            }

        }

        //Xoá bác sĩ
        public void DeleteDoctor(int doctorId, int updatedBy)
        {
            try
            {
                doctorDL.DeleteDoctor(doctorId, updatedBy);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xoá bác sĩ: " + ex.Message);
            }
        }
    }
}
