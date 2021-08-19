using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderData
{
    public class orders
    {
        public int StoreId { get; set; }
        public int Customer_Id { get; set; }
        public int OrderId { get; set; }
        public double TotalBill { get; set; }
        public string OrderDate { get; set; }
    }
}
