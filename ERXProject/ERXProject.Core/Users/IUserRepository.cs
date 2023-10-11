using ERXProject.Core.Users;

namespace ERXProject.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> InsertAsync(User user);
        Task<User> GetAsync(string accessKey);
        Task<User> GetAsync(Guid id);
    }
}
