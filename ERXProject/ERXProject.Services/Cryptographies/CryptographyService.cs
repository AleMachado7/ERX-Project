using ERXProject.Services.Cryptographies;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace ERXProject.Repositories.Cryptographies
{
    public class CryptographyService : ICryptographyService
    {
        private readonly IConfiguration _configuration;

        public CryptographyService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string GeneratePasswordHash(string password)
        {
            var hashKey = Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:HashKey").Value);

            using (var hmac = new HMACSHA512(hashKey))
            {
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(passwordHash);
            }
        }

        public bool ValidatePassword(string inputPassword, string userPassword)
        {
            var inputHash = this.GeneratePasswordHash(inputPassword);

            return userPassword.Equals(inputHash);
        }
    }
}
