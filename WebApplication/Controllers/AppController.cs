using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
