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
            Console.WriteLine("<1> Add Shoes Details \n <2>Add Store Information <0>Exit");
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
            ShoesLibrary.shoes shoes1 = new ShoesLibrary.shoes();
            Console.Write("shoes Id: ");
            shoes1.Id = int.Parse(Console.ReadLine());
            Console.Write(" shoes Category: ");
            shoes1.Category = (ShoesLibrary.Category)int.Parse(Console.ReadLine());
            Console.Write(shoes1.AddShoes());
            FileRepo repo = new FileRepo();
            var cate = shoes1.Category;
            //Console.WriteLine(cate);
            var addshoes = repo.Init(shoes1.Id, (ShoesData.Category)cate);
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
    }
}
