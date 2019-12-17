namespace EfCoreSimple.Domain
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}