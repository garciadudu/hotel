using ConstructoIT.Hotel.Accor.Site.Infraestrutura.Clients.Configuration;
using ConstructoIT.Hotel.Accor.Site.Infraestrutura.Condominio.Services;
using ConstructoIT.Hotel.Accor.Site.Infraestrutura.Familia.Services;
using ConstructoIT.Hotel.Accor.Site.Infraestrutura.Morador.Services;
using ConstructoIT.Hotel.Accor.Site.Infraestrutura.Services.Condominio;
using ConstructoIT.Hotel.Accor.Site.Infraestrutura.Services.Familia;
using ConstructoIT.Hotel.Accor.Site.Infraestrutura.Services.Morador;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Site.Infraestrutura.Services
{
    public static class ConstructoITServiceExtensions
    {
        public static IServiceCollection AddConstructoITServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConstructoITClientConfiguration>(configuration);

            services.AddScoped(serviceProvider =>
            {
                var config = serviceProvider.GetService<IOptionsSnapshot<ConstructoITClientConfiguration>>();
                return new RestClient(config.Value.BaseUrl);
            });

            services.AddTransient<ICondominioService, CondominioService>();
            services.AddTransient<IFamiliaService, FamiliaService>();
            services.AddTransient<IMoradorService, MoradorService>();

            return services;
        }
    }
}
