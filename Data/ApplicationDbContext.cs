using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using WebJackpot.Areas.Identity.Data;
using WebJackpot.Models;

namespace WebJackpot.Data
{
    public class ApplicationDbContext : IdentityDbContext<WebJackpotUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Jackpot> Jackpots { get; set; }
        public DbSet<TriggeredJackpot> TriggeredJackpots { get; set; }

    }
}
