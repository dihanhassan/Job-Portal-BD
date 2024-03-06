using Dapper;
using JobPortal.API.Models;
using JobPortal.API.Models.Data;
using JobPortal.API.Repositorie.Interface;
using System.Collections.Generic;

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
                int RowsEffect = 1;

                using (var connection = _dbConnection.CreateConnection())
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string query = @"
                        INSERT INTO JOB_POSTS_HEADER (UserID, Title, Description, Vacancy, Education, Organization, Location,Compensation, EmployeeStatus, Experience, Created, DeadLine, Field)
                        VALUES (@UserID, @Title, @Description, @Vacancy, @Education, @Organization, @Location,@Compensation, @EmployeeStatus, @Experience, @Created, @DeadLine, @Field)";

                            RowsEffect = await connection.ExecuteAsync(query, jobPost, transaction);


                            for (int i = 0; i < jobPost.Responsibilities.Length; i++)
                            {
                                string Responsibilities = jobPost.Responsibilities[i].ToString();
                                string queryNew = @"
                            INSERT INTO JOB_POSTS_RESPONSIBILITY (UserID,Responsibilities)
                            VALUES (@UserID,@Responsibilities)";

                                RowsEffect &= await connection.ExecuteAsync(queryNew, jobPost, transaction);
                            }

                            for (int i = 0; i < jobPost.Requirements.Length; i++)
                            {
                                string Requirement = jobPost.Requirements[i].ToString();
                                string queryNew = @"
                              INSERT INTO JOB_POSTS_REQUIREMENTS (UserID,Responsibilities)
                              VALUES (@UserID,@Requirement)";

                                RowsEffect &= await connection.ExecuteAsync(queryNew, jobPost, transaction);
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();

                            throw new Exception(ex.Message);


                        }
                    }
                   


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
                    string query = @"SELECT * FROM JOB_POSTS_HEADER";
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
