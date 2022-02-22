using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Constants;
using Core.Utilities.CustomExceptions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

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

            IEnumerable<ValidationFailure> errors;
            if (e.GetType() == typeof(ValidationException))
            {
                errors = ((ValidationException)e).Errors;
                httpContext.Response.StatusCode = 400;

                return httpContext.Response.WriteAsync(new ValidationErrorDetails
                {
                    StatusCode = 400,
                    SituationCode = 2,
                    Message = JsonConvert.DeserializeObject<List<string>>(e.Message),
                    Errors = errors
                }.ToString());
            }
            if (e.GetType() == typeof(UnApprovedAccountException))
            {
                return httpContext.Response.WriteAsync(new ErrorDetails
                {
                    Success = false,
                    SituationCode = 3,
                    StatusCode = httpContext.Response.StatusCode,
                    Message = CoreMessages.UnapprovedAccount
                }.ToString());
            }
            if (e.GetType() == typeof(UnauthorizedAccessException))
            {
                return httpContext.Response.WriteAsync(new ErrorDetails
                {
                    Success = false,
                    SituationCode = 4,
                    StatusCode = httpContext.Response.StatusCode,
                    Message = CoreMessages.UnAuthorizedAccount,
                }.ToString());
            }
            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                SituationCode = 1,
                Success = false,
                StatusCode = httpContext.Response.StatusCode,
                Message = new List<string> { e.Message + " \n" + e.InnerException.Message, }
            }.ToString());
        }
    }
}
