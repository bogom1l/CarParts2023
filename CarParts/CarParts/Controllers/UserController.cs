namespace CarParts.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using ViewModels.Car;

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

            TempData["SuccessMessage"] = "You added 100euro to your balance.!";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveMoney(RentCarViewModel rentCarViewModel)
        {
            await _userService.RemoveMoney(GetUserId(), 1); //TODO:?? kade go polzwam twa izobshto

            return null!; //TODO: ? //return RedirectToAction("Index", "Home");
        }
    }
}