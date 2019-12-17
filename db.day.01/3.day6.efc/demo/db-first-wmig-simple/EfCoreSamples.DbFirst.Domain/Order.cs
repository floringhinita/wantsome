using System;
using System.Collections.Generic;

namespace EfCoreSamples.DbFirst.Domain
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
