using JobPortalAPI.ViewModel;
using System.Data.SqlClient;
using System.Data;

namespace JobPortalAPI.Repository
{
    public class EmployerReg:IEmployerReg
    {
        private readonly IConfiguration _configuration;
        public EmployerReg(IConfiguration configuration)
        {
                _configuration = configuration;
        }
        public int AddCompanyDetails(EmployerDetails employerDetails)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_CompanyDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CompanyName", employerDetails.CompanyName);
                    command.Parameters.AddWithValue("@StartEmployeeRange", employerDetails.StartEmployeeRange);
                    command.Parameters.AddWithValue("@EndEmployeeRange", employerDetails.EndEmployeeRange);
                    command.Parameters.AddWithValue("@CAddress", employerDetails.CAddress);

                    SqlParameter outputID = new SqlParameter();
                    outputID.ParameterName = "@CompanyID";
                    outputID.SqlDbType = SqlDbType.Int;
                    outputID.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputID);

                    command.ExecuteNonQuery();

                    employerDetails.CompanyID = (int)outputID.Value;

                }
            }
            return employerDetails.CompanyID;
        }
        public bool AddEmployer(EmployerDetails employerDetails)
        {
            int NumberOfRow;
            string ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_InsertEmployer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EFirstName", employerDetails.EFirstName);
                    if (string.IsNullOrEmpty(employerDetails.EMiddleName))
                    {
                        command.Parameters.AddWithValue("@EMiddleName", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@EMiddleName", employerDetails.EMiddleName);
                    }

                    command.Parameters.AddWithValue("@ELastName", employerDetails.ELastName);
                    command.Parameters.AddWithValue("@Email", employerDetails.Email);
                    command.Parameters.AddWithValue("@Designation", employerDetails.Designation);
                    command.Parameters.AddWithValue("@PhoneNumber", employerDetails.PhoneNumber);
                    if (employerDetails.CompanyID == 0)
                    {
                        command.Parameters.AddWithValue("@CompanyID", AddCompanyDetails(employerDetails));
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@CompanyID", employerDetails.CompanyID);
                    }

                    NumberOfRow = command.ExecuteNonQuery();


                }
            }
            if (NumberOfRow > 0)
            {
                return true;
            }
            return false;
        }
    }
}
