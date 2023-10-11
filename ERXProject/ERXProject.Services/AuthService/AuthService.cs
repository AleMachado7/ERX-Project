using ERXProject.Core.Users;
using ERXProject.Repositories.Users;
using ERXProject.Services.Cryptographies;
using ERXProject.Services.TokenService;

namespace ERXProject.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly ICryptographyService _cryptographyService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService, ICryptographyService cryptographyService)
        {
            this._userRepository = userRepository;
            this._tokenService = tokenService;
            this._cryptographyService = cryptographyService;
        }

        public async Task<UserResult> LoginAsync(LoginParams loginParams)
        {
            try
            {
                var user = await _userRepository.GetAsync(loginParams.AccessKey);

                if (user == null) return null;

                var passwordValid = this._cryptographyService.ValidatePassword(loginParams.Password, user.Password);

                if (passwordValid)
                {
                    return new UserResult(user);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
