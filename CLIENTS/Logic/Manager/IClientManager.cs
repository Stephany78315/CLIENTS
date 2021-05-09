using System;
using System.Collections.Generic;
using System.Text;
using UPB.ProyectoFinal.Logic.Model;

namespace UPB.ProyectoFinal.Logic.Manager
{
    public interface IClientManager
    {
        List<Client> GetAllClients();
        List<Client> CreateClient(Client client);
        List<Client> UpdateClient(Client client);
        List<Client> DeleteClient(Client client);
    }
}
