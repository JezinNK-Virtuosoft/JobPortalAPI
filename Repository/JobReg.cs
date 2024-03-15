using JobPortalAPI.Model;
using System.Data;
using System.Data.SqlClient;

namespace JobPortalAPI.Repository
{
    public class JobReg:IJobReg
    {
        private readonly IConfiguration _configuration;
        public JobReg(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool InsertJobseekers(Jobseekers jobseekers)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_InsertJobseeker", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@SFirstName", jobseekers.SFirstName);
                    if (string.IsNullOrEmpty(jobseekers.SMiddleName))
                    {
                        command.Parameters.AddWithValue("@SMiddleName", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@SMiddleName", jobseekers.SMiddleName);
                    }

                    command.Parameters.AddWithValue("@SLastName", jobseekers.SLastName);
                    command.Parameters.AddWithValue("@Email", jobseekers.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", jobseekers.PhoneNumber);
                    command.Parameters.AddWithValue("@DateOfBirth", jobseekers.DateOfBirth);
                    command.Parameters.AddWithValue("@WorkStatus", jobseekers.WorkStatus);

                    int NumberofRows = (int)command.ExecuteNonQuery();
                    if (NumberofRows > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }
    }
}
