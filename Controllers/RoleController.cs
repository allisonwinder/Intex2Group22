using Intex2Group22.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Intex2Group22.Controllers
{
    public class RoleController : Controller
    {
        [Authorize(Policy = "EmployeeOnly")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = $"{RoleConstants.Roles.Administrator}")]
        public IActionResult Admin()
        {
            return View();
        }
    }
}
