using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleWebServiceLate.Service;

namespace YouAreLate.Controllers
{
    public class LoginController : Controller
    {

        private LateService service = new LateService();

        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Authentificate(IFormCollection collection)
        {

            string login = collection["form-username"];
            string password = collection["form-password"];

            if(!string.IsNullOrEmpty(login) || !string.IsNullOrEmpty(password))
            {
                if(service.AuthentificateUser(login, password) != null)
                {
                    return RedirectToAction("Home/Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

    }
}