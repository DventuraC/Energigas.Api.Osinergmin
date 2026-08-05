using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Requests
{
    public class AttentionOrderDetailRequestDto
    {
        public required string CodeDetail { get; set; }
        public required string CodeProduct { get; set; }
        public required decimal AmountSoul { get; set; }
        public required string Plate { get; set; }
        public required string Status { get; set; }
    }
}
