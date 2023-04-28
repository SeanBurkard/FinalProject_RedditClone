namespace FinalProject_RedditClone.Utility.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IRoleRepository Role { get; }
        IPostsRepository Posts { get; }
        IForumRepository Forum { get; }
    }
}
