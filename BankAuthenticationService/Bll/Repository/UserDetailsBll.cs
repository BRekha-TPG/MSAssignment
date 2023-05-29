using BankAuthenticationService.Dal;
using BankAuthenticationService.Model;

namespace BankAuthenticationService.Bll.Repository
{
    public class UserDetailsBll : IUserDetailsBll
    {
        private readonly IUserDetailsDal _userDetailsDal;
        public UserDetailsBll(IUserDetailsDal userDetailsDal) 
        {
            _userDetailsDal = userDetailsDal;
        }

        public Task<bool> ActivateUser(string userId)
        {
            return _userDetailsDal.ActivateUser(userId);
        }

        public Task<User> CreateUserAsync(User userDetails)
        {
            return _userDetailsDal.CreateUserAsync(userDetails);
        }

        public Task<User> GetUserAsync(string userId, string password)
        {
            return _userDetailsDal.GetUserAsync(userId, password);
        }
    }
}
