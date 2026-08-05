namespace Infrastructure.Integrations.Osinergmin.DTOs.Requests
{
    public class SoapPurchaseOrdenDetailRequestDto
    {
        public required string codigoProducto { get; set; }
        public required double cantidadSolicitada { get; set; }
    }
}
