using System;
using static Domain.Constants.Constants;

namespace Application.Models
{
    public class CommonApiResponse
    {
        public static CommonApiResponse Create(ProcessResults statusCode, object result = null, string message = null)
        {
            return new CommonApiResponse(statusCode, result, message);
        }

        public ProcessResults StatusCode { get; set; }
        public string RequestID { get; }
        public string Message { get; set; }
        public object Data { get; set; }

        protected CommonApiResponse(ProcessResults statusCode, object data = null, string message = null)
        {
            RequestID = Guid.NewGuid().ToString();
            StatusCode = statusCode;
            Data = data;
            Message = message;
        }
    }
}
