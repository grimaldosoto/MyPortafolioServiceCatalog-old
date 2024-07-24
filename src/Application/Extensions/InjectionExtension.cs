using Application.Interfaces;
using Application.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extensions
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(
                    AppDomain.CurrentDomain.GetAssemblies()
                    .Where(p => !p.IsDynamic)
                    );
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ITechnologyApplication, TechnologyApplication>();
            
            return services;
        }
    }
}
