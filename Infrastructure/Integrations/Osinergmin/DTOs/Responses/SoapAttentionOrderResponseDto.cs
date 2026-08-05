using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Integrations.Osinergmin.DTOs.Responses
{
    public class SoapAttentionOrderResponseDto
    {
        public string? CodigoAutorizacion { get; set; } 
        public string? CodigoError { get; set; } 
        public string? Resultado { get; set; }   
    }
}
