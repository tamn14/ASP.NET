using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

namespace ASP.Net.Models
{
    [Table("Portfolio")]
    public class Portfolio
    {
        public string AppUserId { get; set; }
        public string StockId { get; set; }
        public AppUser AppUser { get; set; }
        public Stock stock { get; set; }
    }
}