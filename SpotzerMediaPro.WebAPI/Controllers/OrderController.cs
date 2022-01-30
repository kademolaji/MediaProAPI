using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotzerMediaPro.Common.Helpers;
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
        public OrderController(ICreateOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(201, Type = typeof(CreateResponse))]
        [ProducesResponseType(400, Type = typeof(CreateResponse))]
        public async Task<IActionResult> Create([FromBody]OrderDto model)
        {
            try
            {
                var apiResponse = await _service.CreateOrder(model, 1);

                return Ok(apiResponse.ResponseType);
            }
            catch (Exception ex)
            {
                return BadRequest($"Server Error {ex.Message}");
            }
        }
    }
}
