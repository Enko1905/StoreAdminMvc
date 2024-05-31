using Microsoft.AspNetCore.Mvc;

namespace StoreAdmin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
