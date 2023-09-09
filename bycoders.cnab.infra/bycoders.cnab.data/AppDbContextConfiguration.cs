using bycoders.cnab.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace bycoders.cnab.api.Configuration
{
    public static class DbConfigurationService
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection serviceCollection, ConfigurationManager configManager)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = configManager.GetConnectionString("DefaultConnection"); 
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));                
            });

            return serviceCollection;
        }      
    }      
}
