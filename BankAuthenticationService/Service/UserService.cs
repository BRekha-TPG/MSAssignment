using BankAuthenticationService.Bll;

namespace Identity.WebApi.Services
{
    using BankAuthenticationService.Model;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public interface IUserService
    {
        Task<AuthResult> Authenticate(string userId, string password);
    }

    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserDetailsBll _userDetailsBll;

        public UserService(IOptions<AppSettings> appSettings,IUserDetailsBll userDetailsBll)
        {
            _appSettings = appSettings.Value;
            _userDetailsBll = userDetailsBll;
        }

        public async Task<AuthResult> Authenticate(string userId, string password)
        {
            var user =  await _userDetailsBll.GetUserAsync(userId, password);
            
            //return null if user not found
            if (user == null)
                return null;

            if (!user.IsActive)
                return new AuthResult() {auth_token = string.Empty, IsActive = false };

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("AccountNumber", user.AccountNumber.ToString()),
                    new Claim(ClaimTypes.Role, user.UserRole.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim("UserId", user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _appSettings.ValidAudience,
                Issuer = _appSettings.ValidIssuer,
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtSecurityToken =  tokenHandler.WriteToken(token);

            return new AuthResult()
            { auth_token = jwtSecurityToken, IsActive = true};
        }
    }
}
