using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentInterfaceSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var product = new CartValidation()
            .GetCart(1)
            .CheckQuantity()
            .CheckPrice();

            Console.ReadLine();
        }
    }

    class Cart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Product Product { get; set; }
    }

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }


    class CartValidation : ICartValidation
    {
        private Cart Cart;
        private List<Cart> carts = new List<Cart>();
        public CartValidation()
        {
            carts.Add(new Cart
            {
                Id = 1,
                Quantity = 0,
                Price = 3000,
                Product = new Product
                {
                    Id = 1,
                    Name = "Iphone 7",
                    Price = 3000
                }
            });
        }
        public ICartValidation CheckPrice()
        {
            if (Cart.Price < 0)
            {
                throw new Exception("Price must be greater than zero");
            }

            return this;
        }

        public ICartValidation CheckQuantity()
        {
            if (Cart.Quantity == 0)
            {
                throw new Exception("Quantity must be greater than zero");
            }

            return this;
        }

        public ICartValidation GetCart(int id)
        {
            Cart = carts.FirstOrDefault();
            return this;
        }
    }

    interface ICartValidation
    {
        ICartValidation GetCart(int id);
        ICartValidation CheckQuantity();
        ICartValidation CheckPrice();
    }

}
