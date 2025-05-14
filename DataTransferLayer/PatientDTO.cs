using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferLayer
{
    public class PatientDTO : CommonProps
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string PCode { get; set; }
        public int DoctorId { get; set; }

        public PatientDTO() { }

        public PatientDTO(int PatientId, string PatientName, string Address, string Contact, DateTime DateOfBirth, int Age, string Gender, string BloodGroup, string PCode, int DoctorId)
        {
            this.PatientId = PatientId;
            this.Name = PatientName;
            this.Address = Address;
            this.Contact = Contact;
            this.DateOfBirth = DateOfBirth;
            this.Age = Age;
            this.Gender = Gender;
            this.BloodGroup = BloodGroup;
            this.PCode = PCode;
            this.DoctorId = DoctorId;

        }
        public PatientDTO(string PatientName, string Address, string Contact, DateTime DateOfBirth, string Gender, string BloodGroup, string PCode, int DoctorId,DateTime addDate,int by)
        {
            this.Name = PatientName;
            this.Address = Address;
            this.Contact = Contact;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.BloodGroup = BloodGroup;
            this.PCode = PCode;
            this.DoctorId = DoctorId;
            this.AddedDate = addDate;
            this.AddedBy = by;
        }
    }
}
