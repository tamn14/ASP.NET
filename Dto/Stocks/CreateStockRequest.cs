using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net.Dto.Stocks
{
    public class CreateStockRequest
    {
        [Required]
        [MaxLength(10 , ErrorMessage = "Symbol cannot be over 10 characters ")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(10 , ErrorMessage = "Symbol cannot be over 10 characters ")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1,100000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.0001,100)]
        public decimal LastDiv { get; set; }
        [Required] 
        [MaxLength(10, ErrorMessage ="Industry can be over 10 characters ")]
        public string Industry { get; set; } = string.Empty;
        [Range(1, 500000000000 )]
        public long MarketCap { get; set; }
    }
}