using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentInterfaceSample
{
    class CartValidation : ICartBeforeValidation, ICartValidation, ICartAfterValidation
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
        public ICartAfterValidation CheckPrice()
        {
            if (Cart.Price < 0)
            {
                throw new Exception("Price must be greater than zero");
            }

            return this;
        }

        public ICartAfterValidation CheckQuantity()
        {
            if (Cart.Quantity == 0)
            {
                throw new Exception("Quantity must be greater than zero");
            }

            return this;
        }

        public ICartBeforeValidation GetCart(int id)
        {
            Cart = carts.FirstOrDefault();
            return this;
        }

    }

    interface ICommon
    {

    }

    interface ICartValidation : ICommon
    {
        ICartBeforeValidation GetCart(int id);

    }

    interface ICartAfterValidation : ICommon
    {
        ICartAfterValidation CheckPrice();
    }

    interface ICartBeforeValidation : ICommon
    {
        ICartAfterValidation CheckQuantity();
    }
}