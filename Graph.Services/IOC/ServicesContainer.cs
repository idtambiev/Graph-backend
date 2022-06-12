using Graph.DataAccess.IOC;
using Graph.Services.Interfaces;
using Graph.Services.MappingProfiles;
using Graph.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
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


            services.AddTransient<IAuthService, AuthService>()
                    .AddTransient<IGraphService, GraphService>()
                    .AddTransient<IVectorService, VectorService>()
                    .AddTransient<IVertexService, VertexService>()
                    .AddTransient<IEdgeService, EdgeService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
