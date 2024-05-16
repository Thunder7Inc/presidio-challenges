namespace PizzaShopAPI.models
{
    public class Order
    {
        public int OId { get; set; }

        public int CId { get; set; }

        public Customer Customer { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
