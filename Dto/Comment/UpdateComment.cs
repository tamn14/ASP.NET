using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net.Dto.Comment
{
    public class UpdateComment
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public int? StockId { get; set; }
    }
}