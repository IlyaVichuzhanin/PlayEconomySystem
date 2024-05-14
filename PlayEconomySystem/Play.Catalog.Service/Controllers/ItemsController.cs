using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Data;
using Play.Catalog.Service.Models.DTOs;

namespace Play.Catalog.Service.Controllers
{
    [Route("items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ItemsController(AppDbContext appDbContext)
        {
            _appDbContext=appDbContext;
        }

        private static readonly List<ItemDto> _items = new List<ItemDto>
        {
            new ItemDto(Guid.NewGuid(), "Potion", "Restore some ...", 5,DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Antidote", "Cures poison", 7,DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Bronze sword", "Deals a small amount of damage", 20,DateTimeOffset.UtcNow)
        };


        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            try
            {
                IEnumerable<ItemDto> items = _appDbContext.Items.ToList();
                return items;
            }
            catch (Exception ex) { }

            return null;
        }
        [HttpGet("{id}")]
        public ItemDto GetById(Guid id)
        {
            var item = _appDbContext.Items.Where(item => item.Id == id).SingleOrDefault();
            return item;
        }

    }
}
