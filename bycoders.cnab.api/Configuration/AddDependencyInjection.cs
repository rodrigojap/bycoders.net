using bycoders.cnab.application.UseCases.Contracts;
using bycoders.cnab.application.UseCases.Impl;
using bycoders.cnab.data;
using bycoders.cnab.data.Repository;
using bycoders.cnab.domain.Interfaces;
using bycoders.cnab.services;

namespace bycoders.cnab.api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection serviceCollection)
        {            
            serviceCollection.AddScoped<ICNABOperationParser, CNABOperationParser>();
            serviceCollection.AddScoped<IProcessCnabOperations, ProcessCnabOperations>();
            serviceCollection.AddScoped<IGetSummaryOperationsByStore, GetSummaryOperationsByStore>();            
            serviceCollection.AddScoped<ICNABOperationListParser, CNABOperationListParser>();
            serviceCollection.AddScoped<IFormFileValidator, FormFileValidator>();            

            serviceCollection.AddScoped<ApplicationDbContext>();

            serviceCollection.AddScoped<ICNABOperationsRepository, CNABOperationsRepository>(); 

            return serviceCollection;
        }
    }
}
