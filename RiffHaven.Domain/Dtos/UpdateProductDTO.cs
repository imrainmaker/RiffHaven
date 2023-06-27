using System.ComponentModel.DataAnnotations;

namespace RiffHaven.Domain.Dtos
{
    public class UpdateProductDTO
    {
        [Required]
        public string Model { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
