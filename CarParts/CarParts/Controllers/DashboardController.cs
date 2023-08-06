namespace CarParts.Web.Controllers
{
    using Data;
    using Data.Models;
    using Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Services.Data.Interfaces;
    using ViewModels.Dealer;
    using ViewModels.User;

    public class DashboardController : BaseController
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;

        public DashboardController(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext,
            IUserService userService)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _userService = userService;
        }


        [HttpGet]
        public async Task<IActionResult> EditAccountSettings(string id)
        {
            if (GetUserId() != id)
            {
                TempData["ErrorMessage"] = "User can only edit his own personal account.";
                return RedirectToAction("Index", "Home");
            }

            var editUserViewModel = await _dbContext.Users
                .Where(u => u.Id == id)
                .Select(u => new EditUserViewModel
                {
                    Username = u.UserName, //SHOULD NOT BE ABLE TO CHANGE
                    Email = u.Email, // SHOULD NOT BE ABLE TO CHANGE
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    PhoneNumber = u.PhoneNumber,
                    Balance = u.Balance
                })
                .FirstOrDefaultAsync();

            if (editUserViewModel == null)
            {
                TempData["ErrorMessage"] = "User with provided id does not exist!";
                return RedirectToAction("Index", "Home");
            }

            return View(editUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditAccountSettings(EditUserViewModel editUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editUserViewModel);
            }

            var currentUser = await _userManager.FindByIdAsync(User.GetId());

            if (currentUser != null)
            {
                // Update the user's account settings
                currentUser.FirstName = editUserViewModel.FirstName;
                currentUser.LastName = editUserViewModel.LastName;
                currentUser.PhoneNumber = editUserViewModel.PhoneNumber;
                if (User.IsAdmin())
                {
                    currentUser.Balance = editUserViewModel.Balance;
                }

                var result = await _userManager.UpdateAsync(currentUser);

                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Account settings updated successfully!";
                    return RedirectToAction("Index", "Home");
                }

                // Handle errors if the update failed
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(editUserViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditDealerAccountSettings(int id)
        {
            var dealer = await _dbContext.Dealers
                .Where(d => d.Id == id)
                .Select(d => new EditDealerViewModel
                {
                    Username = d.User.UserName,
                    Email = d.User.Email,
                    Address = d.Address,
                    UserId = GetUserId()
                })
                .FirstOrDefaultAsync();

            if (dealer == null)
            {
                TempData["ErrorMessage"] = "Dealer with provided id does not exist!";
                return RedirectToAction("Index", "Home");
            }

            if (GetUserId() != dealer.UserId)
            {
                TempData["ErrorMessage"] = "Dealer can only edit his personal account.";
                return RedirectToAction("Index", "Home");
            }

            return View(dealer);
        }

        [HttpPost]
        public async Task<IActionResult> EditDealerAccountSettings(EditDealerViewModel editDealerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editDealerViewModel);
            }

            var dealer = await _dbContext.Dealers
                .FirstOrDefaultAsync(d => d.UserId == editDealerViewModel.UserId);

            if (dealer != null)
            {
                dealer.Address = editDealerViewModel.Address;

                await _dbContext.SaveChangesAsync();

                TempData["SuccessMessage"] = "Dealer's account settings were updated successfully!";
                return RedirectToAction("Index", "Home");
            }

            TempData["ErrorMessage"] = "Some error has occurred. Please try again.";
            return View(editDealerViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAllReviewsForUser()
        {
            try
            {
                var reviewsCount = await _userService.GetMyReviewsCountAsync(GetUserId());

                if (reviewsCount == 0)
                {
                    TempData["ErrorMessage"] = "You have not made any reviews!";
                    return RedirectToAction("EditAccountSettings", "Dashboard", new { area = "", id = GetUserId() });
                }

                await _userService.DeleteAllReviewsForUserByIdAsync(GetUserId());

                TempData["SuccessMessage"] = $"All {reviewsCount} of your reviews were deleted successfully!";
                return RedirectToAction("EditAccountSettings", "Dashboard", new { area = "", id = GetUserId() });
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        private IActionResult GeneralError()
        {
            TempData["ErrorMessage"] =
                "Unexpected error occurred! Please try again later or contact administrator.";

            return RedirectToAction("Index", "Home");
        }
    }
}