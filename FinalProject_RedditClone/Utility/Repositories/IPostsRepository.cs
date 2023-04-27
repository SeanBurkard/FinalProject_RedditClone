using FinalProject_RedditClone.Migrations;
using FinalProject_RedditClone.Models;

namespace FinalProject_RedditClone.Utility.Repositories
{
    public interface IPostsRepository
    {
        Posts GetById(int id);
        IEnumerable<Posts> GetAll();
        void Add(Posts post);
        void Update(Posts post);
        void Delete(Posts post);
    }
}
