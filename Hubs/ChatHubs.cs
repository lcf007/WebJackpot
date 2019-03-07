using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Timers;

namespace WebJackpot.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

    }
}