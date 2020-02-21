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
        public HealthCareContext(DbContextOptions<HealthCareContext> options)
            : base (options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // My configure functions here:
        }
    }
}
