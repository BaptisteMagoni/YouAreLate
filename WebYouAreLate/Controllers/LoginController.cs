using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleWebServiceLate.Service;
using ServiceReferenceLate;
using System.Collections.Generic;
using System.Security.Claims;
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
        public IActionResult Authentificate(IFormCollection collection)
        {
            if (!string.IsNullOrEmpty(collection["form-username"]) && !string.IsNullOrEmpty(collection["form-password"]))
            {
                string username = collection["form-username"];
                string password = collection["form-password"];

                UserDTO userDTO = late.AuthentificateUser(username, password);

                if (userDTO != null)
                {

                    var userClaims = new List<Claim>
                    {
                        new Claim("UserID", userDTO.identifiant)
                    };

                    //    var licenseClaims = new List<Claim>()
                    //{
                    //    new Claim(ClaimTypes.Name, "Bob K Foo"),
                    //    new Claim("DrinvingLicense", "A+"),
                    //};

                    var userIdenity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { userIdenity });

                    HttpContext.SignInAsync(userPrincipal);

                    return Redirect("/Home");
                }

            }
            return RedirectToAction("Index");
        }

       //[HttpPost]
       // public ActionResult Index(LoginModel viewModel, string returnUrl)
       // {

       //     UserDTO userDTO = late.AuthentificateUser(viewModel.userDTO.identifiant, viewModel.userDTO.password);

       //     if (userDTO != null)
       //     {

       //         var grandmaClaims = new List<Claim>
       //         {
       //             new Claim(ClaimTypes.Name, viewModel.userDTO.identifiant),
       //             new Claim("Grandma.Says", "Suce ma bite")
       //         };

       //         var licenseClaims = new List<Claim>()
       //         {
       //             new Claim(ClaimTypes.Name, "Bob K Foo"),
       //             new Claim("DrinvingLicense", "A+"),
       //         };

       //         var grandmaIdentity = new ClaimsIdentity(grandmaClaims, "Grandma Identity");
       //         var licenseIdentity = new ClaimsIdentity(licenseClaims, "Government");

       //         var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity, licenseIdentity });

       //         HttpContext.SignInAsync(userPrincipal);

       //         return RedirectToAction("Home");
       //     }

       //     return View("Login/Index");
       // }

        [Authorize]
        public ActionResult Home()
        {
            return View();
        }

    }
}