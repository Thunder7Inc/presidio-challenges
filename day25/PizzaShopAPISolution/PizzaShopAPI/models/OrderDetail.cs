namespace PizzaShopAPI.models
{
    public class OrderDetail
    {
        public int OdId { get; set; }
        public int PId { get; set; }
        public Pizza Pizza { get; set; }

        public int OId { get; set; }

        public Order Order { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
    }
}
