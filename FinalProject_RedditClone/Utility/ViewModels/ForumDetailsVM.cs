using FinalProject_RedditClone.Models;

namespace FinalProject_RedditClone.Utility.ViewModels
{
    public class ForumDetailsVM
    {
        public Forum Forum { get; set; }
        public IEnumerable<Posts> Posts { get; set; }
        public int ForumId { get; set; }
    }
}
