using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferLayer
{
    public class MedicineDTO:CommonProps
    {
        public int MedicineId { get; set; } = 0;
        public string MedicineName { get; set; } = "";
        public decimal Price { get; set; } = 0;
        public string Type { get; set; } = "";

        public int DiagnosisId { get; set; } = 0;
        public int PatientId { get; set; } = 0;

        public MedicineDTO() { }

        public MedicineDTO(int medicineId, string medicineName, decimal price, string type, int diagnosisId, int patientId)
        {
            this.MedicineId = medicineId;
            this.MedicineName = medicineName;
            this.Price = price;
            this.Type = type;
            this.DiagnosisId = diagnosisId;
            this.PatientId = patientId;
        }
    }
}
