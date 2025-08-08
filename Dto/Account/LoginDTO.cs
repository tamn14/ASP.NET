using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net.Dto.Account
{
    public class LoginDTO
    {
        [Required]
        public string Username { set; get; }
        [Required]
        public string Password { set; get; }

    }
}