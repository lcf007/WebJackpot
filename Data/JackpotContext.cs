using Microsoft.EntityFrameworkCore;


namespace WebJackpot.Data
{
    public class WebJackpotContext : DbContext
    {
        public WebJackpotContext(DbContextOptions<WebJackpotContext> options) : base(options)
        {
        }

        public DbSet<WebJackpot.Models.Jackpot> Jackpot { get; set; }
        public DbSet<WebJackpot.Models.Player> Player { get; set; }
        public DbSet<WebJackpot.Models.TriggeredJackpot> TriggeredJackpot { get; set; }
    }
}
