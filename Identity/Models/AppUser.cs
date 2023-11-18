using Microsoft.AspNetCore.Identity;

namespace Identity.Models
{
    public class AppUser: IdentityUser
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
