using Dapper;
using JobPortal.API.Models.Authentication;
using JobPortal.API.Models.Data;
using JobPortal.API.Repositorie.Interface.Authentication;

namespace JobPortal.API.Repositorie.Implimentation.Authentication
{
    public class RegistrationRepo : IRegistrationRepo
    {
        private readonly DapperDBConnection _connection;
        public RegistrationRepo(DapperDBConnection connection)
        {
            _connection = connection;
        }
        public int RegisterUser(UserRegistrationModel user)
        {
            string query = @"INSERT INTO Users (UserName, Email, UserPassword, UserType, RegistrationDate, IsActive)
                         VALUES (@UserName, @Email, @UserPassword, @UserType, @RegistrationDate, @IsActive)";

            int RowsCount = 0;
            using (var connection = this._connection.CreateConnection())
            {

                RowsCount = connection.Execute(query, user);

            }
            return RowsCount;

        }
    }
}
