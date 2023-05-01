using FinalProject_RedditClone.Data;
using FinalProject_RedditClone.Models;
using FinalProject_RedditClone.Utility.Repositories;

namespace FinalProject_RedditClone.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Comment comment)
        {
            _context.Comment.Add(comment);
            _context.SaveChanges();
        }

        public void Delete(Comment comment)
        {
            _context.Comment.Remove(comment);
            _context.SaveChanges();
        }

        public IEnumerable<Comment> GetAll()
        {
            return _context.Comment.ToList();
        }

        public IEnumerable<Comment> GetAllByPostId(int id)
        {
            var comments = _context.Comment
                            .Where(c => c.PostId == id)
                            .ToList();
            return comments;
        }

        public Comment GetById(int id)
        {
            return _context.Comment.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Comment comment)
        {
            _context.Comment.Update(comment);
            _context.SaveChanges();
        }
    }
}
