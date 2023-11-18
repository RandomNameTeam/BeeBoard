using Microsoft.AspNetCore.Mvc;

namespace Identity.Models
{
    public class LoginUserDto
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }   

    }
}
