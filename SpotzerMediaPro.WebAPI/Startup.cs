using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using SpotzerMediaPro.Domain.Helpers;
using SpotzerMediaPro.WebAPI.Filters;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotzerMediaPro.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<DataContext>(options =>
              options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"), b =>
              b.MigrationsAssembly("SpotzerMediaPro.Domain")));

            // Configure app services
            services.RegisterServices();

         

            services.AddControllers();
            services.AddSwaggerExamplesFromAssemblyOf<SwaggerMultipleExampleFilter>();
            services.AddSwaggerGen(c =>
            {
                c.ExampleFilters();
                c.SwaggerDoc("v1",
                     new OpenApiInfo
                     {
                         Title = "SpotzerMediaPro API",
                         Version = "v1",
                         Description = "A multitenant order platform",

                     });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, ILogger<Startup> logger)
        {
            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SpotzerMediaPro.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
