using FinalProject_RedditClone.Models;

namespace FinalProject_RedditClone.Utility.Repositories
{
    public interface IPostsRepository
    {
        IEnumerable<Posts> SearchPosts(string query);
        IEnumerable<Posts> GetAllByForumId(int id);
        Posts GetById(int id);
        IEnumerable<Posts> GetAll();
        IEnumerable<Posts> GetHomeFeed();
        void Add(Posts post);
        void Update(Posts post);
        void Delete(Posts post);
    }
}
