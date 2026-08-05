using System;
using System.Collections.Generic; 
using System.Text;
using System.Xml.Serialization;

namespace Infrastructure.Integrations.Osinergmin.DTOs.Responses
{
    public class SoapSimpleOrderDetailResponseDto
    {
        public decimal Cantidad1 { get; set; }
        public decimal Cantidad2 { get; set; }
        public decimal CantidadDespachada { get; set; }
        public decimal CantidadSolicitada { get; set; }
        public decimal CantidadVendida { get; set; }
        public string CodigoEstado { get; set; }
        public string CodigoMotivoRechazo { get; set; }
        public string CodigoProducto { get; set; }
        public decimal DensidadObservada { get; set; }
        public string DetallePedido { get; set; }
        public decimal FactorAPI { get; set; }
        public decimal FactorApor { get; set; }
        public decimal FactorComp { get; set; }
        public string FechaDespacho { get; set; }
        public string FechaVenta { get; set; }
        public string PlacaTransporte { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioGalon { get; set; }
        public decimal Temperatura { get; set; }
    }
}
