using System.Data;
using BankAuthenticationService.Model;
using Microsoft.Data.SqlClient;

namespace BankAuthenticationService.Dal.Repository
{
    public class UserDetailsDal : IUserDetailsDal
    {
        private readonly IConfiguration _configuration;
        public UserDetailsDal(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ActivateUser(string userId)
        {
            try
            {
                var connectionstring = _configuration.GetConnectionString("ConnStr");

                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("ActivateUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@userId", userId));

                    var activated = cmd.ExecuteNonQuery();
                    if (activated > 0)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<User> CreateUserAsync(User userDetails)
        {
            try
            {
                var connectionstring = _configuration.GetConnectionString("ConnStr");

                User user = null;
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CreateUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@userId", userDetails.UserId));
                    cmd.Parameters.Add(new SqlParameter("@userName", userDetails.UserName));
                    cmd.Parameters.Add(new SqlParameter("@password", userDetails.Password));
                    cmd.Parameters.Add(new SqlParameter("@email", userDetails.Email));
                    cmd.Parameters.Add(new SqlParameter("@userRole", userDetails.UserRole));
                    cmd.Parameters.Add(new SqlParameter("@accountNumber", userDetails.AccountNumber));
                    cmd.Parameters.Add(new SqlParameter("@mobileNumber", userDetails.MobileNumber));
                    cmd.Parameters.Add(new SqlParameter("@isActive", userDetails.IsActive));

                    var registered = cmd.ExecuteNonQuery();
                    if (registered > 0)
                    {
                        user = new User()
                        {
                            UserName = userDetails.UserName,
                            AccountNumber = userDetails.AccountNumber
                        };
                    }
                }

                return user;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<User> GetUserAsync(string userId, string password)
        {
            try
            {
                var connectionstring = _configuration.GetConnectionString("ConnStr");

                User user = null;
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetUserDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@userId", userId));
                    cmd.Parameters.Add(new SqlParameter("@password", password));

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        user = new User
                        {
                            UserName = dr["UserName"].ToString(),
                            UserId = dr["UserId"].ToString(),
                            AccountNumber = Convert.ToInt64(dr["AccountNumber"]),
                            UserRole = (UserRole)Enum.ToObject(typeof(UserRole), dr["UserRole"]),
                            MobileNumber = dr["MobileNumber"].ToString(),
                            Email = dr["Email"].ToString(),
                            IsActive = Convert.ToBoolean(dr["IsActive"])
                        };
                    }

                    return user;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
