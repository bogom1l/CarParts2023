namespace CarParts.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;

    public class RentController : AdminController
    {
        private readonly IRentService _rentService;

        public RentController(IRentService rentService)
        {
            _rentService = rentService;
        }

        public async Task<IActionResult> All()
        {
            var rents = await _rentService.GetAllRentsAsync();
            return View(rents);
        }
    }
}