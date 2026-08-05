using Application.DTOs;
using Application.DTOs.Requests;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Common;

namespace Energigas.Api.Osinergmin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Scop : ControllerBase
    {
        private readonly IPurchaseOrderService _IpurchaseOrderService;

        public Scop(IPurchaseOrderService IpurchaseOrderService)
        {
            _IpurchaseOrderService = IpurchaseOrderService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSimpleOrder([FromBody] SimplePurchaseOrderRequestDto request)
        {
            var result = await _IpurchaseOrderService.CreateSimplePurchaseOrder(request);
            return Ok(ApiResponse<object>.Ok(result));
        }
    }
}
