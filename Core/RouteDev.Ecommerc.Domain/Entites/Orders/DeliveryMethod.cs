using RouteDev.Ecommerc.Domain.Entites.Base;

namespace RouteDev.Ecommerc.Domain.Entites.Orders
{
    public class DeliveryMethod:BaseEntity<int>
    {
        public string ShortName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string DeliveryTime { get; set; } = default!;
        public decimal Cost { get; set; }

    }
}
