using Dapper;
using JobPortal.API.Models;
using JobPortal.API.Models.Data;
using JobPortal.API.Repositorie.Interface;

namespace JobPortal.API.Repositorie.Implementation
{
    public class ViewApplicantRepo : IViewApplicantRepo
    {
        private readonly DapperDBConnection _dBconnection;
        public ViewApplicantRepo(DapperDBConnection dBConnection)
        {
             _dBconnection = dBConnection;
        }
        public async Task<List<ApplicantInfoModel>> GetApplicantInfo(string UserID, int PostID)
        {
            try
            {
                List<ApplicantInfoModel> ApplicantInfo = new List<ApplicantInfoModel>();
                using (var connection = _dBconnection.CreateConnection())
                {
                    string query = @"SELECT 
                                    ap.[EmployeeID],
                                    ap.[PostID],
                                    ap.[RecruiterID],
                                    ap.[AppliedDate],
                                    ap.[Experience],
                                    sp.[FirstName],
                                    sp.[LastName],
                                    sp.[Gender],
                                    sp.[Institution],
                                    sp.[MobileNumber],
                                    sp.[Skill],
                                    sp.[ResumeUrl],
                                    ut.[Email]
                                FROM 
                                    JOB_APPLY ap
                                INNER JOIN 
                                    JOB_SEEKER_PROFILE sp ON ap.[EmployeeID] = sp.[UserID]
                                INNER JOIN 
                                    UserTable ut ON ut.[UserID] = sp.[UserID]
                                WHERE 
                                    ap.[PostID] = @PostID;";


                    var UserInfo = await connection.QueryAsync<ApplicantInfoModel>(query, new { PostID = PostID});
                    ApplicantInfo = UserInfo.ToList();   
                }
                return ApplicantInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}
