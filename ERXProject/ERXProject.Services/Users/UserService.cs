using ERXProject.Core.Users;
using ERXProject.Repositories.Users;
using ERXProject.Services.Cryptographies;

namespace ERXProject.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptographyService _cryptographyService;

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
    }
}
