using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{
    class Patient
    {
        public int IDNum { get; set; }
        public string Name { get; set; }
        public decimal BalanceOwed { get; set; }

        public Patient(int idNum, string name, decimal balanceOwed)
        {
            IDNum = idNum;
            Name = name;
            BalanceOwed = balanceOwed;
        }
    }
}
