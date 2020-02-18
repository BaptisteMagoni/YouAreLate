using ModuleWebServiceLate.Service;
using ServiceReferenceLate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebYouAreLate.Models
{
    public class HomeModel
    {
        public LateService late = new LateService();
        public List<LateTicketDTO> tickets { get; set; }
        
        public List<List<CommentaryDTO>> commentaries { get; set;  }

    }
}
