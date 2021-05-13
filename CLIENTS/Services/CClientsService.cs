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

                client.BaseAddress = new Uri(config.GetConnectionString("DirSer"));
                string name = config.GetSection("ReqHeaders").GetSection("Name").Value;
                string val = config.GetSection("ReqHeaders").GetSection("Value").Value;
                client.DefaultRequestHeaders.Add(name, val);


                var response = await client.GetAsync(config.GetSection("ReqHeaders").GetSection("Route").Value);
                string respBody = await response.Content.ReadAsStringAsync();
                clients = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CClient>>(respBody);

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
