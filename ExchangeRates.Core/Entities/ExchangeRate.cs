using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ExchangeRates.Core.Entities
{
    public class ExchangeRate
    {
        [DataMember(Name="date")]
        public string Date { get; set; }

        [DataMember(Name = "base")]
        public string Base { get; set; }

        [DataMember(Name = "rates")]
        public IDictionary<string, double> Rates { get; set; }
    }

    public class Rate
    {
        public string Region { get; set; }
        public double TheRate { get; set; }
    }
}
