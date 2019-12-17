using System;
using System.Collections.Generic;

namespace EfCoreSamples.DbFirst.Context
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
