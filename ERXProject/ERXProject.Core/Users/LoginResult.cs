namespace ERXProject.Core.Users
{
    public class LoginResult
    {
        public Guid Id { get; set; }
        public string Token { get; set; }

        public LoginResult(User user)
        {
            this.Id = user.Id;
            this.Token = user.Token;
        }
    }
}
