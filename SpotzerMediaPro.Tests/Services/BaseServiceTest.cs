using Moq;
using SpotzerMediaPro.Domain.Helpers;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SpotzerMediaPro.Common.Settings;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SpotzerMediaPro.Tests.Services
{
    public abstract class BaseServiceTest : IDisposable
    {
        protected DataContext MockContext;
        protected Mock<IOptions<AppSettings>> SettingsMock;

        protected BaseServiceTest()
        {
            MockContext = new DataContext(GetOptionsBuilder());
        }

        public void Dispose()
        {
            MockContext.Database.EnsureDeleted();
            MockContext = new DataContext(GetOptionsBuilder());
        }

        private static DbContextOptions<DataContext> GetOptionsBuilder()
        {
            return new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
        }
    }
}
