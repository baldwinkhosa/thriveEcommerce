using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThriveEcommerce.BusinessLibrary.Exceptions
{
    public class ApplicationException : Exception
    {
        internal ApplicationException(string businessMessage) : base(businessMessage)
        {
        }

        internal ApplicationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

