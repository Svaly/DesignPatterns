using Decorations;
using System;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Decorator pattern sample implementation");

            var weddingDate = new DateTime(2034, 7, 11);

            var decoration = new TablesDecoration(new CarDecoration(new Decoration(weddingDate)));


            foreach (var task in decoration.GetTasks())
            {
                Console.WriteLine(task);
            }
            Console.ReadKey();
        }
    }
}
