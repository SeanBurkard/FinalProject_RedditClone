using FinalProject_RedditClone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject_RedditClone.Utility.ViewModels
{
    public class EditUserVM
    {
        public ApplicationUser User { get; set; }
        public IList<SelectListItem> Roles { get; set; }
    }
}
