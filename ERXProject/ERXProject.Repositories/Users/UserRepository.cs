using ERXProject.Core.Users;
using OpenERX.Repositories.Shared.Sql;
using System.Data.SqlClient;
using System.Text;

namespace ERXProject.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlConnectionProvider _connection;
        public UserRepository(SqlConnectionProvider connection)
        {
            this._connection = connection;
        }

        public async Task<User> InsertAsync(User user)
        {
            try
            {
                var queryString = new StringBuilder()
                .AppendLine("INSERT INTO [TB_USERS]")
                .AppendLine(" (")
                .AppendLine("[id],")
                .AppendLine("[code],")
                .AppendLine("[name],")
                .AppendLine("[access_key],")
                .AppendLine("[password],")
                .AppendLine("[email],")
                .AppendLine("[phone],")
                .AppendLine("[type_code],")
                .AppendLine("[type_name],")
                .AppendLine("[profile_code],")
                .AppendLine("[profile_name],")
                .AppendLine("[status_code],")
                .AppendLine("[status_name],")
                .AppendLine("[last_access],")
                .AppendLine("[access_count],")
                .AppendLine("[enabled],")
                .AppendLine("[avatar],")
                .AppendLine("[note]")
                .AppendLine(" )")
                .AppendLine(" VALUES")
                .AppendLine(" (")
                .AppendLine("@id,")
                .AppendLine("@code,")
                .AppendLine("@name,")
                .AppendLine("@access_key,")
                .AppendLine("@password,")
                .AppendLine("@email,")
                .AppendLine("@phone,")
                .AppendLine("@type_code,")
                .AppendLine("@type_name,")
                .AppendLine("@profile_code,")
                .AppendLine("@profile_name,")
                .AppendLine("@status_code,")
                .AppendLine("@status_name,")
                .AppendLine("@last_access,")
                .AppendLine("@access_count,")
                .AppendLine("@enabled,")
                .AppendLine("@avatar,")
                .AppendLine("@note")
                .AppendLine(" )");

                using var connection = await this._connection.CreateConnectionAsync();
                var query = connection.CreateCommand();
                query.CommandText = queryString.ToString();

                this.SetParameters(user, query);
                query.Parameters.Add(new SqlParameter("@code", await this.GetInsertCodeAsync()));

                await query.ExecuteNonQueryAsync();

                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<User> GetAsync(Guid id)
        {
            try
            {
                var queryString = new StringBuilder()
                .AppendLine(" SELECT * FROM [TB_USERS]")
                .AppendLine(" WHERE [id] = @id");

                using var connection = await this._connection.CreateConnectionAsync();
                var query = connection.CreateCommand();

                query.CommandText = queryString.ToString();

                query.Parameters.Add(new SqlParameter("@id", id));

                var dataReader = await query.ExecuteReaderAsync();

                User user = null;

                while (dataReader.Read())
                {
                    user = LoadDataReader(dataReader);
                }

                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<User> GetAsync(string accessKey)
        {
            try
            {
                var queryString = new StringBuilder()
                .AppendLine("SELECT * FROM [TB_USERS]")
                .AppendLine("WHERE [access_key] = @access_key");

                using var connection = await this._connection.CreateConnectionAsync();

                var query = connection.CreateCommand();
                query.CommandText = queryString.ToString();
                query.Parameters.Add(new SqlParameter("@access_key", accessKey));

                var dataReader = await query.ExecuteReaderAsync();

                User user = null;

                while (dataReader.Read())
                {
                    user = LoadDataReader(dataReader);
                }

                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private void SetParameters(User user, SqlCommand query)
        {
            query.Parameters.Add(new SqlParameter("@id", user.Id.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@name", user.Name.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@access_key", user.AccessKey.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@password", user.Password.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@email", user.Email.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@phone", user.Phone.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@type_code", user.TypeCode.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@type_name", user.TypeName.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@profile_code", user.ProfileCode.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@profile_name", user.ProfileName.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@status_code", user.StatusCode.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@status_name", user.StatusName.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@last_access", user.LastAccess.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@access_count", user.AccessCount.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@enabled", user.Enabled.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@avatar", user.Avatar.GetDbValue()));
            query.Parameters.Add(new SqlParameter("@note", user.Note.GetDbValue()));
        }

        private async Task<int> GetInsertCodeAsync()
        {
            var queryString = new StringBuilder()
                .AppendLine(" SELECT COUNT(*)")
                .AppendLine(" FROM TB_USERS");

            var connection = await this._connection.CreateConnectionAsync();
            var query = connection.CreateCommand();

            query.CommandText = queryString.ToString();

            var code = Convert.ToInt32(await query.ExecuteScalarAsync());

            code++;

            return code;
        }

        private static User LoadDataReader(SqlDataReader dataReader)
        {
            var user = new User();

            user.Id = dataReader.GetGuid("id");
            user.Code = dataReader.GetInt32("code");
            user.Name = dataReader.GetString("name");
            user.AccessKey = dataReader.GetString("access_key");
            user.Password = dataReader.GetString("password");
            user.Email = dataReader.GetString("email");
            user.Phone = dataReader.GetString("phone");
            user.TypeCode = dataReader.GetInt32("type_code");
            user.TypeName = dataReader.GetString("type_name");
            user.ProfileName = dataReader.GetString("profile_name");
            user.StatusCode = dataReader.GetInt32("status_code");
            user.StatusName = dataReader.GetString("status_name");
            user.LastAccess = dataReader.GetDateTime("last_access");
            user.AccessCount = dataReader.GetInt32("access_count");
            user.Enabled = dataReader.GetBoolean("enabled");
            user.Avatar = dataReader.GetString("avatar");
            user.Note = dataReader.GetString("note");

            return user;
        }
    }
}
