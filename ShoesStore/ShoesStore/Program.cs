using System;

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
            ShoesLibrary.shoes shoes1 = new ShoesLibrary.shoes();
            Console.Write("Please enter your shoes Id: ");
            shoes1.Id = int.Parse(Console.ReadLine());
            Console.Write("Please enter your shoes Category: ");
            shoes1.Category = (ShoesLibrary.Category)int.Parse(Console.ReadLine());
            Console.Write(shoes1.AddShoes());
            FileRepo repo = new FileRepo();
            var cate = shoes1.Category;
            //Console.WriteLine(cate);
            var addshoes = repo.Init(shoes1.Id, (ShoesData.Category)cate);
            repo.Addshoes(addshoes);
        }
    }
}
