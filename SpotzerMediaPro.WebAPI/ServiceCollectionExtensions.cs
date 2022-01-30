using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SpotzerMediaPro.Common.Helpers;
using SpotzerMediaPro.Common.Interfaces;
using SpotzerMediaPro.Contracts.ServiceContracts;
using SpotzerMediaPro.Domain.Helpers;
using SpotzerMediaPro.Services;
using SpotzerMediaPro.Services.Shared;

namespace SpotzerMediaPro.WebAPI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // Configure singletons services
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ILoggerService, LoggerService>();
            
            // Configure DI for application services
            services.AddScoped<ICreateOrderService, CreateOrderService>();
            services.AddScoped<IAuditTrailService, AuditTrailService>();
            services.AddScoped<IHttpAccessorService, HttpAccessorService>();
            services.AddScoped<IBasicAuthService, BasicAuthService>();
            
           // Configure transcient services
            services.AddTransient<DataContext>();

            return services;
        }
    }
}
