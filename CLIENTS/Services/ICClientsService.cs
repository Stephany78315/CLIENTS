using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UPB.ProyectoFinal.Services.Models;

namespace UPB.ProyectoFinal.Services
{
    public interface ICClientsService
    {
        public Task<List<CClient>> GetAll();
    }
}
