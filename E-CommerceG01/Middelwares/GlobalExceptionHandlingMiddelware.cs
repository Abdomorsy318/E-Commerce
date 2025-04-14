using System.Net;
using Domain.Exceptions;
using Shared.ErrorModels;

namespace E_CommerceG01.Middelwares
{
    public class GlobalExceptionHandlingMiddelware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlingMiddelware> _logger;

        public GlobalExceptionHandlingMiddelware(RequestDelegate next , ILogger<GlobalExceptionHandlingMiddelware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context )
        {
            try
            {
                await _next(context);
                if(context.Response.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    await HandelNotFoundEndPointException(context);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Somthing Went Wrong {ex}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandelNotFoundEndPointException(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            var response = new ErrorDetails
            {
                StatusCode = (int)HttpStatusCode.NotFound,
                Message = $"The Endpoint {context.Request.Path} Not Found"
            }.ToString();
            await context.Response.WriteAsync(response);
        }

        //Handel Exception
        public async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            //set status code 500
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //set content type "application/json"
            context.Response.ContentType = "application/json";
            //C# 09
            context.Response.StatusCode = ex switch
            {
                //if exception is not found
                NotFoundExceptions => (int)HttpStatusCode.NotFound,
                //if exception is bad request
                //BadRequestException => (int)HttpStatusCode.BadRequest,
                ////if exception is unauthorized
                //UnauthorizedException => (int)HttpStatusCode.Unauthorized,
                ////if exception is forbidden
                //ForbiddenException => (int)HttpStatusCode.Forbidden,
                ////if exception is internal server error
                _ => (int)HttpStatusCode.InternalServerError
            };
            //return standard response
            var response = new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            }.ToString();
            await context.Response.WriteAsync(response);
        }
    }
}
