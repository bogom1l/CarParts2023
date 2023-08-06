namespace CarParts.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;

    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> AddMoney()
        {
            try
            {
                await _userService.AddMoneyAsync(GetUserId());

                TempData["SuccessMessage"] = "You added 100 euro to your balance!";
                return RedirectToAction("EditAccountSettings", "Dashboard", new { id = GetUserId() });
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ResetMoney()
        {
            try
            {
                await _userService.ResetMoneyAsync(GetUserId());

                TempData["SuccessMessage"] = "You have successfully reset your balance!";
                return RedirectToAction("EditAccountSettings", "Dashboard", new { id = GetUserId() });
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddCustomAmountMoney(double amount)
        {
            try
            {
                await _userService.AddCustomAmountMoneyAsync(GetUserId(), amount);

                TempData["SuccessMessage"] = $"You added {amount} euro to your balance!";
                return RedirectToAction("EditAccountSettings", "Dashboard", new { id = GetUserId() });
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        private IActionResult GeneralError()
        {
            TempData["ErrorMessage"] =
                "Unexpected error occurred! Please try again later or contact administrator.";

            return RedirectToAction("Index", "Home");
        }
    }
}