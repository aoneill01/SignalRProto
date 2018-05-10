using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRProto.Hubs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRProto
{
    [Route("api/[controller]")]
    public class ProtoController : Controller
    {
        private IHubContext<ProtoHub> _hubContext;

        public ProtoController(IHubContext<ProtoHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet("pauseSession/{id}")]
        public async Task<string> PauseSession(int id)
        {
            await _hubContext.Clients.Group($"testsession/{id}").SendAsync("Paused");

            return $"paused session {id}";
        }

        [HttpGet("pauseTester/{id}")]
        public async Task<string> PauseTester(int id)
        {
            await _hubContext.Clients.Group($"tester/{id}").SendAsync("Paused");

            return $"paused tester {id}";
        }
    }
}
