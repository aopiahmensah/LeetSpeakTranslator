using LST.Repository.EF.All;
using LST.Service.Implementations;
using LST.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST.UnitTest.Helpers
{
    public static class DependencyConfig
    {
        private static IConfiguration _configuration;
        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Register dependencies here
            services.AddDbContext<LSTContext>(
            options => options.UseSqlServer(_configuration["LSTContext"]));
            services.AddScoped<ITransactionService, TransactionService>();

            // Other dependencies can be registered here if needed

            return services.BuildServiceProvider();
        }
    }
}
