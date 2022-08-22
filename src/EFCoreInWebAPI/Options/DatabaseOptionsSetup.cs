using Microsoft.Extensions.Options;

namespace EFCoreInWebAPI.Options
{
    public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
    {
        private readonly IConfiguration _configuration;
        private const String _sectionName = "DataBaseOptions";
        public DatabaseOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(DatabaseOptions options)
        {
            options.ConnectionString = _configuration.GetConnectionString("Database");
            _configuration.GetSection(_sectionName).Bind(options);
        }
    }
}
