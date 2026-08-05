using Application.DTOs.Requests;
using Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task<SimplePurchaseOrderResponseDto> CreateSimplePurchaseOrder(SimplePurchaseOrderRequestDto simplePurchaseOrder);
        Task<SimpleOrderResponseDto> GetSimpleOrder(SimpleOrderRequestDto order);
        Task<AttentionOrderResponseDto> AttentionOrder(AttentionOrderRequestDto order);
    }
}
