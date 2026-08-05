using Application.DTOs.Requests;
using Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ISoapOsinergminClient
    {
        Task<SimplePurchaseOrderResponseDto> GenerateSimplePurchaseOrder(SimplePurchaseOrderRequestDto  simplePurchaseOrder);
        Task<SimpleOrderResponseDto> GetSimplePurchaseByScopAsync(SimpleOrderRequestDto simplePurchaseOrder);
        Task<AttentionOrderResponseDto> AttentionOrderAsync(AttentionOrderRequestDto attentionOrder);
    }
}
