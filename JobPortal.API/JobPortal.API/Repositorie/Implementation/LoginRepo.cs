using Dapper;
using JobPortal.API.Models.Authentication;
using JobPortal.API.Models.Data;
using JobPortal.API.Repositorie.Interface;

namespace JobPortal.API.Repositorie.Implementation
{
    public class LoginRepo :ILoginRepo
    {
        private readonly DapperDBConnection _dbConnection;
        public LoginRepo(DapperDBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<UserLoginModel> GetUserLoginInfo()
        {
            UserLoginModel response = null;

           
            string query = "SELECT * FROM Users";

            using (var connection = _dbConnection.CreateConnection())
            {
                response = await connection.QueryFirstOrDefaultAsync<UserLoginModel>(query);
            }

            return  response;
        }
    }
}
