using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Service.Apstraction.DTO_s.Auth
{
    public class RegisterDto
    {
        public required string DisplayName { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public  string PhoneNumber { get; set; }


        public required string Password { get; set; }

    }
}
