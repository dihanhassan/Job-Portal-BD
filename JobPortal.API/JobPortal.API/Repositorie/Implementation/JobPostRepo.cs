using Dapper;
using JobPortal.API.Models;
using JobPortal.API.Models.Data;
using JobPortal.API.Repositorie.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                                
                                string queryNew = @"
                                INSERT INTO JOB_POSTS_RESPONSIBILITY (UserID,Responsibilities)
                                VALUES (@UserID,@Responsibilities)";

                                RowsEffect &= await connection.ExecuteAsync(queryNew, new { UserID = jobPost.UserID, Responsibilities = jobPost.Responsibilities[i].ToString() }, transaction);
                            }

                            for (int i = 0; i < jobPost.Requirements.Length; i++)
                            {
                             
                                string queryNew = @"
                                INSERT INTO JOB_POSTS_REQUIREMENTS (UserID,Requirements)
                                VALUES (@UserID,@Requirements)";

                                RowsEffect &= await connection.ExecuteAsync(queryNew, new { UserID  = jobPost.UserID, Requirements = jobPost.Requirements[i].ToString() }, transaction);
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

                    connection.Open();

                    using (var reader = await connection.ExecuteReaderAsync(query))
                    {
                        while ( reader.Read())
                        {
                            // Assuming UserID is an int, adjust the type accordingly
                            JobPostModel jobPost = new JobPostModel();
                            jobPost.postID = reader.GetInt32(0);
                            jobPost.UserID = reader.GetString(1);
                            jobPost.Title = reader.GetString(2);
                            jobPost.Description = reader.GetString(3);
                            jobPost.Vacancy = reader.GetInt32(4);
                            jobPost.Education = reader.GetString(5);
                            jobPost.Organization = reader.GetString(6);
                            jobPost.Location = reader.GetString(7);
                            jobPost.Compensation = reader.GetString(8);
                            jobPost.EmployeeStatus  = reader.GetString(9);
                            jobPost.Experience = reader.GetString(10);
                            jobPost.Created=reader.GetDateTime(11);
                            jobPost.DeadLine = reader.GetDateTime(12);
                            jobPost.Field = reader.GetString(13);

                            // querry for Requirement

                            string queryReq = @"SELECT Requirements 
                                                FROM JOB_POSTS_REQUIREMENTS 
                                                WHERE  postID = @postID";
                            using (var readr2 = await connection.ExecuteReaderAsync(queryReq, new { postID = jobPost.postID }))
                            {
                                List<string> requirement = new List<string>(); 
                                while ( readr2.Read())
                                {
                                    requirement.Add(readr2.GetString(0));
                                }
                                jobPost.Requirements= requirement.ToArray();
                            }

                            string queryRes = @"SELECT Responsibilities 
                                                FROM JOB_POSTS_RESPONSIBILITY
                                                WHERE  postID = @postID";
                            using (var readr3 = await connection.ExecuteReaderAsync(queryRes, new { postID = jobPost.postID }))
                            {
                                List<string> responsibilities = new List<string>();
                                while (readr3.Read())
                                {
                                    responsibilities.Add(readr3.GetString(0));
                                }
                                jobPost.Responsibilities = responsibilities.ToArray();
                            }


                            jobs.Add(jobPost);



                            // Do something with the userId, for example, add it to a list
                            // userIds.Add(userId);
                        }
                    }
                    /*var result = await connection.QueryAsync<JobPostModel>(query);
                    jobs = result.ToList();*/
                    
                  

                    
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
