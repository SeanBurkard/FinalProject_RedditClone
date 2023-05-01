using FinalProject_RedditClone.Data;
using FinalProject_RedditClone.Models;
using FinalProject_RedditClone.Utility.Repositories;

namespace FinalProject_RedditClone.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        private readonly ApplicationDbContext _context;
        public VoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Vote vote)
        {
            _context.Vote.Add(vote);
            _context.SaveChanges();
        }

        public void Delete(Vote vote)
        {
            _context.Vote.Remove(vote);
            _context.SaveChanges();
        }

        public IEnumerable<Vote> GetAll()
        {
            return _context.Vote.ToList();
        }

        public IEnumerable<Vote> GetAllByForumId(int id)
        {
            var votes = _context.Vote
                            .Where(x => x.ForumId == id)
                            .ToList();
            return votes;
        }

        public IEnumerable<Vote> GetAllByPostId(int id)
        {
            var votes = _context.Vote
                            .Where(x => x.PostId == id) 
                            .ToList();
            return votes;
        }

        public Vote GetById(int id)
        {
            return _context.Vote.FirstOrDefault(v => v.Id == id);
        }

        public void Update(Vote vote)
        {
            _context.Vote.Update(vote);
            _context.SaveChanges();
        }
    }
}
