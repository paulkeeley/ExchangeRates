using ExchangeRates.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRates.Services.Interfaces
{
    public interface IExchangeRateService
    {
        Task<ExchangeRate> GetExchangeRates();

        Task<bool> WriteExchangeRates(ExchangeRate rates);
    }
}
