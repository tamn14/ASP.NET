using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net.Models
{
    [Table("Comments")]
    public class Comment
    {
        public string Id { set; get; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string? StockId { get; set; }
        //navigate , FE can join it and get data of Stock
        // FE no create FK with it . FE will connect navigation to StockId
        public Stock? Stock { get; set; }
    }
}