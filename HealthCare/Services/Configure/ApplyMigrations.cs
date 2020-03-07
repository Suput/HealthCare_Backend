using HealthCare.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Configure.Models.Configure.Interfaces;

namespace HealthCare.Services.Configure
{
    public class ApplyMigrations : IConfigureWork
    {
        private readonly HealthCareContext context;
        private readonly ILogger<ApplyMigrations> logger;
        private int tryCount = 10;
        private TimeSpan tryPeriod = TimeSpan.FromSeconds(5);

        public ApplyMigrations(HealthCareContext context, ILogger<ApplyMigrations> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task Configure()
        {
            try
            {
                var pending = await context.Database.GetPendingMigrationsAsync();
                if (pending?.Count() != 0)
                    await context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                if (tryCount == 0)
                    throw;

                logger.LogWarning(ex, "Error while apply migrations");
                tryCount--;
                await Task.Delay(tryPeriod);
                await Configure();
            }
        }
    }
}
