using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Newtonsoft.Json;
using WebJackpot.Data;
using WebJackpot.Models;
using Newtonsoft.Json.Converters;

namespace WebJackpot.Hubs
{
    public class MessageHub : Hub
    {
        private readonly WebJackpotContext _context;

        public MessageHub(WebJackpotContext context)
        {
            _context = context;
        }

        public override async Task OnConnectedAsync()
        {
            // Handle Jackpot Logic
            var jackpots = await _context.Jackpots.ToListAsync();
            await Clients.All.SendAsync("ReceiveMessage", "root", JsonConvert.SerializeObject(jackpots, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss tt" }));
        }

        public async Task PlayGame(string user, string message)
        {
            // Find Player In DB.
            var currPlayer = await _context.Players.FirstOrDefaultAsync(m => m.Name == user)
                ;
            if (currPlayer == null)
            {
                var player = new Player();
                player.Name = user;
                _context.Add(player);
            }

            // Handle Jackpot Logic
            var jackpots = await _context.Jackpots
                .ToListAsync();
            jackpots?.ForEach(i=>
            {
                i.CurrentWin += 1;
                i.CurrentTime = DateTime.Now;
                if (i.CurrentWin >= i.TriggerPoints)
                {
                    i.CurrentWin -= i.TriggerPoints;
                    var jpHistory = new TriggeredJackpot()
                    {
                        PlayerID = currPlayer.PlayerID,
                        JackpotID = i.JackpotID,
                        CurrentWin = i.TriggerPoints,
                        TriggerTime = DateTime.Now
                    };
                    _context.Add(jpHistory);
                }
            });
            await _context.SaveChangesAsync();

            jackpots = await _context.Jackpots.ToListAsync();
            await Clients.All.SendAsync("ReceiveMessage", user, JsonConvert.SerializeObject(jackpots));
        }
    }
}