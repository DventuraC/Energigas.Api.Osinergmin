using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Requests
{
    public class CommonOrderRequestDto
    {
        public required string UserLogin { get; set; }
        public required string UserPassword { get; set; }
        public string? CodeWhosaleEquivalent { get; set; }
        public string? CodePlantEquivalent { get; set; }
    }
}
