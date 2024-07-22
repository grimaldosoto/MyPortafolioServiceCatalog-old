﻿using Infrastructure.Persistences.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            //llamado del context
            var assembly = typeof(MyPortaLiveContext).Assembly.FullName;

            //add service
            services.AddDbContext<MyPortaLiveContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DbConnection"), 
                    b => b.MigrationsAssembly(assembly)),
                    ServiceLifetime.Transient
                );

            return services;
        }
    }
}