using DOCUMENTATION.APPLICATION.Validators.TopicValidators;
using DOCUMENTATION.INFRASTRUCTURE.Factory;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace DOCUMENTATION.IOC.Configurations
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterIocDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services
                .AddControllers();

            services
                .AddFluentValidation(fv => fv
                    .RegisterValidatorsFromAssemblyContaining<TopicCreateCommandValidator>());

            services
                .AddDbContext<AppDbContext>(options => options
                    .UseSqlServer(Configuration
                        .GetConnectionString("Connection")));

            services
                .RegisterRepositories();

            services
                .AddMediatRSetup();

            services
                .AddCors(options =>
                {
                    options
                        .AddPolicy("PermitirApiRequest",
                            builder =>
                            builder
                                .WithOrigins("http://localhost:3000")
                                    .AllowAnyHeader()
                                        .AllowAnyMethod()
                    );
                });

            services
                .AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Documentação", Version = "v1" });
            });

            return services;
        }
    }
}