using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPB.ProyectoFinal.Logic.Model;
using UPB.ProyectoFinal.Logic.Manager;

namespace UPB.ProyectoFinal.Clients.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IClientManager _clientManager;
        public ClientsController(IConfiguration config,IClientManager clientManager)
        {
            _config = config;
            _clientManager = clientManager;
        }

        [HttpGet]
        public List<Client> GetClients()
        {
            return _clientManager.GetAllClients();
        }

        [HttpPost]
        public List<Client> CreateClient(Client client)
        {
            return _clientManager.CreateClient(client);
        }
        [HttpPut]
        public List<Client> UpdateClient(Client client)
        {
            return _clientManager.UpdateClient(client);
        }
        [HttpDelete]
        public List<Client> DeleteClient(Client client)
        {
            return _clientManager.DeleteClient(client);
        }
    }
}
