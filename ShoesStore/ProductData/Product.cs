using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductData
{
    /*public enum Category
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
    }*/
    public class Product
    {
        public int Product_Id { get; set; }
        public int Category_Id { get; set; }
        public int Store_Id { get; set; }
        public string Product_Name { get; set; }
        public bool P_Active { get; set; }

        /*public int StoreId { get; set; }
        public int Id { get; set; }
        public Category Category { get; set; }
        public double Size { get; set; }
        public double Price { get; set; }
        public Colors Color { get; set; }
        public Types Type { get; set; }
        public Lace Lace { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set;}*/
    }
    public class ProductDetails
    {
        public int ProductDetails_Id { get; set; }
        public int Product_Id { get; set; }
        public int Brand_Id { get; set; }
        public bool Product_Type { get; set; }
        public decimal Price { get; set; }
        public bool Lace{ get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
    }
    public class Color
    {
        public int Color_Id { get; set; }
        public string Color_Name { get; set; }
    }
    public class ProductColor
    {
        public int Product_Id { get; set; }
        public int Color_Id { get; set; }
    }
    public class Size
    {
        public int Size_Id { get; set; }
        public decimal Size_Name { get; set; }
    }
    public class ProductSize
    {
        public int Product_Id { get; set; }
        public int Size_Id { get; set; }
    }
    public class Brand
    {
        public int Brand_Id { get; set; }
        public string Brand_Name { get; set; }
    }
    public class Category
    {
        public int Category_Id { get; set; }
        public string Category_Name { get; set; }
        public bool CT_Active { get; set; }
    }
}
