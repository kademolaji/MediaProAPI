using Microsoft.AspNetCore.Mvc;
using Moq;
using SpotzerMediaPro.Common.Interfaces;
using SpotzerMediaPro.Contracts.ServiceContracts;
using SpotzerMediaPro.Tests.Services;
using SpotzerMediaPro.Tests.Utils;
using SpotzerMediaPro.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpotzerMediaPro.Tests.Controllers
{
   public class OrderControllerTest : BaseServiceTest
    {
            [Fact]
        public void TestCreateOrderServiceShouldReturnTrueStatusGivenRightInputWebsiteDetails()
        {
            // Given
            var channels = SpotzerMediaProFaker.GetChannels();
            foreach (var channel in channels)
            {
                MockContext.Channels.Add(channel);
            }

            var products = SpotzerMediaProFaker.GetProducts();
            foreach (var product in products)
            {
                MockContext.Products.Add(product);
            }

            var channelProducts = SpotzerMediaProFaker.GetChannelProducts();
            foreach (var channelProduct in channelProducts)
            {
                MockContext.ChannelProducts.Add(channelProduct);
            }

            MockContext.SaveChanges();


            var createOrderService = new Mock<ICreateOrderService>();
            var loggerServiceMock = new Mock<ILoggerService>();
            var orderController = new OrderController(createOrderService.Object, loggerServiceMock.Object);
            var orders = SpotzerMediaProFaker.GetOrders();
            var websiteDetails = orders.FirstOrDefault();

            // When
            var order = orderController.Create(websiteDetails).GetAwaiter().GetResult();
            // Then
            Assert.IsType<BadRequestObjectResult>(order);
        }
    }
}
