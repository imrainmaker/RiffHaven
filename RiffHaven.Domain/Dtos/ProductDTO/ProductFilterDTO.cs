using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiffHaven.Domain.Dtos.ProductDTO
{
    public class ProductFilterDTO
    {

        public decimal? price { get; set; }
        public string? Tremolo { get; set; }
        public string? Pickup { get; set; }
        public int? Scale { get; set; }
        public int? Frets { get; set; }
        public string? Color { get; set; }
        public string? Style { get; set; }
        public string? Brand { get; set; }
        public string? BodyWood { get; set; }
        public string? NeckWood { get; set; }
        public string? TopWood { get; set; }
        public string? FretboardWood { get; set; }
    }
}
