using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order();
            order.AddItem(new Shoe("Fancy Shoe 1", 565));
            order.AddItem(new Shoe("Fancy Shoe 2", 431));
            order.Print();

            Console.ReadKey();
        }


        public interface IOrderable
        {
            void Print();

            decimal GetPrice();
        }

        public class Order : IOrderable
        {
            private List<IOrderable> _orderItems = new List<IOrderable>();

            public void AddItem(IOrderable item)
            {
                _orderItems.Add(item);
            }

            public decimal GetPrice()
            {
                return _orderItems.Sum(x => x.GetPrice());
            }

            public void Print()
            {
                Console.WriteLine($"Order details: ");

                _orderItems.ForEach(item => item.Print());

                Console.WriteLine($"Total: {GetPrice()}");
            }
        }

        public sealed class Shoe : IOrderable
        {
            private string _name;
            private decimal _price;

            public Shoe(string name, decimal price)
            {
                _name = name;
                _price = price;
            }

            public void Print()
            {
                Console.WriteLine($"    {_name}: {GetPrice()}");
            }

            public decimal GetPrice()
            {
                return _price;
            }
        }
    }
}
