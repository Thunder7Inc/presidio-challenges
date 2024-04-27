using NUnit.Framework;
using ShoppingBL;
using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System.Collections.Generic;

namespace ShoppingBLTest
{
    public class Tests
    {
        AbstractRepository<int, Cart> _cartRepository;
        ICartService _cartService;

        [SetUp]
        public void Setup()
        {
            _cartRepository = new CartRepository();
            _cartService = new CartBL(_cartRepository,productRepository);
        }

        [Test]
        public void ShippingCharges_Pass_Test()
        {
            // Arrange
            var cart = new Cart { CartItems = new List<CartItem> { new CartItem { Price = 101 } } };
            _cartRepository.Add(cart);

            // Act
            var result = _cartService.ShippingCharges(cart.CartId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ShippingCharges_Fail_Test()
        {
            // Arrange
            var cart = new Cart { CartItems = new List<CartItem> { new CartItem { Price = 99 } } };
            _cartRepository.Add(cart);

            // Act
            var result = _cartService.ShippingCharges(cart.CartId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckForDiscount_Pass_Test()
        {
            // Arrange
            var cart = new Cart { CartItems = new List<CartItem> { new CartItem { Price = 500 }, new CartItem { Price = 500 }, new CartItem { Price = 500 } } };
            _cartRepository.Add(cart);

            // Act
            var result = _cartService.CheckForDiscount(cart.CartId);

            // Assert
            Assert.AreEqual(1425, result.TotalPrice);
        }
        [Test]
        public void CheckForDiscount_Fail_Test()
        {
            // Arrange
            var cart = new Cart { CartId = 1, CartItems = new List<CartItem> { new CartItem { Price = 400 }, new CartItem { Price = 400 }, new CartItem { Price = 400 } } };
            _cartRepository.Add(cart);

            // Act & Assert
            Assert.Throws<NoCartWithGivenIdException>(() => _cartService.CheckForDiscount(9999)); // Use a CartId that does not exist
        }


        [Test]
        public void CheckMaximumQuantity_Pass_Test()
        {
            // Arrange
            var cart = new Cart { CartItems = new List<CartItem> { new CartItem { Quantity = 6 } } };
            _cartRepository.Add(cart);

            // Act
            var result = _cartService.CheckMaximumQuantity(cart.CartId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckMaximumQuantity_Fail_Test()
        {
            // Arrange
            var cart = new Cart { CartItems = new List<CartItem> { new CartItem { Quantity = 5 } } };
            _cartRepository.Add(cart);

            // Act
            var result = _cartService.CheckMaximumQuantity(cart.CartId);

            // Assert
            Assert.IsFalse(result);
        }
    }
}