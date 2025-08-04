using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace ASP.Net.Dto.Stocks
{
    public class ApiResponse<T>
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public ApiResponse() { }

        public ApiResponse(int code, string message, T data)
        {
            Code = code;
            Message = message;
            Data = data;
        }

        public ApiResponse(int code, string message)
        {
            Code = code;
            Message = message;
        }


    }
}