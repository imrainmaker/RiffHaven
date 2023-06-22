using RiffHaven.API.Dtos;
using RiffHaven.Domain.Entities;


namespace RiffHaven.API.Mappers
{
    public static class ProductMapper
    {
        public static Products ToProduct(this NewProductDTO productDTO)
        {
            return new Products
            {
                Model = productDTO.Model,
                Description = productDTO.Description,
                Stock = productDTO.Stock,
                Price = productDTO.Price,

                Brand = productDTO.Brand,
                Color = productDTO.Color,
                Style = productDTO.Style,
                Pickup = productDTO.Pickup,
                Scale = productDTO.Scale,
                Frets = productDTO.Frets,
                Tremolo = productDTO.Tremolo,
                BodyWood = productDTO.BodyWood,
                TopWood = productDTO.TopWood,
                NeckWood = productDTO.NeckWood,
                FretboardWood = productDTO.FretboardWood
            };
        }
    }
}
