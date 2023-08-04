namespace CarParts.Web.Controllers
{
    using Data;
    using Data.Models;
    using Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ViewModels.User;

    public class DashboardController : BaseController
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> EditAccountSettings(string id)
        {
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
    }
}