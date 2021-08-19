using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesLibrary
{
   public class Orders
    {
        int orderid;
        public int OrderId
        {
            get
            {
                return orderid;
            }
            set
            {
               orderid = value;
            }
        }
        int customer_id;
        public int Customer_Id
        {
            get
            {
                return customer_id;
            }
            set
            {
                customer_id = value;
            }
        }
        int storeid;
        public int StoreId
        {
            get
            {
                return storeid;
            }
            set
            {
                storeid = value;
            }
        }

        double totalbill;
        public double TotalBill
        {
            get
            {
                return totalbill;
            }
            set
            {
                totalbill = value;
            }
        }
        string orderdate;
        public string OrderDate
        {
            get
            {
                return orderdate;
            }
            set
            {
                orderdate = value;
            }
        }
    }
}
