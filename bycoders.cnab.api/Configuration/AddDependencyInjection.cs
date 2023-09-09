using bycoders.cnab.application.UseCases.Contracts;
using bycoders.cnab.application.UseCases.Impl;
using bycoders.cnab.data;
using bycoders.cnab.services;

namespace bycoders.cnab.api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection serviceCollection)
        {            
            serviceCollection.AddScoped<ICNABOperationParser, CNABOperationParser>();
            serviceCollection.AddScoped<IProcessCnabOperations, ProcessCnabOperations>();
            serviceCollection.AddScoped<ICNABOperationListParser, CNABOperationListParser>();

            serviceCollection.AddScoped<ApplicationDbContext>();

            return serviceCollection;
        }
    }
}
