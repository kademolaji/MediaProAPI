using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SpotzerMediaPro.Contracts.ServiceContracts;
using SpotzerMediaPro.Tests.Helpers;
using SpotzerMediaPro.WebAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpotzerMediaPro.Tests.DependencyInjection
{
    public class WebApiDependencyResolverTest
    {
        private const string SettingsFile = "appsettings.json";
        private readonly DependencyResolverHelper _serviceProvider;

        public WebApiDependencyResolverTest()
        {
           
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(SettingsFile, optional: false, reloadOnChange: false)
                .Build();

            var webHost = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseConfiguration(config)
                .Build();

            _serviceProvider = new DependencyResolverHelper(webHost);
        }

        [Fact]
        public void ICreateOrderServiceShouldGetResolved()
        {
            // When
            var service = _serviceProvider.GetService<ICreateOrderService>();

            // Then
            Assert.NotNull(service);
        }

        [Fact]
        public void IHttpAccessorServiceShouldGetResolved()
        {
            // When
            var service = _serviceProvider.GetService<IHttpAccessorService>();

            // Then
            Assert.NotNull(service);
        }

        [Fact]
        public void IAuditTrailServiceShouldGetResolved()
        {
            // When
            var service = _serviceProvider.GetService<IAuditTrailService>();

            // Then
            Assert.NotNull(service);
        }

        [Fact]
        public void IBasicAuthServiceShouldGetResolved()
        {
            // When
            var service = _serviceProvider.GetService<IBasicAuthService>();

            // Then
            Assert.NotNull(service);
        }
    }
}
