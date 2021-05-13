using System;
using System.Collections.Generic;
using System.Text;

namespace UPB.ProyectoFinal.Data.Exceptions
{
   public class DataWriteException : Exception
    {
        public DataWriteException(string message) : base(message)
        {

        }
    }
}
