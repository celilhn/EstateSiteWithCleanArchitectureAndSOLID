using System;
using System.Net;

namespace Application.Models
{
    public class LogDetail
    {
        public string Endpoint { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
