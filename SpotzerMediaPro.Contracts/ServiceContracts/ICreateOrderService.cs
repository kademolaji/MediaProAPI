using SpotzerMediaPro.Common.Helpers;
using SpotzerMediaPro.Contracts.DataContracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Contracts.ServiceContracts
{
    public interface ICreateOrderService
    {
        Task<ApiResponse<CreateResponse>> CreateOrder(OrderDto model, long userId);
    }
}
