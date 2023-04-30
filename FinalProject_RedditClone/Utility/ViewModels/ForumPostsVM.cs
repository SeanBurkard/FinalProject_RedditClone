using FinalProject_RedditClone.Models;

namespace FinalProject_RedditClone.Utility.ViewModels
{
    public class ForumPostsVM
    {
        public Forum Forum { get; set; }
        public List<Posts>? Posts { get; set; }
    }
}
