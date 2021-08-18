using System;
using ShoesLibrary;

namespace ShoesLibrary
{
    public enum Category
    {
        Casual_Wear=1,Sports,Loafer,Boots,Sneakers,
        
    }
    public enum Colors
    {
        Black,Blue,White,Grey,Red,Brown
    }
    public enum Types
    {
        Male = 0, Female
    }
    public enum Lace
    {
        Yes = 0, No
    }

   public class shoes
    {
        int id;
        public int Id {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        Category category;
        public Category Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }
        double size;
        public double Size 
        { 
            get { 
                return size;
            }
            set 
            {
                size = value; 
            }
        }

        double price;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        Colors color;
        public Colors Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        Types type;
        public Types Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        Lace lace;
        public Lace Lace
        {
            get
            {
                return lace;
            }
            set
            {
                lace = value;
            }
        }
        string brand;
        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {
                brand = value;
            }
        }
        int quantity;
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        public  string AddShoes()
        {
            return  $"\nId: {Id} \nCategory: {Category}\nSize:{size}\nPrice:{price}";

       
        }
    }
}
