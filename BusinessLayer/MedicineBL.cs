using DataLayer;
using DataTransferLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataLayer;
using DataTransferLayer;

namespace BusinessLayer
{
    public class MedicineBL
    {
        private MedicineDL MedicineDL = new MedicineDL();
        public List<MedicineDTO> GetMedicinesByPatientId()
        {
            return MedicineDL.GetAllMedicines();
        }

        public List<MedicineDTO> GetMedicinesByPatientId(int patientId)
        {
            return MedicineDL.GetMedicinesByPatientId(patientId);
        }
    }
}
