using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.CustomExceptions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = 400;

            string message = "Internal Server Error";
            IEnumerable<ValidationFailure> errors;
            if (e.GetType() == typeof(ValidationException))
            {
                message = e.Message;
                errors = ((ValidationException)e).Errors;
                httpContext.Response.StatusCode = 400;

                return httpContext.Response.WriteAsync(new ValidationErrorDetails
                {
                    StatusCode = 400,
                    SituationCode = 2,
                    Message = message,
                    Errors = errors
                }.ToString());
            }
            if (e.GetType() == typeof(UnApprovedAccountException))
            {
                return httpContext.Response.WriteAsync(new UnApprovedAccountErrorDetails
                {
                    UserId = ((UnApprovedAccountException)e).UserId,
                    Success = false,
                    SituationCode = 3,
                    StatusCode = httpContext.Response.StatusCode,
                    Message = "UnAprovement account, please approve your account with Sms code!"
                }.ToString());
            }

            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                SituationCode = 1,
                Success = false,
                StatusCode = httpContext.Response.StatusCode,
                Message = e.Message
            }.ToString());
        }
    }
}
