using Cliente.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.Controllers
{
    [AdminOnly]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
