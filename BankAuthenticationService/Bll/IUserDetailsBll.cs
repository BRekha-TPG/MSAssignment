using BankAuthenticationService.Model;

namespace BankAuthenticationService.Bll
{
    public interface IUserDetailsBll
    {
        public Task<User> GetUserAsync(string userId, string password);

        public Task<User> CreateUserAsync(User userDetails);
        public Task<bool> ActivateUser(string userId);
    }
}
