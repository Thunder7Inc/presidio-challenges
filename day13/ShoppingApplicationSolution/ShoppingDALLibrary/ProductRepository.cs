using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {

        public override async Task<Product> Delete(int key)
        {
            Product product = items.FirstOrDefault(p => p.Id == key);
            if (product != null)
            {
                items.Remove(product);
                return product;
            }
            throw new ProductNotFoundException($"No Product with ID {key} found to delete!");
        }

        public override async Task<Product> GetByKey(int key)
        {
            Product product = items.FirstOrDefault(p => p.Id == key);
            if (product == null)
            {
                throw new ProductNotFoundException($"Product with the ID {key} was not found.");
            }
            return product;
        }

        public override async Task<Product> Update(Product item)
        {
            Product product = items.FirstOrDefault(p => p.Id == item.Id);
            if (product == null)
            {
                throw new ProductNotFoundException($"Product with the ID {item.Id} was not found.");
            }
            product.Price = item.Price;
            product.Name = item.Name;
            product.Image = item.Image;
            product.QuantityInHand = item.QuantityInHand;

            return product;
        }


    }
}
