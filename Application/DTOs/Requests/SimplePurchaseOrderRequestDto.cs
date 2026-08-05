namespace Application.DTOs.Requests
{
    public class SimplePurchaseOrderRequestDto : CommonOrderRequestDto
    {
        public required string TypeTransaction { get; set; }
        public string? TransportPlate { get; set; } // Opcional
        public DateTime DeliveryDate { get; set; }
        public string? Tail { get; set; } 
        public required List<SimplePurchaseOrdenDetailRequestDto> Details { get; set; }
    }
}
