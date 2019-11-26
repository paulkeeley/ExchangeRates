using ExchangeRates.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ExchangeRates.Data.DataSource
{
    public partial class ExchangeRateDBContext : DbContext
    {
        public ExchangeRateDBContext()
        {

        }

        public ExchangeRateDBContext(DbContextOptions<ExchangeRateDBContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Rates> Rates { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile($"appdatasettings.json", optional: false, reloadOnChange: false)
                    .AddJsonFile($"appdatasettings.{env}.json", optional: false, reloadOnChange: false)
                    .Build();

                string connectionString = configuration.GetConnectionString("ExchangeRateDB");
                if (!string.IsNullOrEmpty(connectionString))
                {
                    optionsBuilder.UseSqlServer(connectionString);
                }
                else
                {
                    throw new Exception("Missing connection string for ExchangeRateDB");
                }
            }
        }
    }
}
