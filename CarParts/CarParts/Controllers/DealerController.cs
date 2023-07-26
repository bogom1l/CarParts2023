using CarParts.Services.Data.Interfaces;

namespace CarParts.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class DealerController : BaseController
    {
        private readonly IDealerService _dealerService;

        public DealerController(IDealerService dealerService)
        {
            _dealerService = dealerService;
        }

        [HttpGet]
        public async Task<IActionResult> BecomeDealer()
        {
            bool isDealer = await this._dealerService.AgentExistsByUserIdAsync(GetUserId());

            if (isDealer)
            {
                TempData["ErrorMessage"] = "You are already a dealer!";

                return RedirectToAction("Index", "Home");
            }

            return View();
        }




    }
}
