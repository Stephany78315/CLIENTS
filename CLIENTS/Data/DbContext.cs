using System;
using System.Collections.Generic;
using UPB.ProyectoFinal.Data.Model;
using System.IO;
using Newtonsoft.Json;
using Serilog;
using UPB.ProyectoFinal.Data.Exceptions;
using Microsoft.Extensions.Configuration;

namespace UPB.ProyectoFinal.Data
{
    public class DbContext : IDbContext
    {
        public List<Client> ClientTable { get; set; }
        public string ruta;


        public DbContext(IConfiguration config)
        {
            ruta = config.GetSection("Location").GetSection("DirJson").Value;

            ClientTable = new List<Client>()
            { };
            File.WriteAllText(ruta, Newtonsoft.Json.JsonConvert.SerializeObject(ClientTable));



        }

        public List<Client> GetAllClients()
        {
            try
            {
                List<Client> grupos = new List<Client>();
                grupos = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(ruta));

                return grupos;
            }
            catch (Exception e)
            {
                Log.Error("Se produjo un error" + e.StackTrace + e.Message);
                throw new DataReadException("No se pudo leer los datos");
            }
        }
        public List<Client> CreateClient(Client client)
        {
            try
            {
                List<Client> grupos = new List<Client>();
                grupos = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(ruta));
                grupos.Add(client);
                File.WriteAllText(ruta, JsonConvert.SerializeObject(grupos));

                return grupos;
            }
            catch (Exception e)
            {
                Log.Error("Se produjo un error" + e.StackTrace + e.Message);
                throw new DataWriteException("No se pudo crear el cliente por error de escritura");
            }
        }
        public List<Client> UpdateClient(Client clientToUpdate)
        {
            try
            {
                List<Client> grupos = new List<Client>();
                grupos = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(ruta));

                Client foundClient = grupos.Find(client => client.idClient == clientToUpdate.idClient);
                foundClient.Name = clientToUpdate.Name;
                foundClient.DNI = clientToUpdate.DNI;
                foundClient.Address = clientToUpdate.Address;
                foundClient.Phone = clientToUpdate.Phone;
                foundClient.Ranking = clientToUpdate.Ranking;
                foundClient.Client_Code = clientToUpdate.Client_Code;


                File.WriteAllText(ruta, JsonConvert.SerializeObject(grupos));

                return grupos;
            }
            catch (Exception e)
            {
                Log.Error("Se produjo un error" + e.StackTrace + e.Message);
                throw new DataWriteException("No se pudo actualizar los datos de cliente por la escritura");
            }

        }
        public List<Client> DeleteClient(int clientIdToDelete)
        {
            try
            {
                List<Client> grupos = new List<Client>();
                grupos = JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(ruta));

                grupos.RemoveAll(client => client.idClient == clientIdToDelete);

                File.WriteAllText(ruta, JsonConvert.SerializeObject(grupos));

                return grupos;
            } catch (Exception e) {
                Log.Error("Se produjo un error" + e.StackTrace + e.Message);
                throw new DataWriteException("No se pudo borrar los datos");
            }



        }
    }
}

