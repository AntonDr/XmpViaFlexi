using System;
using System.Collections.Generic;
using System.Text;

namespace VacationsTracker.Core.Domain.Exceptions
{
    internal class InternetConnectionException : Exception
    {
        public InternetConnectionException(string message): base(message)
        {
            
        }
    }
}
