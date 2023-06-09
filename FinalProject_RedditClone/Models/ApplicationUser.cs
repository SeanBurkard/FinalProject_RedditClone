﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace FinalProject_RedditClone.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? State { get; set; }
        public string? Bio { get; set; }
        public byte[]? ProfilePicture { get; set; }
    }

    public class ApplicationRole : IdentityRole 
    {
    
    }
}
