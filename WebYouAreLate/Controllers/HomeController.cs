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
    [Authorize] //Need to be logged for go in this part 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private LateService late = new LateService();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #region Vote
        public IActionResult UpVote() //User Like Late Ticket
        {
            
            var idUser = User.Claims.Where(x => x.Type == "UserID").FirstOrDefault().Value; //Get UserID in Cookie
            object idTicket = null;
            HttpContext.Request.RouteValues.TryGetValue("id", out idTicket);
            VoteDTO vote = new VoteDTO() { //Init new vote object
                idlate = Int32.Parse(idTicket.ToString()),
                iduser = Int32.Parse(idUser)
                
            };
            late.LikeLateTicket(vote); //Send vote
            return RedirectToAction("Index"); //Render Index
        }

        public IActionResult DownVote(int idLate) //User Dislike Late Tickets
        {
            var idUser = User.Claims.Where(x => x.Type == "UserID").FirstOrDefault().Value; //Get UserID in Cookie
            object idTicket = null;
            HttpContext.Request.RouteValues.TryGetValue("id", out idTicket);
            VoteDTO vote = new VoteDTO() // Create New Vote
            {
                idlate = Int32.Parse(idTicket.ToString()),
                iduser = Int32.Parse(idUser)
            };
            late.DisLikeLateTicket(vote); //Send vote
            return RedirectToAction("Index"); //Render Index
        }
        #endregion

        public async Task addLateTicketAsync(IFormCollection collection, IFormFile file)
        {



            if (!string.IsNullOrEmpty(collection["date"]) && !string.IsNullOrEmpty(collection["subject"]))
            {
                var idUser = User.Claims.Where(x => x.Type == "UserID").FirstOrDefault().Value; //Get UserID in Cookie
                LateTicketDTO newTicket = new LateTicketDTO();
                newTicket.Subject = collection["subject"]; //Get Input Value Subject 
                newTicket.datetime = DateTime.Parse(collection["date"]); //Get Input Value Date
                newTicket.image = Path.GetRandomFileName()+ Path.GetExtension(collection.Files[0].FileName); // Set pictures path with random namefile
                newTicket.idUser = Int32.Parse(idUser);
                using (var stream = System.IO.File.Create(Path.Combine(@".\wwwroot\img\upload\", newTicket.image))) //Save Picture 
                {
                    await collection.Files[0].CopyToAsync(stream);
                }
                late.CreateLateTicket(newTicket);

            }
        }
        
        public IActionResult addComment(int idTicket, IFormCollection inputs)
        {
            var idUser = User.Claims.Where(x => x.Type == "UserID").FirstOrDefault().Value; //Get UserID in Cookie
            CommentaryDTO newComment = new CommentaryDTO
            {
                idlate = idTicket,
                message = inputs["message"],
                iduser = Int32.Parse(idUser),
                date = new DateTime()
            };
            late.CreateCommentary(newComment);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            List < LateTicketDTO > tickets = late.GetLateTickets(); //Get all LateTickets
            List<List<CommentaryDTO>> commentaryDTOs = new List<List<CommentaryDTO>>();
            tickets.ForEach(x => {
                x.merite = late.GetCountLikesLate(x) - late.GetCountDisLikeLate(x);
                commentaryDTOs.Add(late.GetCommentariesTicketLate(x));
            }); //Set LateTicketDTO.merite and commment
            
            HomeModel home = new HomeModel //Init Model
            {
                tickets = tickets,
                commentaries = commentaryDTOs,
                late = late
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
