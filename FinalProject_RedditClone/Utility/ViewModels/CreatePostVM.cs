using FinalProject_RedditClone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;

namespace FinalProject_RedditClone.Utility.ViewModels
{
    public class CreatePostVM
    {
        public SelectList Forums { get; set; }
        public int ForumId { get; set; }
        public ApplicationUser User { get; set; }
        public Posts Post { get; set; }
    }
}
