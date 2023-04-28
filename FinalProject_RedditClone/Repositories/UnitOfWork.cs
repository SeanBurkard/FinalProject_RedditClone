using FinalProject_RedditClone.Utility.Repositories;

namespace FinalProject_RedditClone.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository User { get; }
        public IRoleRepository Role { get; }
        public IPostsRepository Posts { get; }
        public IForumRepository Forum { get; }

        public UnitOfWork(IUserRepository user, IRoleRepository role, IPostsRepository posts, IForumRepository forum) 
        {
            User = user;
            Role = role;
            Posts = posts;
            Forum = forum;
        }
    }
}
