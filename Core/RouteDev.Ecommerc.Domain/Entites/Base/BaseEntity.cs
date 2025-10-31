using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Entites.Base
{
    public class BaseEntity<Tkey> where Tkey : IEquatable<Tkey>
    {
        public required Tkey Id { get; set; }
    }
}
