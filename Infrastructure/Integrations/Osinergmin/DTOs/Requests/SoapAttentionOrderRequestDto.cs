using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Integrations.Osinergmin.DTOs.Requests
{
    public sealed class SoapAttentionOrderRequestDto
    {
        public string loginUsuario { get; set; } = string.Empty;

        public string claveUsuario { get; set; } = string.Empty;
        public string codigoAutorizacion { get; set; } = string.Empty;
        public string codigoMayoristaEquivalente { get; set; } = string.Empty;
        public string codigoPlantaEquivalente { get; set; } = string.Empty;
        public string numeroFactura { get; set; } = string.Empty;
        public string fechaFactura { get; set; } = string.Empty;
        public string tipoVentaFactor { get; set; } = "VE";
        public string codigoEquivalenteProductor { get; set; } = string.Empty;

        public List<SoapAttentionDetailOrderRequestDto> detalles = new List<SoapAttentionDetailOrderRequestDto>();

    }
}
