using Application.Interfaces;
using Energigas.Api.Osinergmin.Application.DTOs;

namespace Energigas.Api.Osinergmin.Application.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly ISoapOsinergminClient _IsoapOsinermingClient;

        public PurchaseOrderService(ISoapOsinergminClient IsoapOsinergminClient)
        {
            _IsoapOsinermingClient = IsoapOsinergminClient;
        }

        public async Task<SimplePurchaseOrderResponseDto> CreateSimplePurchaseOrder(SimplePurchaseOrderRequestDto simplePurchaseOrder)
        {
            var response = await _IsoapOsinermingClient.GenerateSimplePurchaseOrder(simplePurchaseOrder);

            return response;
        }
    }

}
