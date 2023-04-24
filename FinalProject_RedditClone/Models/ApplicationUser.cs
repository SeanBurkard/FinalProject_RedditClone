using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace FinalProject_RedditClone.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
        public string Bio { get; set; }
    }
}
