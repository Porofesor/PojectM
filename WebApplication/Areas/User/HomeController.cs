using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApplication.Areas.Client
{
    public class HomeController : Controller
    {
        //<summary>
        // Basic way of attempting login in
        //</summary>
        [HttpPost("mvc/login")]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignInAsync(new ClaimsPrincipal(
                new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
                    })
                ));
            return Ok();
        }
    }
}
