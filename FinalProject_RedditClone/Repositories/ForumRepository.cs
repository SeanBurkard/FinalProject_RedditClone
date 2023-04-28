using FinalProject_RedditClone.Data;
using FinalProject_RedditClone.Models;
using FinalProject_RedditClone.Utility.Repositories;

namespace FinalProject_RedditClone.Repositories
{
    public class ForumRepository : IForumRepository
    {
        private readonly ApplicationDbContext _context;
        public ForumRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public void Add(Forum forum)
        {
            _context.Forum.Add(forum);
            _context.SaveChanges();
        }

        public void Delete(Forum forum)
        {
            _context.Forum.Remove(forum);
            _context.SaveChanges();
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forum.ToList();
        }

        public Forum GetById(int id)
        {
            return _context.Forum.FirstOrDefault(f => f.Id == id);
        }

        public void Update(Forum forum)
        {
            _context.Forum.Update(forum);
            _context.SaveChanges();
        }
    }
}
