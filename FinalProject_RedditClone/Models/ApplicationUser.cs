using Microsoft.AspNetCore.Identity;

namespace FinalProject_RedditClone.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
