using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExchangeRates.Data.Models
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Rates> Rates { get; set; }
    }
}
