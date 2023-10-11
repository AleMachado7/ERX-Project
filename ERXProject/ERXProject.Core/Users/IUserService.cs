using ERXProject.Core.Users;

namespace ERXProject.Services.Users
{
    public interface IUserService
    {
        Task<UserResult> CreateAsync(UserParams createParams);
    }
}
