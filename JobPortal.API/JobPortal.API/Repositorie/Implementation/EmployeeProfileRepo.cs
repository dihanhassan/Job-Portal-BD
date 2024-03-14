using Dapper;
using JobPortal.API.Models;
using JobPortal.API.Models.Data;
using JobPortal.API.Repositorie.Interface;
using System.Data.Common;
using System.Reflection;

namespace JobPortal.API.Repositorie.Implementation
{
    public class EmployeeProfileRepo : IEmployeeProfileRepo
    {
        private readonly DapperDBConnection _connection;
        public EmployeeProfileRepo(DapperDBConnection dBConnection)
        {
            _connection = dBConnection;
        }
        public async Task<int> SetProfileInfo(EmployeeProfileModel profile)
        {
            try
            {
                
                string query = @"INSERT INTO JOB_SEEKER_PROFILE(UserID, FirstName, LastName, Gender, MobileNumber, Skill, Institution,ResumeUrl)
                                VALUES(@UserID, @FirstName, @LastName, @Gender, @MobileNumber, @Skill, @Institution,@ResumeUrl)";

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

        public async Task<int> UpdateProfileInfo(EmployeeProfileModel profile)
        {
            try
            {

                string query = @"UPDATE JOB_SEEKER_PROFILE
                                SET FirstName = @FirstName,
                                    LastName = @LastName,
                                    Gender = @Gender,
                                    MobileNumber = @MobileNumber,
                                    Skill = @Skill,
                                    Institution = @Institution,
                                    ResumeUrl = @ResumeUrl
                                WHERE UserID = @UserID AND ProfileId=@ProfileId;";

                int RowsCount = 0;

                using (var connection = _connection.CreateConnection())
                {

                    RowsCount = await connection.ExecuteAsync(query, profile);

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
