using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CoelsaEntrevista.Mappers.DomainContract;

namespace CoelsaEntrevista.WebApi.Setup
{
    public class MapperInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {

            // Esto hace que busque en el assembly donde este ContactProfile a todas las clases que implemente Profile
            // Asi que no hace falta registrar cada Profile por separado
            services.AddAutoMapper(typeof(ContactProfile));
        }
    }
}
