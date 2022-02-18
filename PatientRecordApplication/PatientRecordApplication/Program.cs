using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Patient patient = new Patient(4, "Test", 44);
            RecordKeeper.WritePatient(patient);
            patient.BalanceOwed = 5;
            RecordKeeper.UpdatePatient(patient);
        }
    }
}
