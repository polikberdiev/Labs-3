using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Lab6.BL.Services;
using Lab6.Domain.Models;
using Lab6.Filters;
using Microsoft.AspNetCore.Mvc;
using Lab6.Models.FormModels.Home;
using Lab6.Models.ViewModels;
using Lab6.Models.ViewModels.Home;

namespace Lab6.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly IAccountTypeService _accountTypeService;


        public HomeController(
            IAccountService accountService,
            IUserService userService,
            IAccountTypeService accountTypeService)
        {
            _accountService = accountService;
            _userService = userService;
            _accountTypeService = accountTypeService;
        }


        // MVC GET page
        [HttpGet]
        public async Task<IActionResult> Accounts(int pageId)
        {
            var accounts = await _accountService.GetAccountsAsync(pageId);

            return View(new AccountsViewModel(accounts));
        }

        // MVC GET page
        [HttpGet]
        public async Task<IActionResult> Account(Guid accountId)
        {
            var account = await _accountService.GetAccountAsync(accountId);

            return View(new AccountViewModel(account));
        }

        // MVC POST form
        [HttpPost]
        [ValidateModelFilter]
        public async Task<IActionResult> AddFunds([FromForm] AddFundsFormModel model)
        {
            // ReSharper disable once PossibleInvalidOperationException
            var value = model.Value.Value * (model.IsSubtracting ? -1 : 1);
            await _accountService.AddFundsAsync(model.AccountId, (decimal)value);

            var account = await _accountService.GetAccountAsync(model.AccountId);

            return Json(account);
        }

        // MVC GET page
        [HttpGet]
        public async Task<IActionResult> AddAccount()
        {
            var users = await _userService.GetUsersAsync();
            var accountTypes = await _accountTypeService.GetAccountTypesAsync();

            return View(new AddAccountViewModel(users, accountTypes));
        }

        // MVC POST form
        [HttpPost]
        [ValidateModelFilter]
        public async Task<IActionResult> AddAccount([FromForm] AddAccountFormModel model)
        {
            var addingAccount = new AccountModel
            {
                // ReSharper disable once PossibleInvalidOperationException
                OwnerUserId = model.OwnerUserId.Value,
                // ReSharper disable once PossibleInvalidOperationException
                AccountTypeId = model.AccountTypeId.Value,
                Number = model.Number
            };
            var account = await _accountService.AddAccountAsync(addingAccount);

            return Json(account);
        }

        // WebAPI POST
        [HttpPost("close-account/{accountId:guid}")]
        public async Task<IActionResult> CloseAccount(Guid accountId)
        {
            await _accountService.RemoveAccountAsync(accountId);

            return Json(new { Success = true });
        }


        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
