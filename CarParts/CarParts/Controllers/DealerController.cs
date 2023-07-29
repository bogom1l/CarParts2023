namespace CarParts.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using ViewModels.Dealer;

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
            var isDealer = await _dealerService.DealerExistsByUserIdAsync(GetUserId());

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
            var isDealer = await _dealerService.DealerExistsByUserIdAsync(GetUserId());

            if (isDealer)
            {
                TempData["ErrorMessage"] = "You are already a dealer!";
                return RedirectToAction("Index", "Home");
            }

            var isPhoneNumberTaken =
                await _dealerService.DealerExistsByPhoneNumberAsync(dealer.PhoneNumber);

            if (isPhoneNumberTaken)
            {
                TempData["ErrorMessage"] = "Dealer with the provided phone number already exists!";
                return RedirectToAction("BecomeDealer", "Dealer");
            }

            if (!ModelState.IsValid)
            {
                return View(dealer);
            }

            var userHasActiveRents = await _dealerService.HasRentsByUserIdAsync(GetUserId());

            if (userHasActiveRents)
            {
                TempData["ErrorMessage"] = "You should have no active rents in order to become a dealer!";
                return RedirectToAction("MyRentedCars", "Car");
            }

            await _dealerService.BecomeDealerAsync(dealer, GetUserId());

            TempData["SuccessMessage"] = "You are now a dealer.";
            return RedirectToAction("Index", "Home");
        }
    }
}