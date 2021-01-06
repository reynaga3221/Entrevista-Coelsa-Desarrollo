using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoelsaEntrevista.Interfaces;
using CoelsaEntrevista.Interfaces.Services;
using CoelsaEntrevista.Interfaces.Repositories;
using CoelsaEntrevista.Setup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CoelsaEntrevista.Services;
using CoelsaEntrevista.Repositories;
using CoelsaEntrevista.WebApi.Setup;

namespace CoelsaEntrevista.WebApi
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

            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
              typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract
          ).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();


            installers.ForEach(i => i.InstallServices(services, Configuration));
          
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

       

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
