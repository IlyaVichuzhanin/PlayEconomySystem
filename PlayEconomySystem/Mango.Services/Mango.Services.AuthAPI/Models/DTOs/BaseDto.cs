using System.ComponentModel.DataAnnotations;

namespace Mango.Services.AuthAPI.Models.DTOs;

public class BaseDto : IDto
{
    [Key]
    public Guid? Id { get; set; }
}