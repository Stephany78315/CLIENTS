using System;
using System.Collections.Generic;
using UPB.ProyectoFinal.Data.Model;
using System.IO;
using Newtonsoft.Json;

namespace UPB.ProyectoFinal.Data
{
    public class DbContext: IDbContext
    {
        public List<Client> ClientTable { get; set; }
        public string ruta;
        /*
         {
          "nombre": "Juan Carlos Morales Baltazar",
          "ci": 1233455,
          "direccion": "Calle Arivancha Nro 234",
          "telefono": 4132112,
          "ranking": 2,
          "codigo": "string"
          }
        */

        public DbContext()
        {
            ruta = @"C:\UPB\Certificación 1\proyect-clients\CLIENTS\clientes.json";

            ClientTable = new List<Client>()
            { };
            File.WriteAllText(ruta, Newtonsoft.Json.JsonConvert.SerializeObject(ClientTable));



        }

        public List<Client> GetAllClients()
        {
            List<Client> grupos = new List<Client>();
             grupos = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(ruta));

            return grupos;
        }
        public List<Client> CreateClient(Client client)
        {
            List<Client> grupos = new List<Client>();
            grupos = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(ruta));
            grupos.Add(client);
            File.WriteAllText(ruta, JsonConvert.SerializeObject(grupos));

            return grupos;
        }
        public List<Client> UpdateClient(Client clientToUpdate)
        {
            List<Client> grupos = new List<Client>();
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
            List<Client> grupos = new List<Client>();
            grupos = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(ruta));

            grupos.RemoveAll(client => client.Client_Id == clientToDelete.Client_Id);

            Console.WriteLine(clientToDelete.Client_Id);

            File.WriteAllText(ruta, JsonConvert.SerializeObject(grupos));

            return grupos;
        }



    }
}
