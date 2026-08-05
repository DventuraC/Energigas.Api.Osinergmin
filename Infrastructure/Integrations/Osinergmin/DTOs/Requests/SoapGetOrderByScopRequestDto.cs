using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Integrations.Osinergmin.DTOs.Requests
{
    public class SoapGetOrderByScopRequestDto
    {
        public required string loginUsuario { get; set; }
        public required string claveUsuario { get; set; }
        public required string codigoAutorizacion { get; set; }
    }
}
