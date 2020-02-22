using HealthCare.Models;
using HealthCare.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.Data
{
    public class HealthCareContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<TelegramUser> TelegramUsers { get; set; }

        public HealthCareContext(DbContextOptions<HealthCareContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // My configure functions here:
            ConfigureTU(builder);
        }

        private void ConfigureTU(ModelBuilder builder)
        {
            builder.Entity<TelegramUser>(opt =>
            {
                opt.HasKey(tu => tu.Id);
            });
        }
    }
}
