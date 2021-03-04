using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace OpenPath.Reporting.Web.API.Middleware
{

    public class ExceptionLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionLogMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory?.CreateLogger<ExceptionLogMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory)); ;
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
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message,
                Exception = exception
            }.ToString());
        }

    }
}

