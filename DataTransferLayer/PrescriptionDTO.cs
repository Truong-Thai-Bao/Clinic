using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferLayer
{
    public class PrescriptionDTO:CommonProps
    {
        public int PrescriptionID { get; set; } = 0;
        public int DiagnosisId { get; set; } = 0;
        public int MedicineId { get; set; } = 0;
        public string MedicineName { get; set; } = "";
        public int MorningDose { get; set; } = 0;
        public int NoonDose { get; set; } = 0;
        public int AfternoonDose { get; set; } = 0;
        public int PatientId { get; set; } = 0;
        public int Day { get; set; } = 0;
        public DateTime AddedDate { get; set; }
        public PrescriptionDTO() { }

        public PrescriptionDTO(int prescriptionID, int diagnosisId, int morningDose, int noonDose, int afternoon, int patientId, int day)
        {
            this.PrescriptionID = prescriptionID;
            this.DiagnosisId = diagnosisId;
            this.MorningDose = morningDose;
            this.NoonDose = noonDose;
            this.AfternoonDose = afternoon;
            this.Day = day;
            this.PatientId = patientId;
        }   
    }
}
