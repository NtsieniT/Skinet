using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.API.Errors
{
    // Class is used to define all error response messages with their status codes
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }


        int StatusCode {get; set;}
        public string Message { get; set; }



        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            // Using new switch statement in the return statement (c# 8 )
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, You are not",
                404 => "Resource found, it was not",
                500 => "Errors are the path to the dark side",
                _ => null
            };
        }

    }
}
