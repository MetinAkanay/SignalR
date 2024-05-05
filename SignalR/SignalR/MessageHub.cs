using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalR.SignalR
{
    public class MessageHub : Hub
    {
        public async Task SendAsync(string message)
        {
            await Clients.All.SendAsync("Name", message);
        }
    }
}