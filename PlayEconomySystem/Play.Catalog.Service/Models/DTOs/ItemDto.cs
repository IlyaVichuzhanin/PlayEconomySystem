namespace Play.Catalog.Service.Models.DTOs
{
    public record ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        public ItemDto(Guid id, string name, string description, decimal price, DateTimeOffset dateTime)
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
