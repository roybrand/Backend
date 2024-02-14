using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translate.Application.Contracts.Persistence;
using Translate.Persistence.Repositories;

namespace Translate.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices
                        (this IServiceCollection services,IConfiguration configuration) {
            services.AddDbContext<TranslateDataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IDicTranslationRepository, DicTranslationRepository>();

            return services;
        }
    }
}
