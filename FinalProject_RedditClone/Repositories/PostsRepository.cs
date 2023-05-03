using FinalProject_RedditClone.Data;
using FinalProject_RedditClone.Models;
using FinalProject_RedditClone.Utility.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

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

        public IEnumerable<Posts> GetAllByForumId(int id)
        {
            return _context.Posts.Where(p => p.ForumId == id);
        }

        public Posts GetById(int id)
        {
            return _context.Posts.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Posts> SearchPosts(string query)
        {
            var titleMatch = _context.Posts.Where(p => p.Title.Contains(query));
            var contentMatch = _context.Posts.Where(p => p.Content.Contains(query));
            return titleMatch.Union(contentMatch);
        }

        public void Update(Posts post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

    }
}
