using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject_RedditClone.Models
{
    public class PostComment
    {
        public IEnumerable<Comment> Comments { get; set; }
        public Posts Post { get; set; }

    }
}
