using System;
using ShoesLibrary;

namespace ShoesStore
{
    class Program
    {
        static void Main(string[] args)
        {
            AddShoes();
        }
        private static void AddShoes()
        {
            shoes shoes1 = new shoes();
            Console.Write("Please enter your shoes Id: ");
            shoes1.Id = int.Parse(Console.ReadLine());
            Console.Write("Please enter your shoes Category: ");
            shoes1.Category = (ShoesLibrary.Category)int.Parse(Console.ReadLine());
            Console.Write(shoes1.AddShoes());
           
        }
        
    }
}
