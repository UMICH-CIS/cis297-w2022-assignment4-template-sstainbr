using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{
    /// <summary>
    /// Neat and tidy menu operations, to make thing easy for the user to navigate
    /// </summary>
    class MainMenu
    {
        public static string Choice { get; set; }
        public static bool EndProgram { get; set; }
        public static void Menu()
        {
            EndProgram = false;
            while (!EndProgram)
            {
                Console.Clear();
                Console.WriteLine("Select Option:");
                Console.WriteLine("1: Add Patient");
                Console.WriteLine("2: Update Patient");
                Console.WriteLine("3: View All Patients");
                Console.WriteLine("4: View Specific Patient");
                Console.WriteLine("5: View Records Owing Minimum Balance");
                Console.WriteLine("6: End");
                Console.WriteLine();
                Choice = Console.ReadLine();

                switch (Choice)
                {
                    case "1":
                        AddPatient();
                        break;
                    case "2":
                        UpdatePatient();
                        break;
                    case "3":
                        ViewPatients();
                        break;
                    case "4":
                        ViewSpecificPatient();
                        break;
                    case "5":
                        ViewMinBalance();
                        break;
                    case "6":
                        EndProgram = true;
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Add new patient
        /// </summary>
        public static void AddPatient()
        {
            Console.Clear();
            Console.WriteLine("Add Patient\n");
            Console.WriteLine("Enter Patient ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Patient name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter balance owed: ");
            decimal balance = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine();

            try
            {
                Patient patient = new Patient(id, name, balance);
                RecordKeeper.WritePatient(patient);
                Console.WriteLine("Saved! Press any key...");
                Console.ReadKey();
            }
            catch(FormatException)
            {
                Console.WriteLine("Error: incorrect format. Press any key...");
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Update existing patient
        /// </summary>
        public static void UpdatePatient()
        {
            Console.Clear();
            Console.WriteLine("Update Patient\n");
            Console.WriteLine("Enter Patient ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Patient name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter balance owed: ");
            decimal balance = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine();

            try
            {
                Patient patient = new Patient(id, name, balance);
                RecordKeeper.UpdatePatient(patient);
                Console.WriteLine("Saved! Press any key...");
                Console.ReadKey();
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: incorrect format. Press any key...");
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Show all patients
        /// </summary>
        public static void ViewPatients()
        {
            Console.Clear();
            Console.WriteLine("Displaying All Patients\n");
            RecordReader.DisplayPatientData();
        }
        /// <summary>
        /// Show a specific patient
        /// </summary>
        public static void ViewSpecificPatient()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Displaying Specific Patient\n");
                Console.WriteLine("Enter Patient ID: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (id < 0)
                {
                    throw new NegativeValueException("Error: cannot accept negative value");
                }
                RecordReader.DisplayPatient(id);
            }
            catch(NegativeValueException e)
            {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// Given a minimum balance, show all accounts owing at least that much
        /// </summary>
        public static void ViewMinBalance()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Viewing Records Owing Minimum Balance\n");
                Console.WriteLine("Enter minimum balance: ");
                decimal balance = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine();
                
                if(balance < 0)
                {
                    throw new NegativeValueException("Error: cannot accept negative value");
                }
                Accountant.DisplayDebt(balance);
            }
            catch(NegativeValueException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
