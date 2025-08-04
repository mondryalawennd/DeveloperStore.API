using DeveloperStore.Common.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DeveloperStore.IoC.ModuleInitializers
{
    public class ApplicationModuleInitializer : IModuleInitializer
    {
        public void Initialize(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
        }
    }
}