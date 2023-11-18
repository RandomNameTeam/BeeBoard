using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class RegisterUserDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string ReturnUrl { get; set; }
        
    }
}
