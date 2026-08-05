using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Requests
{
    public class AttentionOrderRequestDto : CommonOrderRequestDto
    {
        public required string Scop { get; set; }
        public required string NumberInvoice { get; set; }
        public required string DateInvoice { get; set; }
        public List<AttentionOrderDetailRequestDto> Details { get; set; } = new List<AttentionOrderDetailRequestDto>();
    }
}
