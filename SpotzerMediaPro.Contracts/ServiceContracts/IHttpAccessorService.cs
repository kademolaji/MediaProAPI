using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Contracts.ServiceContracts
{
    public interface IHttpAccessorService
    {
        String GetClientIP();
        String GetHostAddress();
    }
}
