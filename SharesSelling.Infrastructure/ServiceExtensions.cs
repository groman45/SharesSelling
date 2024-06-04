using SharesSelling.Application.Repositories;
using SharesSelling.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SharesSelling.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {           
            services.AddScoped<IStockLotRepository, StockLotInMomeryRepository>();
        }
    }
}
