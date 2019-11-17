using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangeRates.Core.Entities;
using ExchangeRates.Services.Implementations;
using ExchangeRates.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ExchangeRates.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRateController : ControllerBase
    {
        private readonly IOptions<ApiConfig> _settings;

        public ExchangeRateController(IOptions<ApiConfig> settings)
        {
            _settings = settings;
        }

        [HttpGet("getrates")]
        public async Task<ActionResult<ExchangeRate>> GetExchangeRates()
        {
            IExchangeRateService exchangeRateService = new ExchangeRateService(_settings);
            var result = await exchangeRateService.GetExchangeRates();

            return Ok(result);
        }
    }
}