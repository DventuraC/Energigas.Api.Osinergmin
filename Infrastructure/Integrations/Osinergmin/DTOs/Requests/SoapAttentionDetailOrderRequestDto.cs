using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Integrations.Osinergmin.DTOs.Requests
{
    public class SoapAttentionDetailOrderRequestDto
    {
        public string detallePedido { get; set; } = string.Empty; 
        public string codigoProducto { get; set; } = string.Empty;
        public decimal cantidadVendida { get; set; } 
        public string placaTransporte { get; set; }  = string.Empty; 
        public string codigoEstado { get; set; }  = "02";
    }
}
