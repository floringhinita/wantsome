using Dapper;
using DapperSamples.App.Entities;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace DapperSamples.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string sqlOrders = "SELECT TOP 5 * FROM Orders;";

            string sqlOrder = "SELECT * FROM Orders WHERE OrderId = @OrderId;";

            string sqlOrderInsert = "INSERT INTO Orders (CustomerId, EmployeeId, OrderDate) Values (@CustomerId, @EmployeeId, @OrderDate);";

            using (var connection = new SqlConnection("Data Source=EN1210001;Integrated Security=True; Initial Catalog=StoreDB_3"))
            {
                var orderDetails = connection.Query<Order>(sqlOrders).ToList();

                var orderDetail = connection.QueryFirstOrDefault<Order>(sqlOrder, new { OrderId = 1 });

                var affectedRows = connection.Execute(sqlOrderInsert, new Order { CustomerId=1, EmployeeId=2, OrderDate=DateTime.Now });

                Console.WriteLine(orderDetails.Count);

                Console.WriteLine(affectedRows);
            }
        }
    }
}
