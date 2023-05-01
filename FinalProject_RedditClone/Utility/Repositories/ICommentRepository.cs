using FinalProject_RedditClone.Models;

namespace FinalProject_RedditClone.Utility.Repositories
{
    public interface ICommentRepository
    {
        Comment GetById(int id);
        IEnumerable<Comment> GetAll();
        IEnumerable<Comment> GetAllByPostId(int id);
        void Add(Comment forum);
        void Update(Comment forum);
        void Delete(Comment forum);
    }
}
