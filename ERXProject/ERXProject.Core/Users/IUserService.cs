using ERXProject.Core.Users;
using Microsoft.AspNetCore.Http;

namespace ERXProject.Services.Users
{
    public interface IUserService
    {
        Task<UserResult> CreateAsync(UserParams createParams);
        Task<UserResult> GetContextUser(IHttpContextAccessor context);
    }
}
