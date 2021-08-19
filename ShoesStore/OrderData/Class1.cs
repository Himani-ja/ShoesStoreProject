using System;
using StoreData;
using ShoesData;
using ShoesLibrary;
using System.Data;
namespace OrderData
{
    public class Order
    {
        public object ViewState { get; private set; }

        public void StoreSelection()
        {
            int shoeselection;
            
            double cost=0;
            int selection;
            StoreData.FileRepoStore Store = new StoreData.FileRepoStore();
            ShoesLibrary.Orders Orderobj = new ShoesLibrary.Orders();
            var allstores = Store.GetAllStores();
            foreach (var store in allstores)
            {

                Console.Write("| Id:" + store.Id);
                Console.Write(" Location:" + store.Location + "|\n");
            }
            Console.WriteLine("Select Store You want to buy from");
            selection = int.Parse(Console.ReadLine());
            foreach (var store in allstores)
            {
                if (selection == store.Id)
                {
                    Console.WriteLine("You selected " + store.Location + " store");
                }
            }
            
            FileRepo display = new FileRepo();
            var allshoes = display.GetAllShoes();
            buymore:
                foreach (var shoes in allshoes)
                {
                    if (selection == shoes.StoreId)
                    {


                        Console.Write("Store id:" + shoes.StoreId + "|");
                        Console.Write("id:" + shoes.Id + "|");
                        Console.Write(" category:" + shoes.Category + "|");
                        Console.Write(" Brand:" + shoes.Brand + "|");
                        Console.Write(" Type:" + shoes.Type + "|");
                        Console.Write(" Lace:" + shoes.Lace + "|");
                        Console.Write(" Size:" + shoes.Size + "|");
                        Console.Write(" Color:" + shoes.Color + "|");
                        Console.Write(" Price:" + shoes.Price + "|\n");
                    }
                    Orderobj.StoreId = shoes.StoreId;

                }
                Console.WriteLine("Select Shoe id to buy");
                shoeselection = int.Parse(Console.ReadLine());
                
                foreach (var shoes in allshoes)
                {

                    if (shoes.Id == shoeselection)
                    {
                    
                        var decreaseqty = display.GetShoes(shoes.Id);
                       

                    
                        Console.WriteLine(decreaseqty.Quantity);
                        cost = cost + shoes.Price;
                       
                        
                        
                    }

                }
                Console.WriteLine("<1>Add more item \n <2> Checkout");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                case 1:
                    goto buymore;
                    break;
                case 2:
                    break;
                default:
                    goto buymore;
                    break;
                }
            Console.WriteLine("Thanks for shopping with us\n Your Total bill is:" + cost);
            OrderRepo order = new OrderRepo();
            Random randomnumber = new Random();
            int num = randomnumber.Next(10000, 100000);
            Orderobj.OrderId = num;
            Orderobj.TotalBill = cost;
            


            var addorder = order.InitOrder(Orderobj.OrderId, Orderobj.StoreId, Orderobj.TotalBill);
            order.AddOrders(addorder);

        }
    }
}
