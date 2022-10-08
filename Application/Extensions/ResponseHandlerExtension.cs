using Application.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Application.Extensions
{
    public static class ResponseHandlerExtension
    {
        public static IApplicationBuilder UseResponseHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseHandler>();
        }
    }
}
