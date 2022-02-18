using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{
    /// <summary>
    /// Exception for when the user enters a negative value when it should not be permitted
    /// </summary>
    class NegativeValueException : Exception
    {
        public NegativeValueException(String message) : base(message)
        {
        }
    }
}
