using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleWebServiceLate.Service;
using ServiceReferenceLate;

namespace YouAreLate.Controllers
{
    public class LoginController : Controller
    {

        private LateService late = new LateService();

        // GET
        public IActionResult Index()
        {
            return View();
        }

        public void Authentificate(IFormCollection collection)
        {
            if (!string.IsNullOrEmpty(collection["username"]) && !string.IsNullOrEmpty(collection["password"]))
            {
                string username = collection["username"];
                string password = collection["password"];

                var user = late.AuthentificateUser(username, password);

            }
        }
    }
}