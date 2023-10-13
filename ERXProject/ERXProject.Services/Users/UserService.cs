using ERXProject.Core.Users;
using ERXProject.Repositories.Users;
using ERXProject.Services.Cryptographies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ERXProject.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptographyService _cryptographyService;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(IUserRepository userRepository, ICryptographyService cryptographyService)
        {
            this._userRepository = userRepository;
            this._cryptographyService = cryptographyService;
        }

        public async Task<UserResult> CreateAsync(UserParams createParams)
        {
            try
            {
                var userExists = await _userRepository.GetAsync(createParams.AcessKey);

                if (userExists == null)
                {
                    var model = await User.CreateAsync(createParams);
                    var pwdHash = _cryptographyService.GeneratePasswordHash(model.Password);
                    model.Password = pwdHash;

                    var user = await this._userRepository.InsertAsync(model);
                    return new UserResult(model);
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

        public async Task<UserResult> GetContextUser(IHttpContextAccessor context)
        {
            foreach (Claim claims in context.HttpContext.User.Claims)
            {
                if (claims.Type == "UserId")
                {
                    try
                    {
                        var userId = Guid.Parse(claims.Value);
                        var user = await this._userRepository.GetAsync(userId);

                        return new UserResult(user);
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
            }
            return null;
        }
    }
}
