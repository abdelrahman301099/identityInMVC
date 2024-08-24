using Microsoft.AspNetCore.Identity;

namespace webapplicationday8.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }

    }
}
