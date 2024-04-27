namespace ShoppingModelLibrary
{
    public class Product : IEquatable<Product>
    {
        public int ProductId { get; set; }
        public double Price { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }
        public int QuantityInHand { get; set; }
        public override string ToString()
        {
            return "Id : " + ProductId +
                "\nName : " + Name +
                "\nPrice : $" + Price +
                "\nNos in Stock : " + QuantityInHand;
        }

        public bool Equals(Product? other)
        {
            return this.ProductId.Equals(other.ProductId);
        }

        public Product()
        {

        }
        public Product(int id, double price, string name, int quantityInHand)
        {
            ProductId = id;
            Price = price;
            Name = name;
            QuantityInHand = quantityInHand;
        }
        

    }
}
