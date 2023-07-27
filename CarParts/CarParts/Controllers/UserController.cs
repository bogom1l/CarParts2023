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
       

        public async Task<IActionResult> AddMoney()
        {
            await this._userService.AddMoney(GetUserId());

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> RemoveMoney(RentCarViewModel rentCarViewModel)
        {
            await this._userService.RemoveMoney(GetUserId(), rentCarViewModel);

            return null!; //TODO: ? //return RedirectToAction("Index", "Home");
        }

    }
}
