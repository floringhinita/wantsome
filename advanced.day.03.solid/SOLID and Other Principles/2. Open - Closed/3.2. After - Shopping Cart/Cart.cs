namespace OpenClosedShoppingCartAfter
{
    using System.Collections.Generic;

    public class Cart
    {
        private readonly List<OrderItem> items;

        public Cart()
        {
            this.items = new List<OrderItem>();
        }

        public IEnumerable<OrderItem> Items
        {
            get { return new List<OrderItem>(this.items); }
        }

        public string CustomerEmail { get; set; }

        public void Add(OrderItem orderItem)
        {
            this.items.Add(orderItem);
        }

        public decimal TotalAmount()
        {
            decimal total = 0m;
            foreach (OrderItem orderItem in this.Items)
            {
                total += orderItem.GetPrice();
            }

            return total;
        }
    }
}