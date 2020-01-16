using Microsoft.AspNetCore.Mvc;

namespace YouAreLate.Controllers
{
    public class LoginController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}