namespace Energigas.Api.Osinergmin.Application.DTOs
{
    public class SimplePurchaseOrderRequestDto
    {
        public required string UserLogin { get; set; }
        public required string UserPassword { get; set; }
        public required string TypeTransaction { get; set; }
        public required string EquivalentWhosaleCode { get; set; }
        public required string EquivalentPlantCode { get; set; }
        public string? TransportPlate { get; set; } // Opcional
        public DateTime DeliveryDate { get; set; }
        public string? Tail { get; set; } 
        public required List<SimplePurchaseOrdenDetailRequestDto> Details { get; set; }
    }
}
