using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject_RedditClone.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [ForeignKey("Posts")]
        public int PostId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Posts Posts { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
