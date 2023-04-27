using FinalProject_RedditClone.Data;
using FinalProject_RedditClone.Models;
using FinalProject_RedditClone.Utility.Repositories;

namespace FinalProject_RedditClone.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private readonly ApplicationDbContext _context;
        public PostsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Posts post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void Delete(Posts post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        public IEnumerable<Posts> GetAll()
        {
            return _context.Posts.ToList();
        }

        public Posts GetById(int id)
        {
            return _context.Posts.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Posts post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }
    }
}
