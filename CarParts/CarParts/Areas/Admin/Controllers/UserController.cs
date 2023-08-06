namespace CarParts.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;

    public class UserController : AdminController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> All()
        {
            var users = await _userService.GetAllUsersAsync();
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