using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPB.ProyectoFinal.Logic.Model;

namespace UPB.ProyectoFinal.Clients.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly IConfiguration _config;
        public ClientsController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public List<Client> GetClients()
        {
            return null;
        }

        [HttpPost]
        public List<Client> CreateClient()
        {
            return null;
        }
        [HttpPut]
        public List<Client> UpdateClient()
        {
            return null;
        }
        [HttpDelete]
        public List<Client> DeleteClient()
        {
            return null;
        }
    }
}
