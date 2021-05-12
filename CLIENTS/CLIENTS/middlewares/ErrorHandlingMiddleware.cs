using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using UPB.ProyectoFinal.Clients.Models;
using UPB.ProyectoFinal.Data.Exceptions;
using UPB.ProyectoFinal.Logic.Exceptions;

namespace UPB.ProyectoFinal.Clients.middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception e)
            {
                await HandleExceptions(httpContext, e);
            }

        }
        private async Task HandleExceptions(HttpContext httpContext, Exception e)
        {
            ExceptionResponse MyError;
            if(e is DataReadException)
            {
                MyError = new ExceptionResponse
                {
                    StatusCode = 500,
                    ErrorMessage = "Ocurrio un error en la base de datos, no se pudo leer"
                };
            }
            else if(e is DataWriteException)
            {
                MyError = new ExceptionResponse
                {
                    StatusCode = 500,
                    ErrorMessage = "Ocurrio un error en la base de datos, no se pudo escribir"
                };
            }
            else if (e is ClientAttrException)
            {
                MyError = new ExceptionResponse
                {
                    StatusCode = 200,
                    ErrorMessage = "Ocurrio un error en el servidor en el registro de clientes"
                };
            }
            else
            {
                MyError = new ExceptionResponse
                {
                    StatusCode = 200,
                    ErrorMessage = "Ocurrio un error en el servidor"
                };
            }
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = MyError.StatusCode;
            await httpContext.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(MyError));
            
        }
    }


    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
