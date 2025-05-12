using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferLayer
{
    public class Diagnosis : CommonProps
    {
        public int DianosisId { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string DiagnosisName { get; set; }

        public Diagnosis(int diagnosisId, int patientId, int doctorId, string diagnosisName)
        {
            this.DianosisId = diagnosisId;
            this.PatientId = patientId;
            this.DoctorId = doctorId;
            this.DiagnosisName = diagnosisName;
        }
        public Diagnosis() { }
    }
}
