using BEChallenge.CrossCutting.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace BEChallenge.API.Shared.Middleware
{
    public class ExceptionMiddleware
    {
        #region Members

        private readonly RequestDelegate _next;

        #endregion

        #region Constructors

        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        #endregion

        #region Methods

        public async Task InvokeAsync(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            try
            {
                await this._next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (typeof(ValidationException).IsAssignableFrom(exception.GetType()))
            {
                context.Response.StatusCode = (Int32)HttpStatusCode.UnprocessableEntity;
                return context.Response.WriteAsync(new ErrorDetailsDto()
                {
                    Message = exception.Message
                }.ToString());
            }

            context.Response.StatusCode = (Int32)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorDetailsDto()
            {
                Message = "Unhandled error"
            }.ToString());
        }

        #endregion
    }
}