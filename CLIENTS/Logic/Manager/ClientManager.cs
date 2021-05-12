using System;
using System.Collections.Generic;
using UPB.ProyectoFinal.Logic.Model;
using UPB.ProyectoFinal.Data;
using UPB.ProyectoFinal.Logic.Exceptions;
using Serilog;


namespace UPB.ProyectoFinal.Logic.Manager
{
    public class ClientManager : IClientManager
    {
        private readonly IDbContext _dbContext;

        public ClientManager(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public List<Client> CreateClient(Client client)
        {
           if (String.IsNullOrEmpty (client.Nombre)) {
                ClientAttrException e = new ClientAttrException("No puede dejar el nombre vacio");
                Log.Error("Se produjo un error"+e.StackTrace+e.Message);
                throw e;
            }
            if (10000000 < client.CI && client.CI < 100000000)
            {
                ClientAttrException e = new ClientAttrException("Carnet de identidad invalido");
                Log.Error("Se produjo un error" + e.StackTrace + e.Message);
                throw e;
            }
            if (0<client.Ranking && client.Ranking<6)
            {
                ClientAttrException e = new ClientAttrException("Ranking es invalido");
                Log.Error("Se produjo un error" + e.StackTrace + e.Message);
                throw e;
            }
            client.Codigo = GenerateCode(client);  
            return DTOMappers.MapClients(_dbContext.CreateClient(DTOMappers.MapClientLD(client)));
        }

        public List<Client> DeleteClient(Client client)
        {
            if (String.IsNullOrEmpty(client.Nombre))
            {
                ClientAttrException e = new ClientAttrException("No puede dejar el nombre vacio");
                Log.Error("Se produjo un error" + e.StackTrace + e.Message);
                throw e;
            }
            if (10000000 < client.CI && client.CI < 100000000)
            {
                ClientAttrException e = new ClientAttrException("Carnet de identidad invalido");
                Log.Error("Se produjo un error" + e.StackTrace + e.Message);
                throw e;
            }
            if (0 < client.Ranking && client.Ranking < 6)
            {
                ClientAttrException e = new ClientAttrException("Ranking es invalido");
                Log.Error("Se produjo un error" + e.StackTrace + e.Message);
                throw e;
            }
            return DTOMappers.MapClients(_dbContext.DeleteClient(DTOMappers.MapClientLD(client)));
        }

        public List<Client> GetAllClients()
        {
            return DTOMappers.MapClients(_dbContext.GetAllClients());
        }

        public List<Client> UpdateClient(Client client)
        {
            if (String.IsNullOrEmpty(client.Nombre))
            {
                ClientAttrException e = new ClientAttrException("No puede dejar el nombre vacio");
                Log.Error("Se produjo un error" + e.StackTrace + e.Message);
                throw e;
            }
            if (10000000 < client.CI && client.CI < 100000000)
            {
                ClientAttrException e = new ClientAttrException("Carnet de identidad invalido");
                Log.Error("Se produjo un error" + e.StackTrace + e.Message);
                throw e;
            }
            if (0 < client.Ranking && client.Ranking < 6)
            {
                ClientAttrException e = new ClientAttrException("Ranking es invalido");
                Log.Error("Se produjo un error" + e.StackTrace + e.Message);
                throw e;
            }
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
