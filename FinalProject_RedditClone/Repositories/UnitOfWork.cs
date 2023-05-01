using FinalProject_RedditClone.Utility.Repositories;

namespace FinalProject_RedditClone.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository User { get; }
        public IRoleRepository Role { get; }
        public IPostsRepository Posts { get; }
        public IForumRepository Forum { get; }
        public ICommentRepository Comment { get; }

        public UnitOfWork(IUserRepository user, IRoleRepository role, IPostsRepository posts, IForumRepository forum, ICommentRepository comment) 
        {
            User = user;
            Role = role;
            Posts = posts;
            Forum = forum;
            Comment = comment;
        }
    }
}
