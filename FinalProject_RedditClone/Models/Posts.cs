namespace FinalProject_RedditClone.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? UserId { get; set; }
        public int? SubforumId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
