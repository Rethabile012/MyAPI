using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("registration")]
        public string Registration(Registration registration)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DocumentsDB").ToString()))
            {
                string query = "INSERT INTO dbo.Registration(FName, LName, Email, Password) VALUES(@FName, @LName, @Email, @Password)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters to the SQL command
                    cmd.Parameters.AddWithValue("@FName", registration.FName);
                    cmd.Parameters.AddWithValue("@LName", registration.LName);
                    cmd.Parameters.AddWithValue("@Email", registration.Email);
                    cmd.Parameters.AddWithValue("@Password", registration.Password);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();

                    if (i > 0)
                    {
                        return "Data inserted";
                    }
                    else
                    {
                        return "Error";
                    }
                }
            }
        }
    }
}
