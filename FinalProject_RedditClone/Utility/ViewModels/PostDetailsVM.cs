using FinalProject_RedditClone.Models;

namespace FinalProject_RedditClone.Utility.ViewModels
{
    public class PostDetailsVM
    {
        public Posts Post { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public string CommentText { get; set; }
    }
}
