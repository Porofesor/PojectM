using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Admin
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
