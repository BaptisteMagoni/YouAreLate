using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSYouAreLate.Entities;

namespace WSYouAreLate.DTO
{
    public class UserDTO
    {

        public int iduser { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string identifiant { get; set; }

        public string password { get; set; }

        public string classe { get; set; }

        public List<LateTicketDTO> tickets { get; set; }

    }
}