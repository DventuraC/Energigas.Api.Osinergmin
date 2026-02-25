namespace Energigas.Api.Osinergmin.Application.DTOs
{
    public class SoapPurchaseOrdenDetailRequestDto
    {
        public required string codigoProducto { get; set; }
        public required double cantidadSolicitada { get; set; }
    }
}
