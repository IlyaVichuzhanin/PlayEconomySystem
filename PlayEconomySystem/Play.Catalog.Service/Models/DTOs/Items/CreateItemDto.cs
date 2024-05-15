using System.ComponentModel.DataAnnotations;

namespace Play.Catalog.Service.Models.DTOs.Items
{
    public class CreateItemDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }

        public CreateItemDto(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public CreateItemDto()
        {

        }
    }
}
