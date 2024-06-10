using Mango.Services.AuthAPI.Models.DTOs.User;

namespace Mango.Services.AuthAPI.Models.DTOs
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }

    }
}
