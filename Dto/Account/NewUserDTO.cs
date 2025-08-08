using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace ASP.Net.Dto.Account
{
    public class NewUserDTO
    {
        public string UserName { get; set; }
        public string Email { set; get; }
        public string Token { get; set;  }
    }
}