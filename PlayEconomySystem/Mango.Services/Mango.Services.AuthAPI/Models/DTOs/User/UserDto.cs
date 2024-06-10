namespace Mango.Services.AuthAPI.Models.DTOs.User
{
    public class UserDto : BaseDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

    }
}
