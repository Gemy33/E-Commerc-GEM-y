using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Entites.IDentity
{
    public class Address
    {

        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
        //[ForeignKey(nameof(ApplicationUser))]
        public required string UserId { get; set; }

    }
}
