using ERXProject.Core.Users;

namespace ERXProject.Services.AuthService
{
    public interface IAuthService
    {
        public Task<LoginResult> LoginAsync(LoginParams loginParams);
    }
}
