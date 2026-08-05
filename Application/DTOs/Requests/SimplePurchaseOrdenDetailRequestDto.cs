namespace Application.DTOs.Requests
{
    public class SimplePurchaseOrdenDetailRequestDto
    {
        public required string ProductCode { get; set; }
        public required double RequestedQuantity { get; set; } = 0;
    }
}
