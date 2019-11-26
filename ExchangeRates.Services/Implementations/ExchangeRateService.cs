using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ExchangeRates.Core.Entities;
using ExchangeRates.Core.Extensions;
using ExchangeRates.Data.DataSource;
using ExchangeRates.Data.Models;
using ExchangeRates.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ExchangeRates.Services.Implementations
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly ApiConfig _settings;
        public ExchangeRateService(IOptions<ApiConfig> settings)
        {
            _settings = settings.Value;
        }

        public async Task<ExchangeRate> GetExchangeRates()
        {
            var json = await GetStringAsync(_settings.ExchangeRateUrl);
            return JsonConvert.DeserializeObject<ExchangeRate>(json);
        }

        private async Task<string> GetStringAsync(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    return await client.GetStringAsync(url);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public async Task<bool> WriteExchangeRates(ExchangeRate rate)
        {
            try
            {
                using (var db = new ExchangeRateDBContext())
                {
                    foreach (var item in rate.Rates)
                    {
                        if (item.IsValid())
                        {
                            var currency = await GetOrAddCountry(item.Key, db);
                            db.Rates.Add(new Rates
                            {
                                Currency = currency,
                                Rate = item.Value,
                                RateDate = DateTime.Parse(rate.Date)
                            });
                        }
                    }

                    await db.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<Currency> GetOrAddCountry(string code, ExchangeRateDBContext db)
        {
            var country = await db.Currency.FirstOrDefaultAsync(x => x.Code == code);
            if (country.IsNotNull())
            {
                return country;
            }

            return new Currency { Code = code, Name = "Unknown currency" };
        }
    }
}
