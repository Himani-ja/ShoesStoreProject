using System;
using ShoesLibrary;
using ShoesData;
using CustData;

namespace ShoesStore
{
    class Program
    {
        static void Main(string[] args)
        {
           // AddShoes();
            AddCustomer();
        }
      /*  private static void AddShoes()
        {
            ShoesData.shoes shoes1 = new ShoesLibrary.shoes();
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
        }*/
        private static void AddCustomer()
        {
            CustData.Customer customer = new CustData.Customer();
            Console.Write("Customer Id: ");
            customer.C_Id = int.Parse(Console.ReadLine());

            Console.Write("Customer name: ");
            customer.C_name = Console.ReadLine();
           
            Console.Write("Customer Email: ");
            customer.C_Email = Console.ReadLine();
        
            Console.Write("Customer contact number: ");
            customer.C_contact = Int32.Parse(Console.ReadLine());

            Console.Write("Customer Location: ");
            customer.C_location = Console.ReadLine();
            CustRepo c_repo = new CustRepo();

            var addcustomer = c_repo.Init(customer.C_Id,customer.C_name, customer.C_Email, customer.C_contact,customer.C_location);
            c_repo.AddCustomer(addcustomer);
        }

    }
}
