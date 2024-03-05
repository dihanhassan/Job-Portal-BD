using Dapper;
using JobPortal.API.Models;
using JobPortal.API.Models.Data;
using JobPortal.API.Repositorie.Interface;

namespace JobPortal.API.Repositorie.Implementation
{
    public class JobPostRepo : IJobPostRepo
    {
        private readonly DapperDBConnection _dbConnection;
        public JobPostRepo(DapperDBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> AddJobPost(JobPostModel jobPost)
        {
            try
            {
                int RowsEffect = 0;

                using (var connection = _dbConnection.CreateConnection())
                {
                    string query = @"
                    INSERT INTO JOB_POSTS (UserID, Title, Description, Vacancy, Education, Organization, Location, EmployeeStatus, Experience, Created, DeadLine, Field)
                    VALUES (@UserID, @Title, @Description, @Vacancy, @Education, @Organization, @Location, @EmployeeStatus, @Experience, @Created, @DeadLine, @Field)";

                    RowsEffect = await connection.ExecuteAsync(query, jobPost);


                }
                return RowsEffect;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<JobPostModel>> GetJobPosts()
        {
           try
            {
                List<JobPostModel> jobs = new List<JobPostModel>();

               

                using (var connection = _dbConnection.CreateConnection())
                {
                    string query = @"SELECT * FROM JOB_POSTS";
                    var result = await connection.QueryAsync<JobPostModel>(query);
                    jobs = result.ToList();
                }
                return  jobs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);    
            
            }
            
        }



    }
}
