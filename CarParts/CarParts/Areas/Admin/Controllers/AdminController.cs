namespace CarParts.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static Common.GlobalConstants.AdminUser;

    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class AdminController : Controller
    {

    }
}
