using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Entites.Orders
{
    public enum OrderStatus
    {
        Pendening = 0,
        PaymentFailed = 1,
        PaymentSucceeded = 2,
    }
}
