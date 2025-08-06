using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net.Helpers
{
    public class QueryObject
    {
        public string? Symbol { get; set; } = null;
        public string? CompanyName { get; set; } = null;

        public string? SortBy { get; set; } = null;
        public bool IsDecsending { set; get; } = false;

        public int PageNumber { set; get; } = 1;
        public int PageSize { set; get; } = 20; 
    }
}