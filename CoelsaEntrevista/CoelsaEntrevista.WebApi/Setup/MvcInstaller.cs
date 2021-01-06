using CoelsaEntrevista.WebApi.Middleware;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoelsaEntrevista.WebApi.Setup
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews(opt =>
            {
                opt.Filters.Add<ExceptionFilter>();
            });
         //   .AddFluentValidation(conf => conf.RegisterValidatorsFromAssemblyContaining<Startup>());
        }
    }
}
