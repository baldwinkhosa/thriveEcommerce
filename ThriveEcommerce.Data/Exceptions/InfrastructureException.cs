using System;
using System.Collections.Generic;
using System.Text;

namespace ThriveEcommerce.Data.Exceptions
{
    public class InfrastructureException : Exception
    {
        internal InfrastructureException(string businessMessage) : base(businessMessage)
        {
        }

        internal InfrastructureException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
