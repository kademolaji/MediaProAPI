using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SpotzerMediaPro.Common.Interfaces;
using SpotzerMediaPro.Common.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Common.Exceptions
{
        public class SpotzerMediaProExceptionMiddleware
    {
            private readonly RequestDelegate _next;
            private readonly ILoggerService _loggerService;

            public SpotzerMediaProExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
            {
                _next = next;
                _loggerService = loggerService;
            }

            public async Task Invoke(HttpContext context)
            {
                try
                {
                    await _next.Invoke(context);
                }
                catch (Exception ex)
                {
                    await LogExceptionAsync(context, ex).ConfigureAwait(false);
                }
            }

            private Task LogExceptionAsync(HttpContext context, Exception exception)
            {
                int statusCode = (int)HttpStatusCode.InternalServerError;
                var result = JsonConvert.SerializeObject(new
                {
                    Status = statusCode,
                    Error = exception.Message
                });

                var request = context.Request;
                _loggerService.Error($"[SpotzerMediaProGlobalException] Request Path: [{request?.Path}], Error => [{exception.Message}], StackTrace => [{exception.StackTrace}]");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;
                return context.Response.WriteAsync(result);
            }
        }
    }