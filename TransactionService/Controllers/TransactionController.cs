using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.API.Data;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Net;
using TransactionService.Model;
using TransactionService.Service;

namespace TransactionService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
    //    private static readonly string[] Summaries = new[]
    //    {
    //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //};

        private readonly ILogger<TransactionController> _logger;

        private readonly ITransactonServices _context;

        AccountDbContext _accountDbContext;

        public TransactionController(ILogger<TransactionController> logger, ITransactonServices context, AccountDbContext accountDbContext)
        {
            _logger = logger;
            _context = context;
            _accountDbContext = accountDbContext;
        }

        [Route("CheckBalance")]
        [HttpGet]
        public async Task<AccountInformation> CheckBalance(Guid id)
        {
            return await _context.CheckBalance(id);
        }

        [Route("GetAllAcountInfo")]
        [HttpGet]
        public async Task<IEnumerable<AccountInformation>> GetAllAcountInfo()
        {
            IEnumerable<AccountInformation> accountInformation = await _context.GetAllAccountInfo();
            return accountInformation;
        }

        [Route("Deposite")]
        [HttpPost]
        public async Task<AccountInformation> Deposite(string account, decimal amount)
        {
            var accountInformation = await _context.Deposite(account, amount);
            return accountInformation;
        }

        [Route("Withdraw")]
        [HttpPost]
        public async Task<AccountInformation> Withdraw(string account, decimal amount)
        {
            var accountInformation = await _context.Withdraw(account, amount);
            return accountInformation;
        }

        [Route("FundTransfer")]
        [HttpPost]
        public async Task<IEnumerable<AccountInformation>> FundTransfer(string SourceAcc, string desAcc, decimal amount)
        {
            var accountInformation = await _context.FundTransfer(SourceAcc, desAcc, amount);
            return accountInformation;
        }


    }
}