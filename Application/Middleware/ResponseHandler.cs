using Application.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using static Domain.Constants.Constants;

namespace Application.Middleware
{
    public class ResponseHandler
    {
        private readonly RequestDelegate next;

        public ResponseHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            int statusCode = 0;
            string message = "";
            var currentBody = context.Response.Body;
            object objResult = null;
            using (var memoryStream = new MemoryStream())
            {
                context.Response.Body = memoryStream;
                await next(context);
                context.Response.Body = currentBody;
                memoryStream.Seek(0, SeekOrigin.Begin);
                string readToEnd = new StreamReader(memoryStream).ReadToEnd();
                if (!readToEnd.Contains("swagger") && (context.Response.StatusCode == (int)HttpStatusCode.OK || context.Response.StatusCode == (int)HttpStatusCode.NoContent))
                {
                    if (readToEnd != "")
                    {
                        objResult = JsonSerializer.Deserialize<object>(readToEnd);
                    }

                    bool statusCodeResult = false;

                    statusCodeResult = Int32.TryParse("" + context.Response.HttpContext.Items["StatusCode"], out statusCode);
                    if (statusCodeResult)
                    {
                        message = "" + context.Items["Message"];
                    }
                    else
                    {
                        statusCode = context.Response.StatusCode;
                    }
                    var result = CommonApiResponse.Create((ProcessResults)statusCode, objResult, message);
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    await context.Response.WriteAsync(JsonSerializer.Serialize(result));
                }
                else
                {
                    await context.Response.WriteAsync(readToEnd);
                }
            }
        }
    }
}
