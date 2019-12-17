using System;
using System.Collections.Generic;

namespace EfCoreSamples.DbFirst.Context
{
    public partial class OrderDetails
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Orders Order { get; set; }
    }
}
