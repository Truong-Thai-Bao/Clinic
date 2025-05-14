using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferLayer
{
    public class Diagnosis : CommonProps
    {
        public int DiagnosisId { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string DiagnosisName { get; set; }
        
        public int appointmentId { get; set; }
        public Diagnosis(int diagnosisId, int patientId, int doctorId, string diagnosisName, int appointmentId)
        {
            this.DiagnosisId = diagnosisId;
            this.PatientId = patientId;
            this.DoctorId = doctorId;
            this.DiagnosisName = diagnosisName;
            this.appointmentId = appointmentId;
        }
        public Diagnosis(string diagnosisName)
        {
            this.DiagnosisName = diagnosisName;
        }
        public Diagnosis() { }
    }
}
