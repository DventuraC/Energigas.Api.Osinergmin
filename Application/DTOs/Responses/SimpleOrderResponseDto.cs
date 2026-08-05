namespace Application.DTOs.Responses
{
    public sealed class SimpleOrderResponseDto
    {
        public string? CodigoAutorizacion { get; set; }
        public string? CodigoDghCliente { get; set; }
        public string? CodigoEstado { get; set; }
        public string? CodigoMayoristaEquivalente { get; set; }
        public string? CodigoOsinergCliente { get; set; }
        public string? CodigoPlantaEquivalente { get; set; }
        public string? DescripcionEstado { get; set; }
        public List<SimpleOrderDetailResponseDto> Detalles { get; set; } = new List<SimpleOrderDetailResponseDto>();
    }

    public sealed class SimpleOrderDetailResponseDto
    {
        public decimal? CantidadDespachada { get; set; } 
        public decimal? CantidadSolicitada { get; set; }
        public decimal? CantidadVendida { get; set; } 
        public string? CodigoEstado { get; set; }
        public string? CodigoProducto { get; set; }
        public string? DetallePedido { get; set; }
        public string? PlacaTransporte { get; set; }
        public decimal? FactorAPI { get; set; }
        public decimal? Temperatura { get; set; }
    }
}
