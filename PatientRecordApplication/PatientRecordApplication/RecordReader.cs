using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PatientRecordApplication
{
    /// <summary>
    /// The class that reads the information about patients
    /// </summary>
    class RecordReader
    {
        private static FileStream fileStream;
        private static StreamReader reader;
        /// <summary>
        /// Displays all patient data to the console
        /// </summary>
        public static void DisplayPatientData()
        {
            string recordIn;
            string[] fields;

            try
            {
                fileStream = new FileStream("PatientData.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                reader = new StreamReader(fileStream);
                fileStream.Seek(0, SeekOrigin.Begin);

                recordIn = reader.ReadLine();
                while (recordIn != null)
                {
                    fields = recordIn.Split(',');
                    if (fields[0] != "")//Don't get stuck on blank lines
                    {
                        Console.WriteLine("Patient ID: " + fields[0]);
                        Console.WriteLine("Name: " + fields[1]);
                        Console.WriteLine("Balance Owed: " + fields[2]);
                        Console.WriteLine();
                    }
                    recordIn = reader.ReadLine();
                }
            }
            finally
            {
                reader.Close();
                fileStream.Close();
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Display a specific patient's information to the console
        /// </summary>
        /// <param name="id">The <see cref="int"/> holding the ID of the patient to display</param>
        public static void DisplayPatient(int id)
        {
            string recordIn;
            string[] fields;

            try
            {
                fileStream = new FileStream("PatientData.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                reader = new StreamReader(fileStream);
                fileStream.Seek(0, SeekOrigin.Begin);

                recordIn = reader.ReadLine();
                while (recordIn != null)
                {
                    fields = recordIn.Split(',');
                    if (fields[0] == Convert.ToString(id)) //Check to see if the patients match
                    {
                        Console.WriteLine("Patient ID: " + fields[0]);
                        Console.WriteLine("Name: " + fields[1]);
                        Console.WriteLine("Balance Owed: " + fields[2]);
                        Console.WriteLine();
                    }
                    recordIn = reader.ReadLine();
                }
            }
            finally
            {
                reader.Close();
                fileStream.Close();
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                Console.WriteLine();
            }
        }
    }
}
