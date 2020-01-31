using System.IO;
using ExpressionTreesAndRuleEngine.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpressionTreesAndRuleEngine.Infrastructure
{
    public class ServiceProviderGenerator
    {
        public ServiceProvider SetupServiceProvider()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",
                    optional: true,
                    reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton(configuration);
            services.AddTransient<IDataAccess, SqliteDataAccess>();
            services.Configure<AppSettings>(x =>
                x.ConnectionString = configuration.GetConnectionString("source"));
            return services.BuildServiceProvider();
        }
    }
}