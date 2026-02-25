using Energigas.Api.Osinergmin.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IPurchaseOrderService
    {
        Task<SimplePurchaseOrderResponseDto> CreateSimplePurchaseOrder(SimplePurchaseOrderRequestDto simplePurchaseOrder);
    }
}
