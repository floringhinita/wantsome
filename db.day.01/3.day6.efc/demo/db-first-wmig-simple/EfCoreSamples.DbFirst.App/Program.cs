using EfCoreSamples.DbFirst.Context;
using EfCoreSamples.DbFirst.Domain;
using System;
using System.Collections.Generic;

namespace EfCoreSamples.DbFirst.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new StoreDB_3Context())
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
