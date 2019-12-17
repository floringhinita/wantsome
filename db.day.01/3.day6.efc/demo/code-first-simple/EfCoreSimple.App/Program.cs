namespace EfCoreSimple.App
{
    using System;
    using System.Collections.Generic;
    using Context;
    using Domain;

    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var context = new MyContext())
            {
                var std = new Order
                {
                    CustomerId = 1,
                    EmployeeId = 1,
                    OrderDate = DateTime.Now,
                    OrderDetails = new List<OrderDetail>
                    {
                        new OrderDetail
                        {
                            OrderId = 1,
                            ProductId = 1,
                            Quantity = 3
                        }
                    }
                };

                context.Orders.Add(std);

                context.SaveChanges();
            }
        }
    }
}
