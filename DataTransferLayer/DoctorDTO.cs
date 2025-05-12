using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferLayer
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }
        public string DocName { get; set; }
        public int Age { get; set; }
        public int YearOfExperience { get; set; }
        public string Contact { get; set; }
        public int LoginUserId { get; set; }
        //public int ConsulationFee { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public DoctorDTO() { }

        public DoctorDTO(int doctorId, string docName, int age, int yearOfExperience, string contact, int loginUserId, int consulationFee, string address, string userName, string userPassword)
        {
            DoctorId = doctorId;
            DocName = docName;
            Age = Age;
            YearOfExperience = yearOfExperience;
            Contact = contact;
            LoginUserId = loginUserId;
            //ConsulationFee = consulationFee;
            Address = address;
            UserName = userName;
            UserPassword = userPassword;
        }
    }
}
