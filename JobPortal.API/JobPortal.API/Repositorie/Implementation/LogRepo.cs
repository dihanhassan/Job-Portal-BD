using Dapper;
using JobPortal.API.Models.Data;
using JobPortal.API.Models.Log;
using JobPortal.API.Models.Response;
using JobPortal.API.Repositorie.Interface;

namespace JobPortal.API.Repositorie.Implementation
{
    public class LogRepo : ILogRepo
    {
        private readonly DapperDBConnection _dbConnection;

        public LogRepo (DapperDBConnection dbConnection)
        {
            _dbConnection = dbConnection;  
        }
        public async Task<int> CreateLog(CustomLog log)
        {
            try
            {

                using (var connection = _dbConnection.CreateConnection())
                {
                    string query = @"INSERT INTO ACTIVITY_LOG (UserID, ActionTime, ActionType, ActionField, jsonPayload)
                                      VALUES ( @UserID, GETDATE(), @ActionType, @ActionField, @JsonPayload);";



                    return await connection.ExecuteAsync(query,log);

                }


            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

       
    }
}
