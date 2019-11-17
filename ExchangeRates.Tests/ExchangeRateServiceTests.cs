using ExchangeRates.Core.Entities;
using ExchangeRates.Services.Implementations;
using ExchangeRates.Services.Interfaces;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace ExchangeRates.Tests
{
    public class ExchangeRateServiceTests
    {
        private Mock<IOptions<ApiConfig>> _mockconfig;
        private ApiConfig _apiConfig;
        private IExchangeRateService _exchangeRateService;

        [SetUp]
        public void Setup()
        {
            _mockconfig = new Mock<IOptions<ApiConfig>>();
            _apiConfig = new ApiConfig
            {
                ExchangeRateUrl = "https://api.exchangeratesapi.io/latest"
            };

            _mockconfig.Setup(ap => ap.Value).Returns(_apiConfig);
            _exchangeRateService = new ExchangeRateService(_mockconfig.Object);
        }

        [Test]
        public async Task GetExchangeRatesAsync_Success()
        {
            var result = await _exchangeRateService.GetExchangeRates();

            Assert.IsNotNull(result);
        }
    }
}