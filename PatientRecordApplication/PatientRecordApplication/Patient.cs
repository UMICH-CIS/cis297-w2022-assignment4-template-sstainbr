using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{
    /// <summary>
    /// Class to hold the patient information
    /// </summary>
    class Patient
    {
        public int IDNum { get; set; } //Patient ID Number
        public string Name { get; set; } //Patient Name
        public decimal BalanceOwed { get; set; } //Balance the patient owes
        /// <summary>
        /// Constructor for patients
        /// </summary>
        /// <param name="idNum">The <see cref="int"/> that represents the patient ID number</param>
        /// <param name="name">The <see cref="string"/> that holds the patient's name</param>
        /// <param name="balanceOwed">The <see cref="decimal"/> amount owed</param>
        public Patient(int idNum, string name, decimal balanceOwed)
        {
            IDNum = idNum;
            Name = name;
            BalanceOwed = balanceOwed;
        }
    }
}
