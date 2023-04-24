using FinalProject_RedditClone.Models;
using Microsoft.AspNetCore.Identity;

namespace FinalProject_RedditClone.Utility.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
