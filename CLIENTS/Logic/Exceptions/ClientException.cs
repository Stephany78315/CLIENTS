using System;
using System.Collections.Generic;
using System.Text;

namespace UPB.ProyectoFinal.Logic.Exceptions
{
    public class ClientException : Exception
    {
        public ClientException(string message) : base(message)
        {
        
        }
    }
}
