namespace f3b_store
{
    public class BasketItem
    {
        public string ProductId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public BasketItem(string productId, int amount, double price)
        {
            ProductId = productId;
            Amount = amount;
            Price = price;
        }
    }
}