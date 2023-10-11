namespace ERXProject.Core.Users
{
    public class UserResult
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string AccessKey { get; set; }
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

        public UserResult(User user)
        {
            this.Id = user.Id;
            this.Code = user.Code;
            this.Name = user.Name;
            this.AccessKey = user.AccessKey;
            this.Email = user.Email;
            this.Phone = user.Phone;
            this.TypeCode = user.TypeCode;
            this.TypeName = user.TypeName;
            this.ProfileCode = user.ProfileCode;
            this.ProfileName = user.ProfileName;
            this.StatusCode = user.StatusCode;
            this.StatusName = user.StatusName;
            this.LastAccess = user.LastAccess;
            this.AccessCount = user.AccessCount;
            this.Enabled = user.Enabled;
            this.Avatar = user.Avatar;
            this.Note = user.Note;
        }
    }
}
