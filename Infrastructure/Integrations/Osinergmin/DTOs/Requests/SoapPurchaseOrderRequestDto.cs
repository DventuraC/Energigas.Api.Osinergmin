namespace Infrastructure.Integrations.Osinergmin.DTOs.Requests
{
    public class SoapPurchaseOrderRequestDto
    {
        public required string loginUsuario { get; set; }
        public required string claveUsuario { get; set; }
        public required string tipoTransaccion { get; set; }
        public required string codigoMayoristaEquivalente { get; set; }
        public required string codigoPlantaEquivalente { get; set; }
        public string? placaTransporte { get; set; } // Opcional
        public DateTime fechaEntrega { get; set; }
        public string? cola { get; set; } 
        public required List<SoapPurchaseOrdenDetailRequestDto> detalles { get; set; }
    }
}
