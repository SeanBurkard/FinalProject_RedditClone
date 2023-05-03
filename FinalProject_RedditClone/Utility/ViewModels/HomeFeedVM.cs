using FinalProject_RedditClone.Models;

namespace FinalProject_RedditClone.Utility.ViewModels
{
    public class HomeFeedVM
    {
        public IEnumerable<Posts> Posts { get; set; }
        public IEnumerable<Forum> Forums { get; set; }
        public string SearchString { get; set; }
        public ApplicationUser? User { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
