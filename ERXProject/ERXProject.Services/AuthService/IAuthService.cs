using ERXProject.Core.Users;

namespace ERXProject.Services.AuthService
{
    public interface IAuthService
    {
        public Task<UserResult> LoginAsync(LoginParams loginParams);
    }
}
