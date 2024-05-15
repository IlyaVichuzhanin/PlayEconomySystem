using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Models.DTOs.Items;

namespace Play.Catalog.Service.Converters
{
    public class ItemConverter : IConverter<ItemDto, Item>
    {
        public ItemDto? ConvertToDto(Item? entity)
        {
            throw new NotImplementedException();
        }

        public Item ConvertToEntity(ItemDto model)
        {
            throw new NotImplementedException();
        }
    }
}
