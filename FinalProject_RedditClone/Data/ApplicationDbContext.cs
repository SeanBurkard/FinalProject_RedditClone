using FinalProject_RedditClone.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FinalProject_RedditClone.Models;

namespace FinalProject_RedditClone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Forum> Forum { get; set; }
        public DbSet<FinalProject_RedditClone.Models.Comment>? Comment { get; set; }
    }
}