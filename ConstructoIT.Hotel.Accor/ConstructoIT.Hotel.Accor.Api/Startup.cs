using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructoIT.Hotel.Accor.Aplicacao.Interfaces;
using ConstructoIT.Hotel.Accor.Aplicacao.Service;
using ConstructoIT.Hotel.Accor.Domain.Core.Interface.Repository;
using ConstructoIT.Hotel.Accor.Domain.Core.Interface.Service;
using ConstructoIT.Hotel.Accor.Dominio.Context;
using ConstructoIT.Hotel.Accor.Infraestrutura.Repository.Repositorio;
using ConstructoIT.Hotel.Accor.Servicos.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConstructoIT.Hotel.Accor.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var conexao = Configuration["SqlConnection:ConnectionString"];
            services.AddDbContext<ConstructoItDbContext>(options => options.UseSqlServer(conexao, options =>
           options.MigrationsAssembly(typeof(ConstructoIT.Hotel.Accor.Infraestrutura.Repository.Repositorio.RepositorioGenerico<>).Assembly.FullName)).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddScoped<IApplicationServiceCondominio, ApplicationServiceCondominio>();
            services.AddScoped<IApplicationServiceFamilia, ApplicationServiceFamilia>();
            services.AddScoped<IApplicationServiceMorador, ApplicationServiceMorador>();

            services.AddScoped<IServiceCondominio, ServiceCondominio>();
            services.AddScoped<IServiceFamilia, ServiceFamilia>();
            services.AddScoped<IServiceMorador, ServiceMorador>();

            services.AddScoped<IRepositoryCondominio, RepositoryCondominio>();
            services.AddScoped<IRepositoryFamilia, RepositoryFamilia>();
            services.AddScoped<IRepositoryMorador, RepositoryMorador>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
