namespace OpenClosedShoppingCartAfter
{
    public class OrderItem
    {
        public string Sku { get; set; }

        public int Quantity { get; set; }

        public decimal GetPrice()
        {
            if (this.Sku.StartsWith("EACH"))
            {
                return this.Quantity * 5m;
            }
            else if (this.Sku.StartsWith("WEIGHT"))
            {
                // quantity is in grams, price is per kg
                return this.Quantity * 4m / 1000;
            }
            else if (this.Sku.StartsWith("SPECIAL"))
            {
                // $0.40 each; 3 for a $1.00
                decimal t = 0m;
                t += this.Quantity * .4m;
                int setsOfThree = this.Quantity / 3;
                t -= setsOfThree * .2m;
                return t;
            }

            return 0;
        }
    }
}