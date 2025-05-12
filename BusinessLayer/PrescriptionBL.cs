using DataLayer;
using DataTransferLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PrescriptionBL
    {
        private PrescriptionDL PrescriptionDL = new PrescriptionDL();
        public List<PrescriptionDTO> GetPrescriptionsByPatientId(int patientId)
        {
            return PrescriptionDL.GetPrescriptionsByPatientId(patientId);
        }

        public void AddPrescription(PrescriptionDTO prescription)
        {
            try
            {
                PrescriptionDL.AddPrescription(prescription);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm đơn thuốc: {ex.Message}");
            }
        }
    }
}
