using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoesLibrary;
using ShoesData;
using CustData;
using StoreData;
using OrderData;

namespace ShoesStore
{
    class AdminLogin
    {
        public void Login(string username, string password)
        {
            Console.WriteLine("\n-------------Admin Module-----------------\n");
            if (username == "admin" && password == "admin")
            {
                
                 int action = menu1();
              
                while (action !=0)
                {
                    switch (action)
                    {
                        case 1:
                            AddShoes();
                            break;
                        case 2:
                            AddStore();
                            break;
                        case 3:
                            SearchCustomer();
                            break;
                        case 4:
                            StoreOrderHistory();
                            break;
                    }
                    action = menu1();
                   
                }
            }
            else
            {Console.WriteLine("\n--------Wrong Credentials--------\n"); }


        }
        public int menu1()
        {
            Console.Clear();
            Console.WriteLine("\n <1> Add Shoes Details \n <2> Add Store Information \n <3> Search Customer by name \n <4> All Order History of Store.\n <0> Exit");
            Console.Write("\n Choose the above option: ");
            int ip = Int32.Parse(Console.ReadLine());
            return ip;
            // performSelectionAction(ip);
        }
       /* public void ContinueOrExit1()
        {
            Console.Write(" Continue ? y/n : ");
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
 
        }*/
        private static void AddShoes()
        {
            FileRepoStore display = new FileRepoStore();
            var allstores = display.GetAllStores();
            Console.WriteLine(" Choose Store: ");
            foreach (var store in allstores)
            {

                Console.Write("\n | Id:" + store.Id+" |");
                Console.Write(" Location:" + store.Location + "|\n");

            }
           
            
            int id;
            id=int.Parse(Console.ReadLine());
            var storeid=display.GetStore(id);

            ShoesLibrary.shoes shoes1 = new ShoesLibrary.shoes();
          
            Random uniqueid = new Random();
            int randomnum = uniqueid.Next(10001, 100000);
            shoes1.Id = randomnum;
            Console.Write(" Please enter shoes Category -\n <1> for Casual_Wear \n <2> for Sports \n <3> for Loafer \n <4> for Boots \n <5> for Sneakers:");
            Console.Write("\n Choose the above Shoes Category: ");
            shoes1.Category = (ShoesLibrary.Category)int.Parse(Console.ReadLine());

            Console.Write("\n Please enter shoes brand: ");
            shoes1.Brand = Console.ReadLine();
            Console.Write("\n Please enter shoes Type - <0> for male and  <1> for female: ");
            shoes1.Type = (ShoesLibrary.Types)int.Parse(Console.ReadLine());
            Console.Write("\n Please enter shoes has Lace - <0> for yes and <1> for no: ");
            shoes1.Lace = (ShoesLibrary.Lace)int.Parse(Console.ReadLine());
            Console.Write("\n Please enter shoes Color-(Black,White,Blue,Red,Brown,Grey): ");
            string color = Console.ReadLine();

            shoes1.Color = (ShoesLibrary.Colors)Enum.Parse(typeof(ShoesLibrary.Colors), color);
            Console.Write("\n Please enter shoes size: ");
            shoes1.Size = double.Parse(Console.ReadLine());
            Console.Write("\n Please enter shoes price: ");
            shoes1.Price = double.Parse(Console.ReadLine());
            Console.Write("\n Please enter shoes quantity: ");
            shoes1.Quantity = int.Parse(Console.ReadLine());

            FileRepo repo = new FileRepo();

            var addshoes = repo.Init(storeid.Id,shoes1.Id, (ShoesData.Category)shoes1.Category, shoes1.Size, shoes1.Price, (ShoesData.Colors)shoes1.Color, (ShoesData.Types)shoes1.Type, (ShoesData.Lace)shoes1.Lace, shoes1.Brand, shoes1.Quantity);
            repo.Addshoes(addshoes);

        }
        private static void AddStore()
        {
            StoreData.Store store1 = new StoreData.Store();

            Random uniqueid = new Random();
            int randomnum = uniqueid.Next(10001, 100000);
            store1.Id = randomnum;

            Console.Write("\n Store Location: ");
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
        private static void StoreOrderHistory()
        {
            int selection;
            FileRepoStore Store = new FileRepoStore();
            var allstores = Store.GetAllStores();
            foreach (var store in allstores)
            {
                Console.Write("| Id:" + store.Id);
                Console.Write(" Location:" + store.Location + "|\n");
            }
            Console.WriteLine("Enter Id of the Store You want order History");
            selection = int.Parse(Console.ReadLine());
           
            OrderRepo orderhistory = new OrderRepo();
            var allorders = orderhistory.GetAllOrders();
             foreach (var order in allorders)
             {
                 if (selection == order.StoreId)
                 {
                    Console.Write("\n|  Date and Time of Order : " + order.OrderDate + "|");
                    Console.Write("Store id: " + order.StoreId + "|");
                    Console.Write(" Order id : " + order.OrderId + "|");
                    Console.Write(" Total bill : " + order.TotalBill + "|\n");
                }
             }
            Console.ReadLine();

        }
    }
}
