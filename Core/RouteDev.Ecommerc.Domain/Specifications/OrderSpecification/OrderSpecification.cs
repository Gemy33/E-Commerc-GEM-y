using RouteDev.Ecommerc.Domain.Entites.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Specifications.OrderSpecification
{
    public class OrderSpecification:BaseSpecification<Order,Guid>
    {
        public OrderSpecification():base()
        {
            AddInclude(o => o.DeliveryMethod);
            AddInclude(o => o.Items);
            
        }

       
    }
}
