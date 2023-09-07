﻿using bycoders.cnab.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace bycoders.cnab.api.Configuration
{
    public static class DbConfigurationService
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection serviceCollection, ConfigurationManager configManager)
        {
            serviceCollection.AddDbContext<DbContextMapping>(options =>
            {
                var connectionString = configManager.GetConnectionString("DefaultConnection"); 
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            return serviceCollection;
        }
    }      
}
