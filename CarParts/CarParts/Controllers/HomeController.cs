namespace CarParts.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using ViewModels.Statistics;

    public class HomeController : BaseController
    {
        private readonly IStatisticsService _statisticsService;

        public HomeController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var statistics = new StatisticsViewModel
            {
                TotalCars = await _statisticsService.GetTotalCars(),
                TotalParts = await _statisticsService.GetTotalParts(),
                TotalUsers = await _statisticsService.GetTotalUsers(),
                TotalDealers = await _statisticsService.GetTotalDealers(),
                TotalRents = await _statisticsService.GetTotalRents()
            };

            return View(statistics);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return View("Error404");
            }

            return View();
        }

        [AllowAnonymous]
        public IActionResult Contacts()
        {
            return View();
        }
    }
}