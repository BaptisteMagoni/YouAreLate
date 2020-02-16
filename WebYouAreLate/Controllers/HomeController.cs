using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebYouAreLate.Models;
using ModuleWebServiceLate.Service;
using Microsoft.AspNetCore.Http;
using ServiceReferenceLate;
using Microsoft.AspNetCore.Authorization;

namespace WebYouAreLate.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private LateService late = new LateService();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult UpVote(int idLate)
        {
            System.Diagnostics.Debug.WriteLine(idLate.ToString());
            return RedirectToAction("Index");
        }

        public void DownVote()
        {
            
        }
        
        public void addLateTicket(IFormCollection collection)
        {
            if (!string.IsNullOrEmpty(collection["form-username"]) && !string.IsNullOrEmpty(collection["form-password"]))
            {
                LateTicketDTO newTicket = new LateTicketDTO();
                newTicket.Subject = collection["subject"];
                newTicket.datetime = DateTime.Parse(collection["date"]);
                newTicket.image = "UrlBidon";
                newTicket.idUser = 1;
                late.CreateLateTicket(newTicket);
            }
        }
        
        public IActionResult Index()
        {
            HomeModel home = new HomeModel
            {
                tickets = late.GetLateTickets()
            };
            return View(home);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
