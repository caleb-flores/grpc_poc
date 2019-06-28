using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Tegra.Domain;
using Tegra.Infrastructure.Data;

namespace Tegra.Infrastructure.IoC
{
    public static class ServiceCollectionExtension 
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service)
        {
            service.AddScoped<IProductionLineRepository, InMemoryProductionLineRepository>();

            return service;
        }
    }
}
