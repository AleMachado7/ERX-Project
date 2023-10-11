using ERXProject.Core.Users;

namespace ERXProject.Services.TokenService
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
        public bool IsValid(string token);
    }
}
