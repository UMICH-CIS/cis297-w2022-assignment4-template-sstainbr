using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PatientRecordApplication
{
    /// <summary>
    /// The class in charge of writing data to the patient records
    /// </summary>
    class RecordKeeper
    {
        private static FileStream fileStream;
        private static StreamWriter writer;
        private static StreamReader reader;
        /// <summary>
        /// Adds a brand new patient to the record
        /// </summary>
        /// <param name="patient">The new <see cref="Patient"/> to add to the record</param>
        public static void WritePatient(Patient patient)
        {
            try
            {
                fileStream = new FileStream("PatientData.txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(fileStream);
                fileStream.Seek(fileStream.Length, SeekOrigin.Begin); //Append to the end
                writer.WriteLine(patient.IDNum + "," + patient.Name + "," + patient.BalanceOwed);
            }
            finally {
                writer.Close();
                fileStream.Close();
            }
        }
        /// <summary>
        /// Updates an existing patient in the record
        /// If they do not exist, add as a new patient
        /// </summary>
        /// <param name="patient">The <see cref="Patient"/> to update in the record</param>
        public static void UpdatePatient(Patient patient)
        {
            string recordIn;
            string[] fields;
            int offset = 0; //Keeps track of location in the file, to properly write over existing data

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
                        fileStream.Seek(offset, SeekOrigin.Begin); //Write over existing patient
                        writer.WriteLine(patient.IDNum + "," + patient.Name + "," + patient.BalanceOwed);
                        return;
                    }
                    recordIn = reader.ReadLine();
                    ++offset;
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
