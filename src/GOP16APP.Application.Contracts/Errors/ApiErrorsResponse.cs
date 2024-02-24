using System;
using System.Collections.Generic;
using System.Text;

namespace GOP16APP.Errors
{
    public class ApiErrorsResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiErrorsResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad request: The request you made is invalid.",
                401 => "Unauthorized: You are not authorized to access this resource.",
                404 => "Not found: The resource you are looking for does not exist.",
                500 => "Internal server error: Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate leads to suffering.",
                _ => null
            };
        }
    }
}
