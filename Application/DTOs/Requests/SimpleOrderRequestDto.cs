using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Requests
{
    public class SimpleOrderRequestDto : CommonOrderRequestDto
    {
        public required string Scop { get; set; }
    }
}
