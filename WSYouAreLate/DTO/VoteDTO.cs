using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSYouAreLate.DTO
{
    public class VoteDTO
    {

        public int iduser { get; set; }

        public int idlate { get; set; }

        public int? Vote { get; set; }

    }
}