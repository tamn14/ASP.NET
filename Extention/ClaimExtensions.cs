using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.Net.Extention
{
    public static class ClaimExtensions
    {
        public static string getUserName(this ClaimsPrincipal user)
        {
            return user.Claims.SingleOrDefault(s => s.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")).Value; 
        }
    }
}