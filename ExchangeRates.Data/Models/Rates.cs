using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExchangeRates.Data.Models
{
    public class Rates
    {
        [Key]
        public int RatesId { get; set; }

        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }

        public double Rate { get; set; }

        public DateTime RateDate { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
