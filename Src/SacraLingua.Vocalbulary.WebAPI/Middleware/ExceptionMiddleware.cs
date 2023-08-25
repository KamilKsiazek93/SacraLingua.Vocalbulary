using SacraLingua.Vocalbulary.Domain.Exceptions;
using SacraLingua.Vocalbulary.WebAPI.Models.Responses;
using System.Net;
using System.Text.Json;

namespace SacraLingua.Vocalbulary.WebAPI.Middleware
{
    /// <summary>
    /// Exception Middleware classes
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next) => _next = next;

        /// <summary>
        /// Check current exception and convert it to proper Error Response
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainValidationException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest);
            }
            catch (DomainEntityNotFoundException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            ErrorResponse errorResponse = new ErrorResponse()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            };

            var json = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(json);
        }
    }
}
