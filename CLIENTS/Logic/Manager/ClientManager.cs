using System;
using System.Collections.Generic;
using UPB.ProyectoFinal.Logic.Model;
using UPB.ProyectoFinal.Data;
using UPB.ProyectoFinal.Services;
using UPB.ProyectoFinal.Services.Models;

namespace UPB.ProyectoFinal.Logic.Manager
{
    public class ClientManager : IClientManager
    {
        private readonly IDbContext _dbContext;
        private readonly IClientService _clientService;

        public ClientManager(IDbContext dbContext, IClientService clientService)
        {
            _dbContext = dbContext;
            _clientService = clientService;
        }

     

        public List<Client> CreateClient(Client client)
        {
            client.Codigo = GenerateCode(client);
             
            return DTOMappers.MapClients(_dbContext.CreateClient(DTOMappers.MapClientLD(client)));
        }

        public List<Client> DeleteClient(Client client)
        {
            return DTOMappers.MapClients(_dbContext.DeleteClient(DTOMappers.MapClientLD(client)));
        }

        public List<Client> GetAllClients()
        {
            return DTOMappers.MapClients(_dbContext.GetAllClients());
        }

        public List<Client> UpdateClient(Client client)
        {
            return DTOMappers.MapClients(_dbContext.UpdateClient(DTOMappers.MapClientLD(client)));
        }

        private string GenerateCode(Client client)
        {
            string code = "";
            string[] names = client.Nombre.Split(' ');

            code += names[0][0];
            int len = names.Length;
            if (len > 2)
            {
                code += names[len - 2][0];
                code += names[len - 1][0];
            }
            else
            {
                code += names[len - 1][0];
                code += '_';
            }
            code += $"-{client.CI}";
            return code;
        }
    }
}
