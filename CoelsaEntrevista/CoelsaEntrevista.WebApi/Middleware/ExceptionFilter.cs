using CoelsaEntrevista.Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoelsaEntrevista.WebApi.Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ExceptionFilter : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {

            // Logeo la excepcion
            //TODO

            if (context.Exception.GetType() == typeof(FormatException))
            {
                // Retorno el error custom
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = 400;
                context.Result = new JsonResult(new
                {
                    Message = "There was a problem with the request model",
                    ExceptionMessage = context.Exception.Message
                });
            }
            else if (context.Exception.GetType() == typeof(BusinessException))
            {
                // Retorno el error custom
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = 500;
                context.Result = new JsonResult(new
                {
                    Message = context.Exception.Message,
                    AditionalMessage = ((BusinessException)context.Exception).AditionalMessage
                });
            }
            else
            {
                // Retorno el error custom
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = 500;
                context.Result = new JsonResult(new
                {
                    Message = "An error has occured, please contact the system admin",
                    ExceptionMessage = context.Exception.Message,
                    StackTrace = context.Exception.StackTrace
                });
            }




        }

    }
}
