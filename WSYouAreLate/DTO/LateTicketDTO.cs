using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSYouAreLate.Entities;

namespace WSYouAreLate.DTO
{
    public class LateTicketDTO
    {

        public int id { get; set; }

        public DateTime datetime { get; set; }

        public int idUser { get; set; }

        public string Subject { get; set; }

        public string image { get; set; }

        public int merite { get; set; }

    }
}