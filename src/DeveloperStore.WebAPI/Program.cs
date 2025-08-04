using Serilog;
using DeveloperStore.Common.Logging;
using DeveloperStore.Common.HealthChecks;
using DeveloperStore.Common.Security;
using DeveloperStore.IoC;
using DeveloperStore.ORM;
using Microsoft.EntityFrameworkCore;
using DeveloperStore.Application;
using MediatR;
using DeveloperStore.WebAPI.Middleware;
using DeveloperStore.Common.Validation;
using DeveloperStore.Application.Vendas.CriarVenda;
using AutoMapper;


namespace DeveloperStore.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Information("Starting web application");

            var builder = WebApplication.CreateBuilder(args);

            builder.AddDefaultLogging();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.AddBasicHealthChecks();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DefaultContext>(options =>
                    options.UseNpgsql(
                        builder.Configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly("DeveloperStore.ORM")
                    )
                );

            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

            //builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            //builder.Services.AddJwtAuthentication(builder.Configuration);

            builder.RegisterDependencies();

            builder.Services.AddAutoMapper(new[] { typeof(Program).Assembly, typeof(ApplicationLayer).Assembly });

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            var app = builder.Build();

            app.UseMiddleware<ValidationExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseBasicHealthChecks();

            app.MapControllers();

            try
            {
                app.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no startup: " + ex.Message);
                throw;
            }
        }
    }
}