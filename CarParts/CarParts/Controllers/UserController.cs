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
            await _userService.AddMoney(GetUserId());

            TempData["SuccessMessage"] = "You added 100euro to your balance!";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> ResetMoney()
        {
            await _userService.ResetMoney(GetUserId());

            return RedirectToAction("Index", "Home");
        }

       
    }
}