using System;
using System.Collections.Generic;
using System.Text;

namespace GOP16APP.Errors
{
    public class ApiValidationErrorResponse : ApiErrorsResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public ApiValidationErrorResponse() : base(400)
        {

        }
    }
}
