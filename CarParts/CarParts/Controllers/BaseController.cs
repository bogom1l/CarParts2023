namespace CarParts.Web.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class BaseController : Controller
    {
        protected string GetUserId()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return id;
        }
    }
}