using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NotificationContracts.DataContracts;
using Product.API.Data;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Net;
using System.Security.Principal;
using System.Security.Claims;
using TransactionService.Model;
using TransactionService.Service;

namespace TransactionService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
   
        private readonly ILogger<TransactionController> _logger;

        private readonly ITransactonServices _context;
        public readonly IPublishEndpoint _publishEndpoint;

        AccountDbContext _accountDbContext;

        public TransactionController(ILogger<TransactionController> logger, ITransactonServices context, AccountDbContext accountDbContext, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _context = context;
            _accountDbContext = accountDbContext;
            _publishEndpoint = publishEndpoint;
        }

        [Route("CheckBalance")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Customer")]
        public async Task<AccountInformation> CheckBalance(string AccountNumber)
        {
            return await _context.CheckBalance(AccountNumber);
        }

        [Route("GetAllAcountInfo")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IEnumerable<AccountInformation>> GetAllAcountInfo()
        {
            IEnumerable<AccountInformation> accountInformation = await _context.GetAllAccountInfo();
            return accountInformation;
        }

        [Route("Deposite")]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Customer")]
        public async Task<AccountInformation> Deposite(string account, decimal amount)
        {
            var accountInformation = await _context.Deposite(account, amount);
            await _publishEndpoint.Publish<IAccountTransaction>(new AccountTransaction()
            {
                FromAccount = account,
                TransactionType = TransactionType.Deposite.ToString(),
                CurrentBalance = accountInformation.CurrentBalance
            });
            return accountInformation;
        }

        [Route("Withdraw")]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Customer")]
        public async Task<AccountInformation> Withdraw(string account, decimal amount)
        {
            var accountInformation = await _context.Withdraw(account, amount);

            await _publishEndpoint.Publish<IAccountTransaction>(new AccountTransaction()
            {
                FromAccount = account,
                TransactionType = TransactionType.Withraw.ToString(),
                CurrentBalance = accountInformation.CurrentBalance
            });
            return accountInformation;
        }

        [Route("FundTransfer")]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Customer")]
        public async Task<IEnumerable<AccountInformation>> FundTransfer(string SourceAcc, string desAcc, decimal amount)
        {
            var accountInformation = await _context.FundTransfer(SourceAcc, desAcc, amount);
            await _publishEndpoint.Publish<IAccountTransaction>(new AccountTransaction()
            {
                FromAccount = SourceAcc,
                ToAccount = desAcc,
                TransactionType = TransactionType.Transfer.ToString()
               // CurrentBalance = accountInformation
            });
            return accountInformation;
        }


    }
}