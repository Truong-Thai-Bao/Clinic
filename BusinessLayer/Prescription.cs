using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Prescription : CommonProps
    {
        public int PrescriptionId { get; set; } = 0;

        public int DiagnosisId { get; set; } = 0;
        public int PatientId { get; set; } = 0;
        public int DoctorId { get; set; } = 0;
        public string MedicineName { get; set; } = "";
        public int MorningDose { get; set; } = 0;
        public int NoonDose { get; set; } = 0;
        public int EveningDose { get; set; } = 0;
        public int NightDose { get; set; } = 0;
        public DateTime AddedDate { get; set; }
    }
}
