using System;
using System.Collections.Generic;
using System.Text;
using UPB.ProyectoFinal.Services.Models;

namespace UPB.ProyectoFinal.Logic.Model
{
    public class DTOMappers
    {
        public static List<Client> MapClients(List<Data.Model.Client> clientes)
        {
            List<Client> mappedClients = new List<Client>();

            foreach (Data.Model.Client c in clientes)
            {
                mappedClients.Add(new Client()
                {
                    Nombre = c.Name,
                    CI = c.DNI,
                    Direccion = c.Address,
                    Telefono = c.Phone,
                    Ranking = c.Ranking,
                    Codigo = c.Client_Id
                });
            }
            return mappedClients;
        }

        public static List<Client> MapCClients(List<CClient> cclients)
        {
            List<Client> mappedCClients = new List<Client>();

            foreach (CClient c in cclients)
            {
                mappedCClients.Add(new Client()
                {
                    Nombre = c.login,
                    Avatar = c.avatar_url
                    
                });
            }
            return mappedCClients;
        }
        public static Client MapClientDL(Data.Model.Client client)
        {


            Client nuevo = new Client()
            {
                Nombre = client.Name,
                CI = client.DNI,
                Direccion = client.Address,
                Telefono = client.Phone,
                Ranking = client.Ranking,
                Codigo = client.Client_Id
            };


            return nuevo;
        }
        public static Data.Model.Client MapClientLD(Client c)
        {


            Data.Model.Client nuevo = new Data.Model.Client()
            {
                Name = c.Nombre,
                DNI = c.CI,
                Address = c.Direccion,
                Phone = c.Telefono,
                Ranking = c.Ranking,
                Client_Id = c.Codigo
            };
            return nuevo;
        }

    }
}
