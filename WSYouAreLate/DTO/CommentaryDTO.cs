using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSYouAreLate.DTO
{
    public class CommentaryDTO
    {

        public int iduser { get; set; }

        public int idlate { get; set; }

        public string message { get; set; }

        public DateTime date { get; set; }

    }
}