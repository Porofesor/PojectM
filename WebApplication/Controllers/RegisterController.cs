using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
