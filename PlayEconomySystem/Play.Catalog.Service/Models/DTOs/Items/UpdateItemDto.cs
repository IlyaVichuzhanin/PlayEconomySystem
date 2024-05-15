using System.ComponentModel.DataAnnotations;

namespace Play.Catalog.Service.Models.DTOs.Items
{
    public class UpdateItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        public UpdateItemDto(string name, string description, decimal price, DateTimeOffset dateTime)
        {
            Name = name;
            Description = description;
            Price = price;
            CreatedDate = dateTime;
        }

        public UpdateItemDto()
        {

        }
    }
}
