using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRChat.Hubs;
using SignalRChat.Models;

namespace SignalRChat.Controllers
{
    public class MessageController : Controller
    {
        private readonly IHubContext<Messagehub> _messageHub;
        public MessageController(IHubContext<Messagehub> messageHub)
        {
            this._messageHub = messageHub;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Message message)
        {
            await _messageHub.Clients.All.SendAsync("sendToUser", message.Title, message.MessageDescription);
            return View();
        }
    }
}