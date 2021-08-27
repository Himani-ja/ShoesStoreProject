using System;
using ShoesLibrary;

namespace ShoesLibrary
{
    

   public class Product
    {
        int p_id;
        public int Product_Id {
            get
            {
                return p_id;
            }
            set
            {
                p_id = value;
            }
        }
        int ct_id;
        public int Category_Id
        {
            get
            {
                return ct_id;
            }
            set
            {
                ct_id = value;
            }
        }
        int st_id;
        public int Store_Id
        {
            get
            {
                return st_id;
            }
            set
            {
                st_id = value;
            }
        }
        string p_name;
        public string Product_Name {
            get
            {
                return p_name;
            }
            set
            {
                p_name = value;
            }
        }
        bool p_active;
        public bool P_Active {
            get
            {
                return p_active;
            }
            set
            {
                p_active = value;
            }
        }
        /*double size;
        public double Size 
        { 
            get { 
                return size;
            }
            set 
            {
                size = value; 
            }
        }*/

        /*double price;
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
        }*/
        /*Colors color;
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
        }*/
        /*Types type;
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
        }*/



        /*public  string AddShoes()
        {
            return  $"\nId: {Id} \nCategory: {Category}\nSize:{size}\nPrice:{price}";

       
        }*/
    }

    public class ProductDetails
    {
        int pd_id;
        public int ProductDetails_Id
        {
            get
            {
                return pd_id;
            }
            set
            {
                pd_id = value;
            }
        }
        int p_id;
        public int Product_Id
        {
            get
            {
                return p_id;
            }
            set
            {
                p_id = value;
            }
        }
        int b_id;
        public int Brand_Id
        {
            get
            {
                return b_id;
            }
            set
            {
                b_id = value;
            }
        }
        bool p_type;
        public bool Product_Type
        {
            get
            {
                return p_type;
            }
            set
            {
                p_type = value;
            }
        }
        decimal p_price;
        public decimal Price
        {
            get
            {
                return p_price;
            }
            set
            {
                p_price = value;
            }
        }
        bool p_lace;
        public bool Lace
        {
            get
            {
                return p_lace;
            }
            set
            {
                p_lace = value;
            }
        }
        int p_quantity;
        public int Quantity 
        {
            get
            {
                return p_quantity;
            }
            set
            {
                p_quantity = value;
            }
        }
        string p_image;
        public string Image
        {
            get
            {
                return p_image;
            }
            set
            {
                p_image = value;
            }
        }
    }
    public class Brand
    {
        int b_id;
        public int Brand_Id
        {
            get
            {
                return b_id;
            }
            set
            {
                b_id = value;
            }
        }
        string b_name;
        public string Brand_Name
        {
            get
            {
                return b_name;
            }
            set
            {
                b_name = value;
            }
        }
    }
    public class Category
    {
        int ct_id;
        public int Category_Id
        {
            get
            {
                return ct_id;
            }
            set
            {
                ct_id = value;
            }
        }
        string ct_name;
        public string Category_Name
        {
            get
            {
                return ct_name;
            }
            set
            {
                ct_name = value;
            }
        }
        bool ct_active;
        public bool CT_Active
        {
            get
            {
                return ct_active;
            }
            set
            {
                ct_active = value;
            }
        }
    }
    public class Color
    {
        int c_id;
        public int Color_Id
        {
            get
            {
                return c_id;
            }
            set
            {
                c_id = value;
            }
        }
        string c_name;
        public string Color_Name
        {
            get
            {
                return c_name;
            }
            set
            {
                c_name = value;
            }
        }
    }
    public class Size
    {
        int s_id;
        public int Size_Id
        {
            get
            {
                return s_id;
            }
            set
            {
                s_id = value;
            }
        }
        string s_name;
        public string Size_Name
        {
            get
            {
                return s_name;
            }
            set
            {
                s_name = value;
            }
        }
    }

    public class ProductColor
    {
        int p_id;
        public int Product_Id
        {
            get
            {
                return p_id;
            }
            set
            {
                p_id = value;
            }
        }

        int c_id;
        public int Color_Id
        {
            get
            {
                return c_id;
            }
            set
            {
                c_id = value;
            }
        }
    }

    public class ProductSize
    {
        int p_id;
        public int Product_Id
        {
            get
            {
                return p_id;
            }
            set
            {
                p_id = value;
            }
        }

        int s_id;
        public int Size_Id
        {
            get
            {
                return s_id;
            }
            set
            {
                s_id = value;
            }
        }
    }

}
