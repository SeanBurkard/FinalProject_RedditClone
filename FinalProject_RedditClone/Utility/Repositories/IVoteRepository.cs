using FinalProject_RedditClone.Models;

namespace FinalProject_RedditClone.Utility.Repositories
{
    public interface IVoteRepository
    {
        Vote GetById(int id);
        IEnumerable<Vote> GetAll();
        IEnumerable<Vote> GetAllByForumId(int id);
        IEnumerable<Vote> GetAllByPostId(int id);
        void Add(Vote vote);
        void Update(Vote vote);
        void Delete(Vote vote);
    }
}
