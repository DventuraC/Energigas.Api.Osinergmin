using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces;

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

        public async Task<SimpleOrderResponseDto> GetSimpleOrder(SimpleOrderRequestDto simpleOrder)
        {
            var response = await _IsoapOsinermingClient.GetSimplePurchaseByScopAsync(simpleOrder);

            return response;
        }

        public async Task<AttentionOrderResponseDto> AttentionOrder(AttentionOrderRequestDto order)
        {
            var respone = await _IsoapOsinermingClient.AttentionOrderAsync(order);
            return respone;
        }

    }

}
