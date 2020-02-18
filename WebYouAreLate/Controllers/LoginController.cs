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

                UserDTO userDTO = late.AuthentificateUser(username, password); //null if credential is bad 

                if (userDTO != null)
                {

                    var userClaims = new List<Claim> //Init Cookie
                    {
                        new Claim("UserID", userDTO.id.ToString()),
                        new Claim("UserName", userDTO.identifiant)
                    };

                    var userIdenity = new ClaimsIdentity(userClaims, "userIdentity");

                    var userPrincipal = new ClaimsPrincipal(new[] { userIdenity });

                    HttpContext.SignInAsync(userPrincipal); //Set Cookie

                    return Redirect("/Home"); 
                }

            }
            return RedirectToAction("Index");
        }

    }
}