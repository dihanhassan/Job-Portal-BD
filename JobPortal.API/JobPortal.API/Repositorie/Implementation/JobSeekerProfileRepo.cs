using Dapper;
using JobPortal.API.Models;
using JobPortal.API.Models.Data;
using JobPortal.API.Repositorie.Interface;
using System.Data.Common;
using System.Reflection;

namespace JobPortal.API.Repositorie.Implementation
{
    public class JobSeekerProfileRepo : IJobSeekerProfileRepo
    {
        private readonly DapperDBConnection _connection;
        public JobSeekerProfileRepo(DapperDBConnection dBConnection)
        {
            _connection = dBConnection;
        }
        public async Task<int> SetProfileInfo(JobSeekerProfileModel profile)
        {
            try
            {
                
                string query = @"INSERT INTO JOB_SEEKER_PROFILE(UserID, FirstName, LastName, Gender, MobileNumber, Skill, Institution)
                                VALUES(@UserID, @FirstName, @LastName, @Gender, @MobileNumber, @Skill, @Institution)";

                int RowsCount = 0;

                using (var connection = _connection.CreateConnection())
                {

                    RowsCount = await connection.ExecuteAsync(query,profile);

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
