using CarParts.Services.Data.Interfaces;
using CarParts.Web.ViewModels.Car;

namespace CarParts.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
       
        [HttpGet]
        public async Task<IActionResult> AddMoney()
        {
            await this._userService.AddMoney(GetUserId());

            TempData["SuccessMessage"] = "You added 100euro to your balance.!";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveMoney(RentCarViewModel rentCarViewModel)
        {
            await this._userService.RemoveMoney(GetUserId(), 1); //TODO:?? kade go polzwam twa izobshto

            return null!; //TODO: ? //return RedirectToAction("Index", "Home");
        }

    }
}
