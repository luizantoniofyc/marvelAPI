using Dextra.Marvel.Application.Exceptions;
using Dextra.Marvel.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Dextra.Marvel.Api.Filters
{
    public class ApplicationExceptionFilter : IExceptionFilter
    {
        void IExceptionFilter.OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            
            if (exception.GetType() == typeof(NotFoundException))
            {
                HttpResponse response = context.HttpContext.Response;
                response.StatusCode = (int)HttpStatusCode.NotFound;
                response.ContentType = "application/json";
                context.Result = new JsonResult("Not Found");
            }
            else
            {
                var exceptionModel = new ExceptionModel()
                {
                    Code = exception.GetType() == typeof(BusinessException) ? exception.Source : "EX000",
                    Message = exception.Message,
                    Type = exception.GetType().Name.ToString()
                };

                HttpResponse response = context.HttpContext.Response;
                response.StatusCode = (int)HttpStatusCode.Conflict;
                response.ContentType = "application/json";
                context.Result = new JsonResult(exceptionModel);
            }
            
        }
    }
}
