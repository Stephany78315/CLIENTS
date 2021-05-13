using System;
using System.Collections.Generic;
using System.Text;

namespace UPB.ProyectoFinal.Data.Exceptions
{
    public class DataReadException : Exception
    {
        public DataReadException(string message) : base(message)
        {

        }
    }
}
