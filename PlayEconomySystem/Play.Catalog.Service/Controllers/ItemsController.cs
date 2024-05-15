using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Play.Catalog.Service.Data;
using Play.Catalog.Service.Models;
using Play.Catalog.Service.Models.DTOs;
using Play.Catalog.Service.Models.DTOs.Items;

namespace Play.Catalog.Service.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ResponseDto<IEnumerable<ItemDto>>> Get()
        {
            var response = new ResponseDto<IEnumerable<ItemDto>>();
            try
            {
                IEnumerable<ItemDto> items = await _appDbContext.Items.ToListAsync();
                if (items == null)
                {
                    response.IsSuccess = false;
                }
                response.Result = items;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpGet("{id}")]
        public async Task<ResponseDto<ItemDto>> GetById(Guid id)
        {
            var response = new ResponseDto<ItemDto>();
            try
            {
                var item = await _appDbContext.Items.Where(item => item.Id == id).SingleOrDefaultAsync();
                if (item == null)
                {
                    response.IsSuccess = false;
                }
                response.Result = item;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpGet]
        [Route("GetByName/{name}")]
        public async Task<ResponseDto<ItemDto>> GetByName(string name)
        {
            var response = new ResponseDto<ItemDto>();
            try
            {
                var item = await _appDbContext.Items.Where(item => item.Name.ToLower() == name.ToLower()).SingleOrDefaultAsync();
                if (item == null)
                {
                    response.IsSuccess=false;
                }
                response.Result = item;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }


        [HttpPost]
        public async Task<ActionResult<ResponseDto<ItemDto>>> Post([FromBody] CreateItemDto createItemDto)
        {
            var response = new ResponseDto<ItemDto>();
            try
            {
                var itemDto = new ItemDto
                {
                    Id = Guid.NewGuid(),
                    Name = createItemDto.Name,
                    Description = createItemDto.Description,
                    Price = createItemDto.Price,
                    CreatedDate = DateTimeOffset.UtcNow,
                };

                await _appDbContext.Items.AddAsync(itemDto);
                await _appDbContext.SaveChangesAsync();
                response.Result= itemDto;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPut]
        public async Task<ActionResult<ResponseDto<ItemDto>>> Put([FromBody] Guid id, UpdateItemDto updateItemDto)
        {
            var response = new ResponseDto<ItemDto>();
            try
            {
                var existingItem = await _appDbContext.Items.Where(item => item.Id == id).SingleOrDefaultAsync();
                var itemDto = new ItemDto
                {
                    Id = existingItem.Id,
                    Name = updateItemDto?.Name,
                    Description = updateItemDto?.Description,
                    Price = updateItemDto.Price,
                    CreatedDate = existingItem.CreatedDate
                };

                _appDbContext.Items.Update(itemDto);
                await _appDbContext.SaveChangesAsync();
                response.Result = itemDto;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = new ResponseDto<ItemDto>();
            try
            {
                var item = await _appDbContext.Items.Where(item => item.Id == id).SingleOrDefaultAsync();
                if (item == null)
                {
                    response.IsSuccess = false;
                }
                _appDbContext.Items.Remove(item);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return NoContent();
        }


    }
}
