using CoelsaEntrevista.Interfaces;
using CoelsaEntrevista.Interfaces.Repositories;
using CoelsaEntrevista.Interfaces.Services;
using CoelsaEntrevista.Repositories;
using CoelsaEntrevista.Services;
using CoelsaEntrevista.Setup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoelsaEntrevista.WebApi.Setup
{
    public class DependencyInjectionInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {

            // SERVICES
            services.AddScoped<IContactService, ContactService>();


            // REPOSITORIES
            services.AddScoped<IContactRepository, ContactRepository>();

            // CONNECTIONS
            services.AddSingleton<IConnectionParameters, DbInstaller>();


        }
    }
}
