using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCargaDocsFormaliza.Data;
using ApiCargaDocsFormaliza.Data.Configuracion;
using ApiCargaDocsFormaliza.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace ApiCargaDocsFormaliza
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("AppAdministration", new OpenApiInfo()
                {
                    Title = "Api Expedientes",
                    Version = "V1"
                });
            });
            services.AddControllers();
            // MongoDB
            services.Configure<ClientesStoreDatabaseSettings>(
                            Configuration.GetSection(nameof(ClientesStoreDatabaseSettings)));
            services.AddSingleton<IClientesStoreDatabaseSettings>(sp =>
                            sp.GetRequiredService<IOptions<ClientesStoreDatabaseSettings>>().Value);
            services.AddSingleton<ClientesDb>();
           

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                // c.SwaggerEndpoint("AppAdministration/swagger.json", "Api Creacion Docs");
                c.SwaggerEndpoint("AppAdministration/swagger.json", "Api Creacion Expedientes");
            });
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
