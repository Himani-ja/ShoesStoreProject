using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoesLibrary;
using ProductData;
using CustData;
using StoreData;
using OrderData;
using InputValidation;

namespace ShoesStore
{
    public class AdminLogin
    {
        Validation validate = new Validation();
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
                                Console.Write("\n Store Location: ");
                                string Location = Console.ReadLine();

                                bool loc = AddStore(Location);
                                //Console.WriteLine("testing"+loc);
                                Console.ReadLine();
                                break;
                            case 3:
                                Console.WriteLine("\n--Search Customer by Name --\n");
                                Console.Write("Enter Customer Name :");
                                string name = Console.ReadLine();
                                //string name1= 
                                SearchCustomer(name);
                                break;
                            case 4:
                                StoreOrderHistory();
                                break;
                    }
                        action = menu1();
                }
            }
            else
            {
                Console.WriteLine("\n--------Wrong Credentials--------\n");
                Console.ReadLine();
            }
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
        private void AddShoes()
        {

            ProductRepo prorepo = new ProductRepo();
            var allcat = prorepo.GetAllCategory();
            foreach (var cat in allcat)
            {

                Console.Write("\n | Id:" + cat.Category_Id + " |");
                Console.Write(" Name:" + cat.Category_Name + "|\n");

            }

            var allbrand = prorepo.GetAllBrand();
            foreach (var brand in allbrand)
            {

                Console.Write("\n | Id:" + brand.Brand_Id + " |");
                Console.Write(" Name:" + brand.Brand_Name + "|\n");

            }


            /*FileRepoStore display = new FileRepoStore();
            var allstores = display.GetAllStores();
            Console.WriteLine(" Choose Store: ");
            foreach (var store in allstores)
            {

                Console.Write("\n | Id:" + store.Id+" |");
                Console.Write(" Location:" + store.Location + "|\n");

            }
                     
            int id=0;
            Console.Write("\n Enter Store Id: ");
            id =int.Parse(Console.ReadLine());
            var storeid=display.GetStore(id);

            Product product = new Product();
          
            Random uniqueid = new Random();
            int randomnum = uniqueid.Next(10001, 100000);
            product.Product_Id = randomnum;*/
            //Console.Write(" Please enter shoes Category -\n <1> for Casual_Wear \n <2> for Sports \n <3> for Loafer \n <4> for Boots \n <5> for Sneakers:");

            /*Console.Write("\n Choose the above Shoes Category: ");
            product.Category = (ShoesLibrary.Category)int.Parse(Console.ReadLine());

            Console.Write("\n Please enter shoes brand: ");
            product.Brand = Console.ReadLine();
            product.Brand = validate.CheckName(product.Brand);
            Console.Write("\n Please enter shoes Type - <0> for male and  <1> for female: ");
            product.Type = (ShoesLibrary.Types)int.Parse(Console.ReadLine());
            Console.Write("\n Please enter shoes has Lace - <0> for yes and <1> for no: ");
            product.Lace = (ShoesLibrary.Lace)int.Parse(Console.ReadLine());
            Console.Write("\n Please enter shoes Color-(Black,White,Blue,Red,Brown,Grey): ");
            string color = Console.ReadLine();
            color = validate.CheckName(color);
            product.Color = (ShoesLibrary.Colors)Enum.Parse(typeof(ShoesLibrary.Colors), color);
            Console.Write("\n Please enter shoes size: ");
            product.Size = double.Parse(Console.ReadLine());
            Console.Write("\n Please enter shoes price: $ ");
            product.Price = double.Parse(Console.ReadLine());
            Console.Write("\n Please enter shoes quantity: ");
            product.Quantity = int.Parse(Console.ReadLine());

            ProductRepo repo = new ProductRepo();

            var addshoes = repo.Init(storeid.Id,product.Id, (ShoesData.Category)product.Category, product.Size, product.Price, (ShoesData.Colors)product.Color, (ShoesData.Types)product.Type, (ShoesData.Lace)product.Lace, product.Brand, product.Quantity);
            repo.Addshoes(addshoes);*/

            Console.ReadLine();
        }
        public bool AddStore(string location)
        {
            Store store1 = new Store();

            Random uniqueid = new Random();
            int randomnum = uniqueid.Next(10001, 100000);
            store1.Id = randomnum;

            //Console.Write("\n Store Location: ");
            store1.Location = location;
            store1.Location = validate.CheckName(store1.Location);
            
            FileRepoStore Repo2 = new FileRepoStore();
            var addStore = Repo2.Init(store1.Id, store1.Location);
            Repo2.Addstore(addStore);
            Console.WriteLine("---Store has been added---");
            //Console.ReadLine();
            return true;
        }

        public bool SearchCustomer(string name)
        {
            
            CustRepo display = new CustRepo();
            //string name;
            //Console.Write("Enter Customer Name :");
            //name = Console.ReadLine();
            name = validate.CheckName(name);

            var customername = display.GetCustomer(name);

            
            if (customername==null )
            {
                validate.SearchName(name);
                Console.ReadLine();
                return false;

            }
            
            else
            {
                Console.WriteLine("Id : " + customername.C_Id);
                Console.WriteLine("Name :" + customername.C_name);
                Console.WriteLine("Email :" + customername.C_Email);
                Console.WriteLine("Contact No :" + customername.C_contact);
                Console.ReadLine();
                return true;
            }
            
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
                    Console.Write("\n\n|  Date and Time of Order : " + order.OrderDate + "|");
                    Console.Write(" Customer id: " + order.Customer_Id + "|");
                    Console.Write("Store id: " + order.StoreId + "|");
                    Console.Write(" Order id : " + order.OrderId + "|");
                    Console.Write(" Total bill : " + order.TotalBill + "|\n");
                 }
             }
            Console.ReadLine();

        }
    }
}
