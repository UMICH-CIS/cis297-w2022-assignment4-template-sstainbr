using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PatientRecordApplication
{
    class RecordKeeper
    {
        private static FileStream fileStream;
        private static StreamWriter writer;
        private static StreamReader reader;
        public static void WritePatient(Patient patient)
        {
            try
            {
                fileStream = new FileStream("PatientData.txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(fileStream);
                fileStream.Seek(fileStream.Length, SeekOrigin.Begin);
                writer.WriteLine(patient.IDNum + "," + patient.Name + "," + patient.BalanceOwed);
            }
            finally {
                writer.Close();
                fileStream.Close();
            }
        }
        public static void UpdatePatient(Patient patient)
        {
            string recordIn;
            string[] fields;

            try {
                fileStream = new FileStream("PatientData.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                writer = new StreamWriter(fileStream);
                reader = new StreamReader(fileStream);
                fileStream.Seek(0, SeekOrigin.Begin);

                recordIn = reader.ReadLine();
                while (recordIn != null)
                {
                    fields = recordIn.Split(',');
                    if (Convert.ToInt32(fields[0]) == patient.IDNum)
                    {
                        writer.WriteLine("TESTESTTESTESTEST");
                        //writer.WriteLine(patient.IDNum + "," + patient.Name + "," + patient.BalanceOwed);
                        return;
                    }
                    recordIn = reader.ReadLine();
                }
                //Only reached if the patient is new
                WritePatient(patient);
            }
            finally
            {
                writer.Close();
                reader.Close();
                fileStream.Close();
            }
        }
    }
}
