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
        public DbSet<FinalProject_RedditClone.Models.Posts>? Posts { get; set; }
    }
}