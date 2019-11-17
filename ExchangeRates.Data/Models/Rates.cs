using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExchangeRates.Data.Models
{
    public class Rates
    {
        [Key]
        public int RatesId { get; set; }

        public string CountryCode { get; set; }

        public double Rate { get; set; }

        public DateTime RateDate { get; set; }
    }
}
