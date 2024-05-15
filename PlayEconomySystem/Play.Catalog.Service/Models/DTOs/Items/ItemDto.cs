using System.ComponentModel.DataAnnotations;

namespace Play.Catalog.Service.Models.DTOs.Items
{
    public class ItemDto : BaseDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(0,(double)decimal.MaxValue)]
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        public ItemDto(Guid? id, string name, string description, decimal price, DateTimeOffset dateTime)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CreatedDate = dateTime;
        }

        public ItemDto()
        {

        }
    }
}
