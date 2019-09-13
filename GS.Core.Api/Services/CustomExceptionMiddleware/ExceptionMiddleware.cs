using System;
using System.Net;
using System.Threading.Tasks;
using GS.Core.Api.Models;
using GS.Core.Api.Services.LoggerService;
using Microsoft.AspNetCore.Http;

namespace GS.Core.Api.Services.CustomExceptionMiddleware
{
   
        public class ExceptionMiddleware
        {
            private readonly RequestDelegate _next;
            private readonly ILoggerManager _logger;

            public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
            {
                _logger = logger;
                _next = next;
            }

            public async Task InvokeAsync(HttpContext httpContext)
            {
                try
                {
                    await _next(httpContext);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Something went wrong: {ex}");
                    await HandleExceptionAsync(httpContext, ex);
                }
            }

            private Task HandleExceptionAsync(HttpContext context, Exception exception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Endpoint = $"{context.Request.Scheme}://{context.Request.Host.Value}{context.Request.Path}/{context.Request.QueryString}",
                    Message = $"Internal Server Error from the custom middleware. {exception.Message}"
                }.ToString());
            }
        }
    
}
