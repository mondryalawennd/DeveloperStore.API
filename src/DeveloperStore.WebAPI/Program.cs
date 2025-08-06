using Serilog;
using DeveloperStore.Common.Logging;
using DeveloperStore.Common.HealthChecks;
using DeveloperStore.IoC;
using DeveloperStore.ORM;
using Microsoft.EntityFrameworkCore;
using DeveloperStore.Application;
using MediatR;
using DeveloperStore.WebAPI.Middleware;
using DeveloperStore.Common.Validation;

namespace DeveloperStore.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Information("Starting web application");

            string CorsPolicy = "_corsPolicy ";

            var builder = WebApplication.CreateBuilder(args);

            builder.AddDefaultLogging();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.AddBasicHealthChecks();
            builder.Services.AddSwaggerGen();
         

            // DB Context
            builder.Services.AddDbContext<DefaultContext>(options =>
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("DeveloperStore.ORM")
                )
            );

           
            builder.RegisterDependencies();

            builder.Services.AddAutoMapper(new[] { typeof(Program).Assembly, typeof(ApplicationLayer).Assembly });
            builder.Services.AddMediatR(cfg =>  { cfg.RegisterServicesFromAssemblies(typeof(ApplicationLayer).Assembly,typeof(Program).Assembly ); });

            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy, policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            app.UseMiddleware<ValidationExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(CorsPolicy);
            app.UseHttpsRedirection();

            //app.UseAuthentication();
            app.UseAuthorization();
            app.UseBasicHealthChecks();
            app.MapControllers();

            
           app.Run();
           
        }
    }
}