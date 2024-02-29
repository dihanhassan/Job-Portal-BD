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
            string query = @"INSERT INTO Users (UserName, Email, UserPassword, UserType, RegistrationDate, IsActive)
                         VALUES (@UserName, @Email, @UserPassword, @UserType, @RegistrationDate, @IsActive)";

            int RowsCount = 0;
            user.IsActive = false;
            using (var connection = _connection.CreateConnection())
            {

                RowsCount = await connection.ExecuteAsync(query, user);

            }
            return  RowsCount;

        }
    }
}
