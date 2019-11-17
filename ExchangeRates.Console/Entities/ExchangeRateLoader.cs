using ExchangeRates.Core.Entities;
using ExchangeRates.Services.Implementations;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.ConsoleApp.Entities
{
    public class ExchangeRateLoader
    {
        private readonly IOptions<ApiConfig> _settings;

        public ExchangeRateLoader(IOptions<ApiConfig> settings)
        {
            _settings = settings;
        }

        public async Task RunAsync()
        {
            Console.WriteLine($"Starting exchange rate load");

            try
            {
                var rates = await LoadRates();
                if (rates != null)
                {
                    var result = await WriteRates(rates);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            Console.WriteLine($"Finished exchange rate load");
        }

        private async Task<bool> WriteRates(ExchangeRate rates)
        {
            var exchangeRateService = new ExchangeRateService(_settings);
            return await exchangeRateService.WriteExchangeRates(rates);
        }

        private async Task<ExchangeRate> LoadRates()
        {
            var exchangeRateService = new ExchangeRateService(_settings);
            return await exchangeRateService.GetExchangeRates();
        }
    }
}
