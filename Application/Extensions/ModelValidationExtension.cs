using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text;
using static Domain.Constants.Constants;

namespace Application.Extensions
{
    public static class ModelValidationExtension
    {
        public static IServiceCollection UseCustomModelValidation(this IServiceCollection services)
        {
            _ = services.Configure((Action<ApiBehaviorOptions>)(apiBehaviorOptions =>
                    apiBehaviorOptions.InvalidModelStateResponseFactory = actionContext =>
                    {
                        string message = GetModelStateErrorWithException(actionContext);

                        return new BadRequestObjectResult(CommonApiResponse.Create(ProcessResults.ModelValidationError, null, message));
                    }));
            return services;
        }

        private static string GetModelStateErrorWithException(ActionContext actionContext)
        {
            string errorMessage = "";
            var message = new StringBuilder();
            foreach (var error in actionContext.ModelState)
            {
                if(error.Value.Errors != null && error.Value.Errors.Any())
                {
                    message.Append(error.Key);
                    message.Append(" : ");
                    if (error.Value.Errors[0].Exception != null)
                    {   
                        message.Append(error.Value.Errors[0].Exception.Message);                       
                    }
                    else if(error.Value.Errors[0].ErrorMessage != null)
                    {
                        message.Append(error.Value.Errors[0].ErrorMessage);
                    }
                    else
                    {
                        message.Append(string.Empty);
                    }
                }
                else
                {
                    message.Append(string.Empty);
                }
                message.Append(", ");
            }
            errorMessage = message.ToString();
            return errorMessage;
        }
    }
}
