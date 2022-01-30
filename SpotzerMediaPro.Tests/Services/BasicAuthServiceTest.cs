using SpotzerMediaPro.Services.Shared;
using SpotzerMediaPro.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpotzerMediaPro.Tests.Services
{
    public class BasicAuthServiceTest : BaseServiceTest
    {
        [Fact]
        public void TestCheckValidUserKeyShouldReturnFalse()
        {
            // Given
            var channels = SpotzerMediaProFaker.GetChannels();
            foreach (var channel in channels)
            {
                MockContext.Channels.Add(channel);
            }

            MockContext.SaveChanges();

            // When

            var basicAuthService = new BasicAuthService(MockContext);
            var result = basicAuthService.CheckValidUserKey("");

            // Then
            Assert.False(result);
        }

        [Fact]
        public void TestCheckValidUserKeyShouldReturnTrue()
        {
            // Given
            var channels = SpotzerMediaProFaker.GetChannels();
            foreach (var channel in channels)
            {
                MockContext.Channels.Add(channel);
            }

            MockContext.SaveChanges();
            var myChannel = channels.FirstOrDefault();

            // When

            var basicAuthService = new BasicAuthService(MockContext);
            var result = basicAuthService.CheckValidUserKey(myChannel.ApiKey);

            // Then
            Assert.True(result);
        }
    }
}
