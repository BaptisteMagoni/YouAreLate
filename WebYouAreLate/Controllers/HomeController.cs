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
using System.IO;

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

        public IActionResult UpVote()
        {
            
            var idUser = User.Claims.Where(x => x.Type == "UserID").FirstOrDefault().Value;
            object idTicket = null;
            HttpContext.Request.RouteValues.TryGetValue("id", out idTicket);
            VoteDTO vote = new VoteDTO() {
                idlate = Int32.Parse(idTicket.ToString()),
                iduser = Int32.Parse(idUser)
            };
            late.LikeLateTicket(vote);
            return RedirectToAction("Index");
        }

        public IActionResult DownVote(int idLate)
        {
            var idUser = User.Claims.Where(x => x.Type == "UserID").FirstOrDefault().Value;
            object idTicket = null;
            HttpContext.Request.RouteValues.TryGetValue("id", out idTicket);
            VoteDTO vote = new VoteDTO()
            {
                idlate = Int32.Parse(idTicket.ToString()),
                iduser = Int32.Parse(idUser)
            };
            late.DisLikeLateTicket(vote);
            return RedirectToAction("Index");
        }
    
        
        public async Task addLateTicketAsync(IFormCollection collection, IFormFile file)
        {



            if (!string.IsNullOrEmpty(collection["date"]) && !string.IsNullOrEmpty(collection["subject"]))
            {
                LateTicketDTO newTicket = new LateTicketDTO();
                newTicket.Subject = collection["subject"];
                newTicket.datetime = DateTime.Parse(collection["date"]);
                newTicket.image = Path.GetRandomFileName()+ Path.GetExtension(collection.Files[0].FileName);
                newTicket.idUser = 1;
                using (var stream = System.IO.File.Create(Path.Combine(@".\wwwroot\img\upload\", newTicket.image)))
                {
                    await collection.Files[0].CopyToAsync(stream);
                }
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
