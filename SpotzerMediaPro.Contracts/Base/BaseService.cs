using Microsoft.Extensions.Options;
using SpotzerMediaPro.Common.Helpers;
using SpotzerMediaPro.Common.Settings;
using SpotzerMediaPro.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Contracts.Base
{
    public abstract class BaseService
    {
        protected readonly DataContext Context;
        protected readonly AppSettings AppSettings;
        protected readonly LoggerService LoggerService;

        protected BaseService(DataContext context, IOptions<AppSettings> appSettings)
        {
            Context = context;
            AppSettings = appSettings.Value;
            LoggerService = new LoggerService();
        }
    }
}
