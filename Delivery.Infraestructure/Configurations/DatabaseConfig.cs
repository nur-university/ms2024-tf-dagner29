using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Delivery.Infraestructure.Configurations
{
    public static class DatabaseConfig
    {

        public static IServiceCollection AddDatabaseInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }


        //public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var connectionString = configuration.GetConnectionString("DefaultConnection");
        //    services.AddDbContext<ApplicationDbContext>(options =>
        //        options.UseSqlServer(connectionString));

        // }
    }
}
