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

        [Route("User/All")]
        public async Task<IActionResult> All()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAllReviews()
        {
            await _userService.DeleteAllReviews();
           
            TempData["SuccessMessage"] = "You have successfully deleted all reviews!";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAllReviewsForCar(int id)
        {
            await _userService.DeleteAllReviewsForCar(id);
           
            TempData["SuccessMessage"] = $"You have successfully deleted all reviews for car with id: {id}!";
            return RedirectToAction("All", "Car", new {area = ""});
        }

    }
}
