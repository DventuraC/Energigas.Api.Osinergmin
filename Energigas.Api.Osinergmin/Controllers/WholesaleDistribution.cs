using Application.DTOs.Requests;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Common;

namespace Energigas.Api.Osinergmin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WholesaleDistribution : ControllerBase
    {
        private readonly IPurchaseOrderService _IpurchaseOrderService;

        public WholesaleDistribution(IPurchaseOrderService IpurchaseOrderService)
        {
            _IpurchaseOrderService = IpurchaseOrderService;
        }
        
        [HttpPost("order-attention")]
        public async Task<IActionResult> GenerateSimplePurchaseOrder([FromBody] AttentionOrderRequestDto request)
        {
            var result = await _IpurchaseOrderService.AttentionOrder(request);
            return Ok(ApiResponse<object>.Ok(result));
        }

        [HttpPost("order-by-code")]
        public async Task<IActionResult> GetOrderByCode([FromBody] SimpleOrderRequestDto request)
        {
            var result = await _IpurchaseOrderService.GetSimpleOrder(request);
            return Ok(ApiResponse<object>.Ok(result));
        }
    }
}
