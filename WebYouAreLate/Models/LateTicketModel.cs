using ModuleWebServiceLate.Service;
using ServiceReferenceLate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebYouAreLate.Models
{
    public class LateTicketModel : LateTicketDTO
    {
        private LateService late = new LateService();

        public LateTicketModel(LateTicketDTO lateTicketDTO)
        {

        }

        public int getMerite()
        {
            return late.GetCountLikesLate(this) - late.GetCountDisLikeLate(this);
        }
    }
}
