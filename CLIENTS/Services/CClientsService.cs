using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UPB.ProyectoFinal.Services.Models;


namespace Services
{
    public class CClientsService : ICClientsService
    {
        public async Task<List<CClient>> GetAll()
        {
            List<CClient> clients = new List<CClient>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.github.com");
            
            var response = await client.GetAsync("/users");
            string respBody = await response.Content.ReadAsStringAsync();
            
            clients = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CClient>>(respBody);

            return clients;
        }

    }
}
