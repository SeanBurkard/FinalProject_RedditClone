using FinalProject_RedditClone.Utility.Repositories;

namespace FinalProject_RedditClone.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository User { get; }
        public IRoleRepository Role { get; }

        public IPostsRepository Posts { get; }

        public UnitOfWork(IUserRepository user, IRoleRepository role, IPostsRepository posts) 
        {
            User = user;
            Role = role;
            Posts = posts;
        }
    }
}
