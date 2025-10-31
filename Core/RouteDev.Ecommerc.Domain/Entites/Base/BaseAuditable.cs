using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Entites.Base
{
    public class BaseAuditable<Tkey> : BaseEntity<Tkey> where Tkey : IEquatable<Tkey>
    {
        public  string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string LastModifiyedBy { get; set; }

    }
}
