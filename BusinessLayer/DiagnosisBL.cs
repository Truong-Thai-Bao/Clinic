using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataTransferLayer;
namespace BusinessLayer
{
    public class DiagnosisBL
    {
        private DiagnosisDL diagnosisDL;
        public DiagnosisBL()
        {
            diagnosisDL = new DiagnosisDL();
        }

        public int SaveDiagnosisBL(Diagnosis diagnosis)
        {
            try
            {
                return diagnosisDL.SaveDiagnosisDL(diagnosis);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetDiagnosisByPatientId(int patientId)
        {
            try
            {
                return diagnosisDL.GetDiagnosisByPatientId(patientId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
