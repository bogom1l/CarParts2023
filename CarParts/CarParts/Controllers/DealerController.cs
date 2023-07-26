using CarParts.Services.Data.Interfaces;
using CarParts.Web.ViewModels.Dealer;

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
            bool isDealer = await this._dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (isDealer)
            {
                TempData["ErrorMessage"] = "You are already a dealer!";

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BecomeDealer(BecomeDealerFormModel dealer)
        {
            bool isDealer = await this._dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (isDealer)
            {
                TempData["ErrorMessage"] = "You are already a dealer!";

                return RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberTaken =
                await this._dealerService.DealerExistsByPhoneNumberAsync(dealer.PhoneNumber);

            if (!ModelState.IsValid)
            {
                return View(dealer);
            }

            bool userHasActiveRents = await this._dealerService.HasRentsByUserIdAsync(GetUserId());
            if (userHasActiveRents)
            {
                TempData["ErrorMessage"] = "You must not have any active rents in order to become a dealer!";

                return RedirectToAction("All", "Car");
                //TODO: return RedirectToAction("MyRentedCars", "Car");
            }

            await this._dealerService.BecomeDealerAsync(dealer, GetUserId());

            TempData["SuccessMessage"] = "You are now a dealer!";
            return RedirectToAction("Index", "Home");
        }


    }
}
