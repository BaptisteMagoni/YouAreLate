using ServiceReferenceLate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebYouAreLate.Models
{
    public class LoginModel
    {
        public UserDTO userDTO { get; set; }
        public bool Authentified { get; set; }
    }
}
