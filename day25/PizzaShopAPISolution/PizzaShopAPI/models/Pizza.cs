namespace PizzaShopAPI.models
{
    public class Pizza
    {
        public int PId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
