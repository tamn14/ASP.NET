using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Net.Models;

namespace ASP.Net.Interface
{
    public interface ITokenService
    {
        string CreateToken(AppUser user); 
    }
}