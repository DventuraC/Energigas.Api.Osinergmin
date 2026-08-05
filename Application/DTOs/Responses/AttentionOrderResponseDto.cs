using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Responses
{
    public sealed class AttentionOrderResponseDto
    {
        public string? CodigoAutorizacion { get; set; }
        public string? CodigoError { get; set; }
        public string? Resultado { get; set; }
        public string? DescripcionEstado { get; set; }
    }
}
