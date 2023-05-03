using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject_RedditClone.Models
{
    public class Vote
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Post")]
        public int? PostId { get; set; }
        [ForeignKey("Forum")]
        public int? ForumId { get; set; }
        public bool IsUpvote { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get;}

        public virtual ApplicationUser User { get; set; }
        public virtual Posts? Post { get; set; }
        public virtual Forum? Forum { get; set; }
    }
}
