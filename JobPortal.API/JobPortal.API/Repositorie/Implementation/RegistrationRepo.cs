using Dapper;
using JobPortal.API.Models.Authentication;
using JobPortal.API.Models.Data;
using JobPortal.API.Repositorie.Interface;

namespace JobPortal.API.Repositorie.Implementation
{
    public class RegistrationRepo : IRegistrationRepo
    {
        private readonly DapperDBConnection _connection;
        public RegistrationRepo(DapperDBConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> RegisterUser(UserRegistrationModel user)
        {
           
           try
            {
                user.UserID = Guid.NewGuid().ToString();
                string query = @"INSERT INTO UserTable (UserID, UserName, Email, UserPassword, UserType, RegistrationDate, IsActive)
                         VALUES (@UserID, @UserName, @Email, @UserPassword, @UserType, @RegistrationDate, @IsActive)";


                int RowsCount = 0;
                user.IsActive = false;
                user.RegistrationDate = DateTime.Now;

                using (var connection = _connection.CreateConnection())
                {

                    RowsCount = await connection.ExecuteAsync(query, user);

                }
                return RowsCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
