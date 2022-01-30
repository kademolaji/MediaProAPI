using Microsoft.Extensions.DependencyInjection;
using SpotzerMediaPro.Domain.Helpers;
using SpotzerMediaPro.WebAPI.Helpers;

namespace SpotzerMediaPro.WebAPI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
           

            // Configure DI for application services
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IPaymentService, PaymentService>();

           // Configure transcient services
            services.AddTransient<DataContext>();
            services.AddTransient<LoggingActionFilterAttribute>();

            return services;
        }
    }
}
