using FinalProject_RedditClone.Models;

namespace FinalProject_RedditClone.Utility.ViewModels
{
    public class ReportingVM
    {
        public IEnumerable<Posts>? Posts { get; set; }
        public IEnumerable<Comment>? Comments { get; set; }
        public IEnumerable<Forum>? Forums { get; set; }
        public IEnumerable<Vote>? Votes { get; set; }
        public IEnumerable<PostComment>? PostComments { get; set; }
    }
}
