using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataTransferLayer;

namespace BusinessLayer
{
    public class PatientBL
    {
        private PatientDL patientDL = new PatientDL();
        public static DataTable GetAllPatientIdAndPCode()
        {
            return PatientDL.GettAllPatientIdAndCode();
        }

        public PatientDTO GetPatientInfo(int patientId)
        {
            return patientDL.GetPatientByPatientId(patientId);
        }

        public int AddPatient(PatientDTO patient)
        {
            return patientDL.AddPatient(patient);
        }

        public List<PatientDTO> GetPatientByDoctorId(int doctorId)
        {
            return patientDL.GetPatientByDoctorId(doctorId);
        }
    }
}
