using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Exceptions
{
    public class ServiceReadException : Exception
    {
        public ServiceReadException(string message) : base(message)
        {

        }
    }
}
