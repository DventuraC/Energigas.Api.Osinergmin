using Energigas.Api.Osinergmin.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ISoapOsinergminClient
    {
        Task<SimplePurchaseOrderResponseDto> GenerateSimplePurchaseOrder(SimplePurchaseOrderRequestDto  simplePurchaseOrder);
    }
}
