using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferLayer
{
    public class Symptom : CommonProps
    {
        public int SymptomId { get; set; }

        public string Name { get; set; }

        public int PatientId { get; set; }

        public Symptom(int id,string name,int patientId)
        {
            this.SymptomId = id;
            this.Name = name;
            this.PatientId = patientId;
        }
        
        public Symptom(string name,int patientId,int by,DateTime date)
        {
            this.Name=name;
            this.PatientId = patientId;
            this.AddedBy = by;
            this.AddedDate = date;
        }

        public Symptom() { }    
    }
}
