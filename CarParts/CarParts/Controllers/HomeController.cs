namespace CarParts.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using ViewModels.Error;

    public class HomeController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IDealerService _dealerService;
        private readonly ICarService _carService;

        public HomeController(IUserService userService, IDealerService dealerService, ICarService carService)
        {
            _userService = userService;
            _dealerService = dealerService;
            _carService = carService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}