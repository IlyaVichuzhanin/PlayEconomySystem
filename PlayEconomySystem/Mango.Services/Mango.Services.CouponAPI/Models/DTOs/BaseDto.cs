using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CouponAPI.Models.DTOs;

public class BaseDto : IDto
{
    public BaseDto(Guid? id)
    {
        Id = id;
    }
    [Key]
    public Guid? Id { get; set; }
}