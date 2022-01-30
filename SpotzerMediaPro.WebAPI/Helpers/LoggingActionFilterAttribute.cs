using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using SpotzerMediaPro.Common.Helpers;
using SpotzerMediaPro.Common.Interfaces;
using SpotzerMediaPro.Common.Settings;
using System;

namespace SpotzerMediaPro.WebAPI.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method)]
    public class LoggingActionFilterAttribute : ActionFilterAttribute
    {
        private readonly ILoggerService _logger;

        public LoggingActionFilterAttribute(IOptions<AppSettings> appSettings)
        {
            _logger = new LoggerService();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.Info(FormatActionLog(context));
            base.OnActionExecuted(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.Info(FormatActionLog(context));
            base.OnResultExecuted(context);
        }

        private string FormatActionLog(FilterContext context)
        {
            var traceIdentifier = context.HttpContext.TraceIdentifier;
            var requestMethod = context.HttpContext.Request.Method;
            var requestUrl = UriHelper.GetDisplayUrl(context.HttpContext.Request);

            return $"[{traceIdentifier}]|[{requestMethod}]|[{requestUrl}]";
        }
    }
}
