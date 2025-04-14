using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shared.ErrorModels
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
        //public string StackTrace { get; set; }
        //public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        //public List<string> Errors { get; set; } = new List<string>();
        //public ErrorDetails(int statusCode, string message)
        //{
        //    StatusCode = statusCode;
        //    Message = message;
        //}
        //public ErrorDetails(int statusCode, string message, string stackTrace)
        //{
        //    StatusCode = statusCode;
        //    Message = message;
        //    StackTrace = stackTrace;
        //}
    }
}
