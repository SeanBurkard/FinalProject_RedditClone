using FinalProject_RedditClone.Models;

namespace FinalProject_RedditClone.Utility.Repositories
{
    public interface IForumRepository 
    {
        Forum GetById(int id);
        IEnumerable<Forum> GetAll();
        void Add(Forum forum);
        void Update(Forum forum);
        void Delete(Forum forum);
    }
}
