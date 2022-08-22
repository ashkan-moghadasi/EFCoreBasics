using EFCoreInWebAPI.Models;
using EFCoreInWebAPI.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EFCoreInWebAPI
{
    public static class EfConfigurator
    {
        public static void  EFNormalConfig(this IServiceCollection serviceCollection, String connectionString)
        {
            serviceCollection.AddDbContext<EmployeeContext>((builder) =>
            {
                builder.UseSqlServer(connectionString);
            });
        }
        public static void EFAdvancedConfig(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<EmployeeContext>((provider,builder) =>
            {
                var options = provider.GetService<IOptions<DatabaseOptions>>()!.Value;
                builder.UseSqlServer(options.ConnectionString, optionsBuilder =>
                {
                    optionsBuilder.CommandTimeout(options.CommandTimeOut);
                    optionsBuilder.EnableRetryOnFailure(options.MaxRetryCount);
                });
                builder.EnableDetailedErrors(options.EnableDetailError);
                builder.EnableSensitiveDataLogging(options.EnableSensitiveDataLogging);

            });
        }

    }
}
