using Microsoft.EntityFrameworkCore;
using WebJackpot.Models;

namespace WebJackpot.Data
{
    public class WebJackpotContext : DbContext
    {
        public WebJackpotContext(DbContextOptions<WebJackpotContext> options) : base(options)
        {
        }

        public DbSet<Jackpot> Jackpots { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<TriggeredJackpot> TriggeredJackpots { get; set; }
    }
}
