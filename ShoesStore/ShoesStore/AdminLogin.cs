using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoesLibrary;
using ShoesData;
using CustData;
using StoreData;

namespace ShoesStore
{
    class AdminLogin
    {
        public void Login(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                
                 int action = menu1();
              
                while (action !=0)
                {
                 
                  //  Console.WriteLine("You choose : " + action);

                    switch (action)
                    {
                        case 1:
                            AddShoes();
                           // ContinueOrExit1();
                            break;
                        case 2:
                            AddStore();
                          //  ContinueOrExit1();
                            break;
                        case 3:
                            SearchCustomer();
                           // ContinueOrExit1();
                          //  Console.Clear();
                           // Console.ReadLine();
                            break;
                    }
                  
                    action = menu1();
                   
                }
               

            }
            else
            {Console.WriteLine("Wrong Credentials..."); }


        }
        public int menu1()
        {
            Console.Clear();
            Console.WriteLine("<1> Add Shoes Details \n<2> Add Store Information \n<3> Search Customer by name <0> Exit");
            Console.Write("Selection : ");
            int ip = Int32.Parse(Console.ReadLine());
            return ip;
            // performSelectionAction(ip);
        }
        public void ContinueOrExit1()
        {
            Console.Write("Continue ? y/n : ");
            var res = Console.ReadLine();
            if (res == "y" || res == "Y")
            {
                Console.Clear();
                //menu1();
            }
            else{
                
                Console.Clear();
                Console.ReadLine();

            }
 
        }
        private static void AddShoes()
        {
            FileRepoStore display = new FileRepoStore();
            var allstores = display.GetAllStores();
            Console.WriteLine("Choose Store :");
            foreach (var store in allstores)
            {

                Console.Write("| Id:" + store.Id);
                Console.Write(" Location:" + store.Location + "|\n");

            }
            int id;
            id=int.Parse(Console.ReadLine());
           
            var storeid=display.GetStore(id);
            Console.WriteLine(storeid.Id);

            ShoesLibrary.shoes shoes1 = new ShoesLibrary.shoes();
            Console.Write("Please enter shoes Id: ");
            shoes1.Id = int.Parse(Console.ReadLine());
            Console.Write("Please enter shoes Category -\npress <1> for Casual_Wear \npress <2> for Sports \npress <3> for Loafer \npress <4> for Boots \npress <5> for Sneakers:");
            shoes1.Category = (ShoesLibrary.Category)int.Parse(Console.ReadLine());
            //var cate = shoes1.Category;
            //Console.Write(shoes1.AddShoes());
            Console.Write("Please enter shoes brand:");
            shoes1.Brand = Console.ReadLine();
            Console.Write("Please enter shoes Type - press <0> for male and press <1> for female: ");
            shoes1.Type = (ShoesLibrary.Types)int.Parse(Console.ReadLine());
            Console.Write("Please enter shoes has Lace - press <0> for yes and press <1> for no: ");
            shoes1.Lace = (ShoesLibrary.Lace)int.Parse(Console.ReadLine());
            Console.Write("Please enter shoes Color-(Black,White,Blue,Red,Brown,Grey): ");
            string color = Console.ReadLine();
            //Console.WriteLine(color);
            shoes1.Color = (ShoesLibrary.Colors)Enum.Parse(typeof(ShoesLibrary.Colors), color);
            Console.Write("Please enter shoes size: ");
            shoes1.Size = double.Parse(Console.ReadLine());
            Console.Write("Please enter shoes price: ");
            shoes1.Price = double.Parse(Console.ReadLine());
            Console.Write("Please enter shoes quantity: ");
            shoes1.Quantity = int.Parse(Console.ReadLine());



            FileRepo repo = new FileRepo();



            //Console.WriteLine(cate);
            var addshoes = repo.Init(storeid.Id,shoes1.Id, (ShoesData.Category)shoes1.Category, shoes1.Size, shoes1.Price, (ShoesData.Colors)shoes1.Color, (ShoesData.Types)shoes1.Type, (ShoesData.Lace)shoes1.Lace, shoes1.Brand, shoes1.Quantity);
            repo.Addshoes(addshoes);

        }
        private static void AddStore()
        {
            StoreData.Store store1 = new StoreData.Store();
            Console.Write("Store Id: ");
            store1.Id = int.Parse(Console.ReadLine());
            Console.Write("Store Location: ");
            store1.Location = Console.ReadLine();
            StoreData.FileRepoStore Repo2 = new StoreData.FileRepoStore();
            var addStore = Repo2.Init(store1.Id, store1.Location);
            Repo2.Addstore(addStore);
        }

        private static void SearchCustomer()
        {
            Console.WriteLine("\n--Search Customer by Name --\n");
            CustRepo display = new CustRepo();
            string name;
            Console.Write("Enter Customer Name :");
            name = Console.ReadLine();

            var storename = display.GetCustomer(name);

            Console.WriteLine("Id : "+storename.C_Id);
            Console.WriteLine("Name :"+storename.C_name);
            Console.WriteLine("Email :"+storename.C_Email);
            Console.WriteLine("Location : "+storename.C_location);
            Console.ReadLine();

        }
    }
}
