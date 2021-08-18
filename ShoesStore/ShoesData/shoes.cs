using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesData
{
    public enum Category
    {
        Casual_Wear = 1, Sports, Loafer, Boots, Sneakers

    }
    public enum Colors
    {
        Black, Blue, White, Grey, Red, Brown
    }
    public enum Types
    {
        Male=0,Female
    }
    public enum Lace
    {
        Yes=0,No
    }
    public class shoes
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public double Size { get; set; }
        public double Price { get; set; }
        public Colors Color { get; set; }
        public Types Type { get; set; }
        public Lace Lace { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set;}

       

    }
}
