using Microsoft.Extensions.DependencyInjection;
using SharesSelling.Application.Interfaces;
using SharesSelling.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharesSelling.Application;

public static class ServiceExtensions
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddTransient<IStockSaleService, StockSaleService>();
        services.AddAutoMapper(typeof(MappingProfiles));
    }
}
