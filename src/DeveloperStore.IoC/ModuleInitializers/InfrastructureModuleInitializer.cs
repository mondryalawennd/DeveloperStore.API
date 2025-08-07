using DeveloperStore.Domain.Events;
using DeveloperStore.Domain.Repositories;
using DeveloperStore.ORM;
using DeveloperStore.ORM.Repositories;
using DeveloperStore.ORM.Repositories.DeveloperStore.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeveloperStore.IoC.ModuleInitializers
{
    public class InfrastructureModuleInitializer : IModuleInitializer
    {
        public void Initialize(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
            builder.Services.AddScoped<IVendaRepository, VendaRepository>();
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IFilialRepository, FilialRepository>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddSingleton<VendaEventosLogger>();
        }
    }
}