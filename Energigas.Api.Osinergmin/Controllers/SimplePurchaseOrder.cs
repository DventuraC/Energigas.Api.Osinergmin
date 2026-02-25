using Application.Interfaces;
using Energigas.Api.Osinergmin.Application.DTOs;
using Energigas.Api.Osinergmin.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Common;

namespace Energigas.Api.Osinergmin.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SimplePurchaseOrder : ControllerBase
    {
        private readonly IPurchaseOrderService _IpurchaseOrderService;

        public SimplePurchaseOrder(IPurchaseOrderService IpurchaseOrderService)
        {
            _IpurchaseOrderService = IpurchaseOrderService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> GenerateSimplePurchaseOrder([FromBody] SimplePurchaseOrderRequestDto request)
        {
            var result = await _IpurchaseOrderService.CreateSimplePurchaseOrder(request);
            return Ok(ApiResponse<object>.Ok(result) );
        }
    }
}
