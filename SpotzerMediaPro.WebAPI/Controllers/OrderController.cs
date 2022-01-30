using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotzerMediaPro.Common.Helpers;
using SpotzerMediaPro.Common.Interfaces;
using SpotzerMediaPro.Contracts.DataContracts.Order;
using SpotzerMediaPro.Contracts.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotzerMediaPro.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICreateOrderService _service;
        private readonly ILoggerService _loggerService;

        public OrderController(ICreateOrderService service, ILoggerService loggerService)
        {
            _service = service;
            _loggerService = loggerService;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(200, Type = typeof(CreateResponse))]
        [ProducesResponseType(400, Type = typeof(CreateResponse))]
        public async Task<IActionResult> Create([FromBody] OrderDto model)
        {
            try
            {
                _loggerService.Info($"[OrderController] Order with OrderId [{model.OrderId}] -> New create order request with model {model}");
                var apiResponse = await _service.CreateOrder(model);
                if (apiResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    _loggerService.Info($"[OrderController] Order with OrderId [{model.OrderId}] -> returned badrequest {apiResponse.ResponseType}");
                    return BadRequest(apiResponse.ResponseType);
                }
                _loggerService.Info($"[OrderController] Order with OrderId [{model.OrderId}] -> returned OK {apiResponse.ResponseType}");
                return Ok(apiResponse.ResponseType);
            }
            catch (Exception ex)
            {
                _loggerService.Error($"[OrderController] Order with OrderId [{model.OrderId}] -> Server Error {ex.Message}");
                return BadRequest($"Server Error {ex.Message}");
            }
        }
    }
}
