﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.SignalR;
using System;

namespace SignalR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignalRController : ControllerBase
    {
        private readonly IHubContext<MessageHub> _context;
        public SignalRController(IHubContext<MessageHub> context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("SendMessage")]
        public async Task Index(string message)
        {
            //var connectionManager = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();
            //connectionManager.Clients.All.addmessage("Merhaba");
            //connectionManager.Clients.
            await _context.Clients.All.SendAsync("Name",message);
        }
    }
}