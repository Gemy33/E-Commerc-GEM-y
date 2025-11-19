using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Service.Apstraction.DTO_s.Auth
{
    public class UserDto
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string ID { get; set; }
        public required string  Token { get; set; }
    }
}
