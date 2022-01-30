using Moq;
using SpotzerMediaPro.Contracts.ServiceContracts;
using SpotzerMediaPro.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpotzerMediaPro.Tests.Services
{
    public class AuditTrailServiceTest : BaseServiceTest
    {
        [Fact]
        public void TestAuditTrailServiceShouldReturnTheCountOfInsertedData()
        {
            // Given
            var httpAccessorServiceMock = new Mock<IHttpAccessorService>();
            var auditTrailService = new AuditTrailService(MockContext, httpAccessorServiceMock.Object);
            int expectedCount = 1;

            auditTrailService.SaveAuditTrail("Test Test Test", "Order", Domain.Entities.ActionType.Created, "Tester");

            // When
            var auditTrails = auditTrailService.SearchAuditTrail(new Common.Helpers.SearchCall<string> { From = 0, PageSize = 10, Parameter = "" }).GetAwaiter().GetResult();

            // Then
            Assert.Equal(auditTrails.ResponseType.TotalCount, expectedCount);
        }
    }
}
