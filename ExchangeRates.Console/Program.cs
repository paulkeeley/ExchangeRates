using ExchangeRates.ConsoleApp.Entities;
using ExchangeRates.Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ExchangeRates.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder builder = ConfigureBuilder();
            var configuration = builder.Build();

            var services = ConfigureServices(configuration);
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<ExchangeRateLoader>().RunAsync().GetAwaiter().GetResult();
        }

        private static IServiceCollection ConfigureServices(IConfigurationRoot configuration)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddOptions<ApiConfig>()
                .Bind(configuration.GetSection(nameof(ApiConfig)));
            services.AddTransient<ExchangeRateLoader>();

            return services;
        }

        private static IConfigurationBuilder ConfigureBuilder()
        {
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            return new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{env}.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables();
        }
    }
}
