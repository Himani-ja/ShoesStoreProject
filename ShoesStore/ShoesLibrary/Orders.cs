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
    }
}
