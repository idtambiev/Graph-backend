using Graph.DataAccess.IOC;
using Graph.Services.Interfaces;
using Graph.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.IOC
{
    public class ServicesContainer
    {
        public static IServiceCollection Configure(IServiceCollection services, IConfiguration configuration)
        {
            RepositoryContainer.Configure(services, configuration);

            services.AddTransient<IAuthService, AuthService>();
            return services;
        }
    }
}
