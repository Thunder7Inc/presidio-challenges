using System;
using System.Threading.Tasks;
using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingCartConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Initialize repositories
            AbstractRepository<int, Customer> customerRepository = new CustomerRepository();
            AbstractRepository<int, Product> productRepository = new ProductRepository();
            AbstractRepository<int, Cart> cartRepository = new CartRepository();

            // Initialize services
            ICustomerService customerService = new CustomerService(customerRepository);
            IProductService productService = new ProductService(productRepository);
            ICartService cartService = new CartService(cartRepository, productRepository);

            // Create and print a sample customer
            Customer newCustomer = new Customer
            {
                Id = 1,
                Name = "John Doe",
                Age = 30,
                Phone = "123-456-7890"
            };
            Console.WriteLine("Creating customer...");
            await customerService.AddCustomer(newCustomer);
            Console.WriteLine("Customer created successfully.");

            // Create and print a sample product
            Product newProduct = new Product
            {
                Id = 1,
                Name = "Sample Product",
                Price = 19.99,
                QuantityInHand = 100,
                Image = "product_image.jpg"
            };
            Console.WriteLine("\nCreating product...");
            await productService.AddProduct(newProduct);
            Console.WriteLine("Product created successfully.");

            // Create and print a sample cart
            Cart newCart = new Cart
            {
                Id = 1,
                CustomerId = 1,
                CreatedAt = DateTime.Now
            };
            Console.WriteLine("\nCreating cart...");
            await cartService.AddProductToCart(newCart.Id, newProduct.Id, 2);
            Console.WriteLine("Product added to cart successfully.");
            Console.WriteLine("\nGetting cart details...");
            Cart cartDetails = await cartService.GetCartById(newCart.Id);
            Console.WriteLine($"Cart ID: {cartDetails.Id}");
            Console.WriteLine($"Customer ID: {cartDetails.CustomerId}");
            Console.WriteLine($"Created At: {cartDetails.CreatedAt}");
            Console.WriteLine("Cart Items:");
            foreach (var cartItem in cartDetails.CartItems)
            {
                Console.WriteLine($"- Product ID: {cartItem.ProductId}, Quantity: {cartItem.Quantity}");
            }

            Console.ReadLine(); // Wait for user input to exit
        }
    }
}
