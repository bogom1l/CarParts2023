namespace CarParts.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;

    public class UserController : AdminController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("User/All")]
        public async Task<IActionResult> All()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }
    }
}
