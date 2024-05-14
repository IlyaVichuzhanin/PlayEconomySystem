using System.ComponentModel.DataAnnotations;

namespace Play.Catalog.Service.Models
{
    public record Item
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTimeOffset CreatedDate { get; set; }
    }
}
