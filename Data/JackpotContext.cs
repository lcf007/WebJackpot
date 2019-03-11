using Microsoft.EntityFrameworkCore;
using WebJackpot.Models;

namespace WebJackpot.Data
{
    public class WebJackpotContext : DbContext
    {
        public WebJackpotContext(DbContextOptions<WebJackpotContext> options) : base(options)
        {
        }

        public DbSet<Jackpot> Jackpot { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<TriggeredJackpot> TriggeredJackpot { get; set; }
        public DbSet<WebJackpot.Models.TriggerCondition> TriggerCondition { get; set; }
    }
}
