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
}
