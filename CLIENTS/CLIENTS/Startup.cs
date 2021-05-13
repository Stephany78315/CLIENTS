using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UPB.ProyectoFinal.Data;
using UPB.ProyectoFinal.Logic.Manager;
using UPB.ProyectoFinal.Services;
using UPB.ProyectoFinal.Clients.middlewares;


namespace UPB.ProyectoFinal.Clients
{
    public class Startup
    {
        public Startup(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            Configuration = configuration;
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel
                .Information()
                .WriteTo.File($"{Directory.GetCurrentDirectory()}/Logger.log")
                .CreateLogger();
            Log.Information($"Se encuentra en: {env.EnvironmentName}");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IDbContext, DbContext>();
            services.AddTransient<IClientManager, ClientManager>();
            services.AddTransient<ICClientsService, CClientsService>();
            services.AddSwaggerGen(p =>
                {
                    p.SwaggerDoc("v3", new OpenApiInfo { Title = "Proyecto Final", Version = "v3" });
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    p.IncludeXmlComments(xmlPath);
                }            
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseGlobalExceptionHandler();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(p =>
                {
                    p.SwaggerEndpoint("/swagger/v3/swagger.json", "Proyecto Final");
                }            
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
