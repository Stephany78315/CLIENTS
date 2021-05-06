using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPB.ProyectoFinal.Logic.Model;

namespace UPB.ProyectoFinal.Clients.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ClientsController> _logger;

        public ClientsController(ILogger<ClientsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return null;
        }
    }
}
