namespace CarParts.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Services.Data.Interfaces;
    using ViewModels.User;
    using static Common.GlobalConstants.AdminUser;

    public class UserController : AdminController
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IMemoryCache memoryCache)
        {
            _userService = userService;
            _memoryCache = memoryCache;
        }

        public async Task<IActionResult> All()
        {
            var users = _memoryCache.Get<ICollection<UserViewModel>>(UsersCacheKey);

            if (users == null)
            {
                users = await _userService.GetAllUsersAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(UsersCacheExpirationTimeInMinutes));

                _memoryCache.Set(UsersCacheKey, users, cacheOptions);
            }

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAllReviews()
        {
            try
            {
                await _userService.DeleteAllReviewsAsync();

                TempData["SuccessMessage"] = "You have successfully deleted all reviews!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAllReviewsForCar(int id)
        {
            try
            {
                await _userService.DeleteAllReviewsForCarAsync(id);

                TempData["SuccessMessage"] = $"You have successfully deleted all reviews for car with id: {id}!";
                return RedirectToAction("All", "Car", new { area = "" });
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