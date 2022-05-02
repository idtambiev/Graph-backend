using Graph.DataAccess.Interfaces;
using Graph.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.DataAccess.IOC
{
    public class RepositoryContainer
    {
        public static IServiceCollection Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GraphDbContext>(options =>

              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Graph.DataAccess"))
            );

            services.AddScoped<IRepository, Repository>();
            return services;
        }
    }
}
