using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleWebServiceLate.Service;
using ServiceReferenceLate;
using WebYouAreLate.Models;


namespace YouAreLate.Controllers
{
    public class LoginController : Controller
    {

        private LateService late = new LateService();

        public IActionResult Index()
        {
            LoginModel loginModel = new LoginModel { Authentified = HttpContext.User.Identity.IsAuthenticated };
            return View(loginModel);
        }
        public void Authentificate(IFormCollection collection)
        {
            if (!string.IsNullOrEmpty(collection["form-username"]) && !string.IsNullOrEmpty(collection["form-password"]))
            {
                string username = collection["form-username"];
                string password = collection["form-password"];

                var user = late.AuthentificateUser(username, password);
                
                

            }
        }

       [HttpPost]
        public ActionResult Index(LoginModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Users user = late.AuthentificateUser(viewModel.userDTO.identifiant, viewModel.userDTO.password);
                if (user != null)
                {
                    //FormsAuthentication.SetAuthCookie(utilisateur.Id.ToString(), false);
                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    return Redirect("/");
                }
                ModelState.AddModelError("Utilisateur.Prenom", "Prénom et/ou mot de passe incorrect(s)");
            }
            return View(viewModel);
        }


    }
}