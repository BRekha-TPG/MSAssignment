using BankAuthenticationService.Bll;
using BankAuthenticationService.Model;
using Identity.WebApi.Services;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotificationContracts.DataContracts;
using System.Security.Claims;
using TransactionService.Controllers;
using TransactionService.Model;

namespace BankAuthenticationService.Controllers
{
    [Route("api/user/[controller]")]
    [ApiController]
    public class AuthenticateController : Controller
    {
        private IUserService _userService;
        private IUserDetailsBll _userDetailsBll;

        private readonly ILogger<TransactionController> _logger;
        public readonly IPublishEndpoint _publishEndpoint;

        public AuthenticateController(IUserService userService, IUserDetailsBll userDetailsBll, IPublishEndpoint publishEndpoint, ILogger<TransactionController> logger)
        {
            _userService = userService;
            _userDetailsBll = userDetailsBll;
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var authResult = await _userService.Authenticate(login.UserName, login.Password);

            if(!authResult.IsActive)
                return BadRequest(new { message = "User is not active. Contatact Bank Administrator" });
            if (string.IsNullOrEmpty(authResult.auth_token))
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(authResult.auth_token);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var userRegistered = await _userDetailsBll.CreateUserAsync(user);

            if (userRegistered == null)
                return BadRequest(new { message = "Registreation Failed" });

            await _publishEndpoint.Publish<INewCustomer>(new NewCustomer()
            {
                CustomerId = Convert.ToInt32(user.UserId),
                CustomerName = user.UserName,
            });
            return Ok("User Registered Succesfully :" + userRegistered.UserName);
        }

        [HttpPut]
        [Route("ActivateUser")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> ActivateUser(string userId)
        {
            var userActivated = await _userDetailsBll.ActivateUser(userId);

            if (!userActivated)
                return BadRequest(new { message = "Failed to Activate user." });

            await _publishEndpoint.Publish<IActivateCustomer>(new ActivateCustomer()
            {
                CustomerId = Convert.ToInt32(userId),
                IsActive = userActivated,
            });
            return Ok("User Registered Succesfully :" + userId);
        }
    }
}