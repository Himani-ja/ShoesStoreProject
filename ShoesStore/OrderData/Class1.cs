using System;
using StoreData;
using ShoesData;
using ShoesLibrary;
using System.Data;

using System.Xml.Linq;
using System.Linq;

namespace OrderData
{
    public class Order
    {
        public object ViewState { get; private set; }

        public void StoreSelection(int u_id)
        {
            int shoeselection;
            
            double cost=0;
            int selection;
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
            selection = int.Parse(Console.ReadLine());
            foreach (var store in allstores)
            {
                if (selection == store.Id)
                {
                    Console.WriteLine(" You selected " + store.Location + " store ");
                }
            }
            
            FileRepo display = new FileRepo();
            var allshoes = display.GetAllShoes();
            buymore:
                foreach (var shoes in allshoes)
                {
                    if (selection == shoes.StoreId)
                    {


                        Console.Write("\n| Store id:" + shoes.StoreId + " |");
                        Console.Write(" Id:" + shoes.Id + " |");
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
                
                foreach (var shoes in allshoes)
                {
                string id = Convert.ToString(shoes.Id);
                    if (shoes.Id == shoeselection)
                    {
                        QuantityUpdate(id);                
                        cost = cost + shoes.Price;
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
                    goto menu;
                  
                }
            Console.Write("\n-----Thanks for shopping with us-----\n Your Total bill is:" + cost+"\n");

            
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

        public static void QuantityUpdate(string id)
        {
            XDocument xdoc = XDocument.Load(@"..\..\..\..\ShoesData\shoes.xml");

            XElement emp = xdoc.Descendants("shoes").FirstOrDefault(p => p.Element("Id").Value == id);
            if (emp != null)
            {
                int quantity = Convert.ToInt32(emp.Element("Quantity").Value);
                quantity = quantity - 1;
                emp.Element("Quantity").Value = Convert.ToString(quantity);
                //xdoc.Root.Add(emp);
                xdoc.Save(@"..\..\..\..\ShoesData\shoes.xml");
            }
        }
    }
}
