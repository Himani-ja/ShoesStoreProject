using System;
using StoreData;
using ProductData;
using ShoesLibrary;
using System.Data;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace OrderData
{
    public class Orderclass
    { 
        /*public void StoreSelection(int u_id)
        {
            int shoeselection;
            int buyquantity;
            int i = 0;
            int j = 0;
            Dictionary<string, string> shoeIdAndQuantity = new Dictionary<string, string>();
            double[] price = new double[200];
            double cost=0;
            FileRepoStore Store = new FileRepoStore();
            Orders Orderobj = new Orders();
            var allstores = Store.GetAllStores();
            Console.WriteLine("\n-----------------Order Page-----------------\n");
            foreach (var store in allstores)
            { 
                Console.Write("|     Id:" + store.Id);
                Console.Write(" Location:" + store.Location + "    |\n");
            }
            Console.Write("\n Select Store Id, You want to buy from ");
            int selection = int.Parse(Console.ReadLine());
            foreach (var store in allstores)
            {
                if (selection == store.Id)
                {
                    Console.WriteLine(" You selected " + store.Location + " store ");
                }
            }
            
            ProductRepo display = new ProductRepo();
            //var allshoes = display.GetAllShoes();
            buymore:
                foreach (var shoes in allshoes)
                {
                    if (selection == shoes.StoreId)
                    {
                        Console.Write("\n| Id:" + shoes.Id + " |");
                        Console.Write(" Category:" + shoes.Category + " |");
                        Console.Write(" Brand:" + shoes.Brand + " |");
                        Console.Write(" Type:" + shoes.Type + " |");
                        Console.Write(" Lace:" + shoes.Lace + " |");
                        Console.Write(" Size:" + shoes.Size + " |");
                        Console.Write(" Color:" + shoes.Color + " |");
                        Console.Write(" Price:" + shoes.Price + " |\n");
                    }
                    Orderobj.StoreId = selection;

                }
                Console.Write("\n Select Shoe Id to buy ");
                shoeselection = int.Parse(Console.ReadLine());
            enterquantity:
                Console.Write("\n Enter Quantity ");
                buyquantity = int.Parse(Console.ReadLine());
            
            foreach (var shoes in allshoes)
                {
                
                 string id = Convert.ToString(shoes.Id);
                    if (shoes.Id == shoeselection)
                    {
                    if (shoes.Quantity < buyquantity)
                    {
                        Console.WriteLine("Sorry we don't have enough quantity");
                        goto enterquantity;
                    }
                    else
                    {
                        shoeIdAndQuantity.Add(Convert.ToString(shoes.Id), Convert.ToString(buyquantity));
                        price[i] = shoes.Price;
                        i++;
                        QuantityUpdate(id, buyquantity);
                        cost = cost+(shoes.Price * buyquantity);
                       
                    }
                    }

                }
            menu:
                Console.Write("\n <1> Add more item \n <2> Checkout\n");
                Console.Write("\n Choose the above option: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                case 1:
                    goto buymore;
                   
                case 2:
                    break;
                default:
                    Console.WriteLine(" You selected wrong option ");
                    Console.ReadLine();
                    goto menu;
                  
                }
            
           
            
            Console.WriteLine("Your orders are");
            Console.WriteLine("Id" + "        Quantity" +"       Price per shoes");
           
            foreach (KeyValuePair<string, string> ord in shoeIdAndQuantity)
            {
                Console.WriteLine("{0}           {1}        {2}",
                ord.Key, ord.Value,price[j]);
                j++;
            }

            Console.WriteLine("---------------------------------");
            Console.Write("Your Total bill is:" + cost + "\n");
            Console.Write("Thanks for shopping with us.......\n");
            OrderRepo order = new OrderRepo();

            DateTime orderdate = DateTime.Now;
            string order_date = Convert.ToString(orderdate);
            
            Random randomnumber = new Random();
            int num = randomnumber.Next(10000, 100000);
            Orderobj.OrderId = num;
            Orderobj.TotalBill = cost;
            Orderobj.Customer_Id = u_id;
            var addorder = order.InitOrder(Orderobj.OrderId,Orderobj.Customer_Id, Orderobj.StoreId, Orderobj.TotalBill,order_date);
            order.AddOrders(addorder);

            Console.ReadLine();
            
        }
        public void OrderHistory(int u_id)
        {
            OrderRepo orderobj = new OrderRepo();
            
            var allorders = orderobj.GetAllOrders();
            foreach (var order in allorders)
            {
                if (u_id == order.Customer_Id)
                {
                    Console.Write("\n|  Date and Time of Order : " + order.OrderDate + " |");
                    Console.Write(" Store id: " + order.StoreId + " |");
                    Console.Write(" Order id: " + order.OrderId + " |");
                    Console.Write(" Total bill: " + order.TotalBill + " |\n");
                    
                }
            }
            Console.ReadLine();

        }

        public static bool QuantityUpdate(string id, int buyquantity)
        {
            XDocument xdoc = XDocument.Load(@"..\..\..\..\ShoesData\shoes.xml");

            XElement emp = xdoc.Descendants("shoes").FirstOrDefault(p => p.Element("Id").Value == id);
            if (emp != null)
            {
                int quantity = Convert.ToInt32(emp.Element("Quantity").Value);
                quantity = quantity - buyquantity;
                emp.Element("Quantity").Value = Convert.ToString(quantity);
                //xdoc.Root.Add(emp);
                xdoc.Save(@"..\..\..\..\ShoesData\shoes.xml");
                return true;
            }
            else
                return false;
        }*/
    }
}
