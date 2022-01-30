using Microsoft.AspNetCore.Http;
using SpotzerMediaPro.Contracts.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Services.Shared
{
    public class HttpAccessorService : IHttpAccessorService
    {
        private readonly IHttpContextAccessor _httpAccessor;
        public HttpAccessorService(IHttpContextAccessor httpContextAccessor)
        {
            _httpAccessor = httpContextAccessor;
        }


        public String GetClientIP()
        {
            return _httpAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        public String GetHostAddress()
        {
            return _httpAccessor.HttpContext.Request.Host.Host.ToString();
        }
    }
}
