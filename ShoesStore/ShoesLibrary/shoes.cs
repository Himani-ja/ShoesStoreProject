using System;

namespace ShoesLibrary
{
    public enum Category
    {
        Casual_Wear=1,Sports,Loafer,Boots,Sneakers,
        
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
        public  string AddShoes()
        {
            return  $"\nId: {Id} \nCategory: {Category}\nSize:{size}";
        }
    }
}
