namespace ERXProject.Core.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string AccessKey { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int TypeCode { get; set; }
        public string TypeName { get; set; }
        public int ProfileCode { get; set; }
        public string ProfileName { get; set; }
        public int StatusCode { get; set; }
        public string StatusName { get; set; }
        public DateTime LastAccess { get; set; }
        public int AccessCount { get; set; }
        public bool Enabled { get; set; }
        public string Avatar { get; set; }
        public string Note { get; set; }
        public string Token { get; set; }

        public User()
        {
            this.Id = Guid.NewGuid();
            this.Enabled = true;
        }

        public static async Task<User> CreateAsync(UserParams createParams)
        {
            User model = new User();

            model.Name = createParams.Name;
            model.AccessKey = createParams.AcessKey;
            model.Password = createParams.Password;
            model.Email = createParams.Email;
            model.Phone = createParams.Phone;
            model.TypeCode = createParams.TypeCode;
            model.TypeName = createParams.TypeName;
            model.ProfileCode = createParams.ProfileCode;
            model.ProfileName = createParams.ProfileName;
            model.StatusCode = createParams.StatusCode;
            model.StatusName = createParams.StatusName;
            model.Avatar = createParams.Avatar;
            model.Note = createParams.Note;

            return model;
        }
    }
}
