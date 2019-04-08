using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebJackpot.Data;
using WebJackpot.Models;
using Newtonsoft.Json.Converters;
using WebJackpot.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace WebJackpot.Hubs
{
    public class MessageHub : Hub
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MessageHub(ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task OnConnectedAsync()
        {
            // Handle Jackpot Logic
            var jackpots = await _context.Jackpots.ToListAsync();
            await Clients.All.SendAsync("ReceiveMessage", "root", JsonConvert.SerializeObject(jackpots, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss tt" }));
        }

        public async Task PlayGame(string message)
        {
            // Find Player In DB.
            var currPlayer = _httpContextAccessor.HttpContext.User.Identity;
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            // or

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
                        UserId = userId,
                        JackpotID = i.JackpotID,
                        CurrentWin = i.TriggerPoints,
                        TriggerTime = DateTime.Now
                    };
                    _context.Add(jpHistory);
                }
            });
            await _context.SaveChangesAsync();

            jackpots = await _context.Jackpots.ToListAsync();
            await Clients.All.SendAsync("ReceiveMessage", currPlayer.Name, JsonConvert.SerializeObject(jackpots));
        }
    }
}