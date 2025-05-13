using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferLayer
{
    public class AppointmentDTO
    {
        public int AppointmentID { get; set; }
        public int PatientId { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string Status { get; set; }
        public string Symptoms { get; set; }
        public bool IsArrived { get; set; }

        public PatientDTO patient { get; set; }

        public AppointmentDTO(int appointmentID, int patientId, string doctorName, DateTime appointmentDate, TimeSpan appointmentTime, string status, string symptoms, bool isArrived)
        {
            AppointmentID = appointmentID;
            PatientId = patientId;
            DoctorName = doctorName;
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;
            Status = status;
            Symptoms = symptoms;
            IsArrived = isArrived;
        }

        public AppointmentDTO() { }
    }
}
