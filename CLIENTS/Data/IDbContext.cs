using System;
using System.Collections.Generic;
using System.Text;
using UPB.ProyectoFinal.Data.Model;

namespace UPB.ProyectoFinal.Data
{
    public interface IDbContext
    {
        List<Client> GetAllClients();
        List<Client> CreateClient(Client client);
        List<Client> UpdateClient(Client client);
        List<Client> DeleteClient(Client client);
    }
}
