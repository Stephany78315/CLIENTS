using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UPB.ProyectoFinal.Services;
using UPB.ProyectoFinal.Services.Models;
using Serilog;
using Services.Exceptions;

namespace Services
{
    public class CClientsService : ICClientsService
    {
        public async Task<List<CClient>> GetAll(IConfiguration config)
        {
            try
            {
                List<CClient> clients = new List<CClient>();
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(config.GetSection("Location").GetSection("DirSer").Value);
                client.DefaultRequestHeaders.Add("User-Agent", @"Mozilla/5.0 (Windows NT 10; Win64; x64; rv:60.0) Gecko/20100101 Firefox/60.0");


                var response = await client.GetAsync("/users");
                string respBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(respBody);
                clients = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CClient>>(respBody);
                Console.WriteLine(clients);

                return clients;
            }
            catch(Exception e)
            {
                Log.Error("Se produjo un error" + e.StackTrace + e.Message);
                throw new ServiceReadException ("Falla de conexión con el service");
            }
        }

    }
}
