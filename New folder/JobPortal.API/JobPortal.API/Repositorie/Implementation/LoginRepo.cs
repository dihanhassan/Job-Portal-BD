using Dapper;
using JobPortal.API.Models.Authentication;
using JobPortal.API.Models.Data;
using JobPortal.API.Repositorie.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JobPortal.API.Repositorie.Implementation
{
    public class LoginRepo :ILoginRepo
    {
        private readonly DapperDBConnection _dbConnection;
        public LoginRepo(DapperDBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<UserLoginModel> GetUserLoginInfo(string UserName,string UserPassword)
        {
            UserLoginModel response = null;

           
            string query = "SELECT * FROM UserTable WHERE UserName = @UserName AND UserPassword = @UserPassword";


            using (var connection = _dbConnection.CreateConnection())
            {
                response = await connection.QueryFirstOrDefaultAsync<UserLoginModel>(query,new { UserName = UserName , UserPassword = UserPassword });
            }

            return  response;
        }
    }
}
