using System.ComponentModel.DataAnnotations;

namespace RiffHaven.Domain.Dtos.ProductDTO
{
    public class UpdateGuitarDTO
    {
        [Required]
        public string Tremolo { get; set; }
        public string Pickup { get; set; }
        [Required]
        public int Scale { get; set; }
        [Required]
        public int Frets { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Style { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string BodyWood { get; set; }
        [Required]
        public string NeckWood { get; set; }
        [Required]
        public string TopWood { get; set; }
        [Required]
        public string FretboardWood { get; set; }
    }
}
