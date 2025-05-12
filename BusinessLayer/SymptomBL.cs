using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferLayer;
using DataLayer;
namespace BusinessLayer
{
    public  class SymptomBL
    {
        private SymptomDL symptomDL;
        public SymptomBL()
        {
            symptomDL = new SymptomDL();
        }

        public List<Symptom> GetSymptomsByPatientId(int patientId)
        {
            try
            {
                return symptomDL.GetSymptomsByPatientId(patientId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertSymtom(Symptom symptom)
        {
            try
            {
                symptomDL.SaveSymptom(symptom);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
