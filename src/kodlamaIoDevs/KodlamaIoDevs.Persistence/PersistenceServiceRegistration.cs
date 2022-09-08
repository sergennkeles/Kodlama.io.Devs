using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Persistence.Contexts;
using KodlamaIoDevs.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Persistence
{
    

    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("KodlamaIODevsConnectionString")));
            services.AddScoped<ILanguageRepository, LanguageRepository>();

            return services;
        }
    }
}
