using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PatientRecordApplication
{
    /// <summary>
    /// The class in charge of all things account balance
    /// </summary>
    class Accountant
    {
        private static FileStream fileStream;
        private static StreamReader reader;
        /// <summary>
        /// Given a minimum balance, display all accounts that owe at least that much
        /// </summary>
        /// <param name="balance">The <see cref="decimal"/> minimum balance an account must owe to be displayed</param>
        public static void DisplayDebt(decimal balance)
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
                        if (Decimal.Compare(Convert.ToDecimal(fields[2]), balance) > 0)
                        {
                            Console.WriteLine("Patient ID: " + fields[0]);
                            Console.WriteLine("Name: " + fields[1]);
                            Console.WriteLine("Balance Owed: " + fields[2]);
                            Console.WriteLine();
                        }
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
