using System;
using System.Collections.Generic;
using UPB.ProyectoFinal.Data.Model;
using System.IO;
using Newtonsoft.Json;

namespace UPB.ProyectoFinal.Data
{
    public class DbContext: IDbContext
    {
        public string ruta;
        public List<Client> grupos = new List<Client>();

        public DbContext()
        {
            ruta = @"C:\UPB\Certificación 1\proyect-clients\CLIENTS";
        }

        public List<Client> GetAllClients()
        {
            grupos = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(ruta));

            return grupos;
        }
        public List<Client> CreateClient(Client client)
        {
            grupos = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(ruta));
            grupos.Add(client);
            File.WriteAllText(ruta, JsonConvert.SerializeObject(grupos));

            return grupos;
        }
        public List<Client> UpdateClient(Client clientToUpdate)
        {
            grupos = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(ruta));

            Client foundClient = grupos.Find(client => client.Client_Id == clientToUpdate.Client_Id);
            foundClient.Name = clientToUpdate.Name;
            foundClient.DNI = clientToUpdate.DNI;
            foundClient.Address = clientToUpdate.Address;
            foundClient.Phone = clientToUpdate.Phone;
            foundClient.Ranking = clientToUpdate.Ranking;


            File.WriteAllText(ruta, JsonConvert.SerializeObject(grupos));

            return grupos;

        }
        public List<Client> DeleteClient(Client clientToDelete)
        {
            grupos = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(ruta));

            grupos.RemoveAll(client => client.Client_Id == clientToDelete.Client_Id);

            File.WriteAllText(ruta, JsonConvert.SerializeObject(grupos));

            return grupos;
        }



    }
}
