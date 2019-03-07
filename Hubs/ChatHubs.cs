using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using WebJackpot.Data;
using WebJackpot.Models;

namespace WebJackpot.Hubs
{
    public class ChatHub : Hub
    {
        private readonly WebJackpotContext _context;

        public ChatHub(WebJackpotContext context)
        {
            _context = context;
        }

        public async Task StartGame()
        {
            // Handle Jackpot Logic
            var jackpotContext = await _context.Jackpot.FindAsync(1);
            await Clients.All.SendAsync("ReceiveMessage", "root", jackpotContext.CurrentWin.ToString());
        }

        public async Task PlayGame(string user, string message)
        {
            // Find Player In DB.
            var playerContext = await _context.Player.FirstOrDefaultAsync(m => m.Name == user);
            if (playerContext == null)
            {
                var player = new Player();
                player.Name = user;
                _context.Add(player);
            }

            // Handle Jackpot Logic
            var jackpotContext = await _context.Jackpot.FindAsync(1);
            jackpotContext.CurrentWin += 1;
            await _context.SaveChangesAsync();

            await Clients.All.SendAsync("ReceiveMessage", user, jackpotContext.CurrentWin.ToString());
        }
    }
}