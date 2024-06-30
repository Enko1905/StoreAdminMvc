using Microsoft.AspNetCore.Mvc;

namespace StoreAdmin.Controllers
{
    public class defaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
