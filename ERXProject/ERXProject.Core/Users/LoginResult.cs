namespace ERXProject.Core.Users
{
    public class LoginResult
    {
        public string Token { get; set; }

        public LoginResult(User user)
        {
            this.Token = user.Token;
        }
    }
}
