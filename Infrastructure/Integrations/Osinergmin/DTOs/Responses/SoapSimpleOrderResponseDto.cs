using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Infrastructure.Integrations.Osinergmin.DTOs.Responses
{
    public class SoapSimpleOrderResponseDto
    {
        public string? API { get; set; }
        public string? CodigoAutorizacion { get; set; }
        public string? CodigoDGHCliente { get; set; }
        public string? CodigoEstado { get; set; }
        public string? CodigoMayoristaEquivalente { get; set; }
        public string? CodigoOsinergCliente { get; set; }
        public string? CodigoPlantaEquivalente { get; set; }
        public string? DescripcionEstado { get; set; }
        public DateTime? FechaCompra { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public DateTime? FechaFactura { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaVenta { get; set; }
        public string? FormaVenta { get; set; }
        public string? HoraModificacion { get; set; }
        public string? HoraRegistro { get; set; }
        public string? HoraVenta { get; set; }
        public string? NumeroFactura { get; set; }
        public string? NumeroGuia { get; set; }
        public string? OrdenPedido { get; set; }
        public string? PlacaTransporte { get; set; }
        public string? RucComprador { get; set; }
        public decimal? VolumenSolicitado { get; set; }
        public decimal? VolumenVenta { get; set; }
        public List<SoapSimpleOrderDetailResponseDto> Detalles { get; set; }
    }
}
