namespace ERXProject.Services.Cryptographies
{
    public interface ICryptographyService
    {
        public string GeneratePasswordHash(string password);
        public bool ValidatePassword(string inputPassword, string userPassword);
    }
}
