using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace ProductData
{
    public class ProductRepo
    {
        /*static List<Product> cats = null;
        public string path = @"..\..\..\..\ProductData\product.xml";
        public List<Product> Init(int sid,int id,Category category,double size,double price,Colors color,Types type,Lace lace,string brand,int quantity)
        {
            cats = new List<Product>(){
                    new Product(){StoreId=sid,Id=id,Category=category,Size=size,Price=price,Color=color,Type=type,Lace=lace,Brand=brand,Quantity=quantity},

                    
                };
            return cats;
        }
        public void Addshoes(List<Product> cats)
        {
            /*  StreamWriter writer = new StreamWriter(path);
               XmlSerializer serializer = new XmlSerializer(typeof(List<shoes>));
               FileStream fs = File.Open(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
               serializer.Serialize(fs, cats); */

            /*XmlSerializer serializer = new XmlSerializer(typeof(List<shoes>));
            FileStream fs = File.Open(path, FileMode.Append);
            serializer.Serialize(fs, cats); 

            fs.Close();*/

            /*if (!File.Exists(path))
            {
                XmlSerializer xSeriz = new XmlSerializer(typeof(List<Product>));
                FileStream fs = File.Open(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                xSeriz.Serialize(fs, cats);

            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                foreach (Product shoe in cats)
                {
                    XmlNode xnode = doc.CreateNode(XmlNodeType.Element, "Shoes", null);
                    XmlSerializer xSeriz = new XmlSerializer(typeof(Product));
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlWriterSettings writtersetting = new XmlWriterSettings();
                    writtersetting.OmitXmlDeclaration = true;
                    StringWriter stringwriter = new StringWriter();
                    using (XmlWriter xmlwriter = System.Xml.XmlWriter.Create(stringwriter, writtersetting))
                    {
                        xSeriz.Serialize(xmlwriter, shoe, ns);
                    }
                    xnode.InnerXml = stringwriter.ToString();
                    XmlNode bindxnode = xnode.SelectSingleNode("shoes");
                    doc.DocumentElement.AppendChild(bindxnode);

                }
                doc.Save(path);
            }

            System.Console.WriteLine("Shoes has been stored in the XML file");
            Console.ReadLine();
        }*/

        public IEnumerable<Product> GetAllProduct(string _path = @"..\..\..\..\ProductData\product.xml")
        {
            XmlSerializer deserializer = null;
            List<Product> allproduct = null;
            try
            {
                using StreamReader reader = new StreamReader(_path);
                deserializer = new XmlSerializer(typeof(List<Product>));
                allproduct = (List<Product>)deserializer.Deserialize(reader);
            }
            catch (DirectoryNotFoundException ex)
            {
                System.Console.WriteLine("Invalid path to the file");
            }
            catch (FileNotFoundException ex)
            {
                System.Console.WriteLine("Invalid path to the file");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception");
            }
            if (allproduct != null)
            {
                if (allproduct.Count > 0)
                    return allproduct;
            }
            else
                throw new System.NullReferenceException();
            return null;
        }
        public Product Getproduct(int id)
        {
            var product = GetAllProduct();
            var shoe = product.Where<Product>(x => x.Product_Id == id).FirstOrDefault();
            return shoe;
        }

        public IEnumerable<ProductDetails> GetAllProductDetails(string _path = @"..\..\..\..\ProductData\productdetails.xml")
        {
            XmlSerializer deserializer = null;
            List<ProductDetails> allproductdetails = null;
            try
            {
                using StreamReader reader = new StreamReader(_path);
                deserializer = new XmlSerializer(typeof(List<ProductDetails>));
                allproductdetails = (List<ProductDetails>)deserializer.Deserialize(reader);
            }
            catch (DirectoryNotFoundException ex)
            {
                System.Console.WriteLine("Invalid path to the file");
            }
            catch (FileNotFoundException ex)
            {
                System.Console.WriteLine("Invalid path to the file");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception");
            }
            if (allproductdetails != null)
            {
                if (allproductdetails.Count > 0)
                    return allproductdetails;
            }
            else
                throw new System.NullReferenceException();
            return null;
        }

        public IEnumerable<Category> GetAllCategory(string _path = @"..\..\..\..\ProductData\Category.xml")
        {
            XmlSerializer deserializer = null;
            List<Category> allcategory = null;
            try
            {
                using StreamReader reader = new StreamReader(_path);
                deserializer = new XmlSerializer(typeof(List<Category>));
                allcategory = (List<Category>)deserializer.Deserialize(reader);
            }
            catch (DirectoryNotFoundException ex)
            {
                System.Console.WriteLine("Invalid path to the file");
            }
            catch (FileNotFoundException ex)
            {
                System.Console.WriteLine("Invalid path to the file");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception");
            }
            if (allcategory != null)
            {
                if (allcategory.Count > 0)
                    return allcategory;
            }
            else
                throw new System.NullReferenceException();
            return null;
        }

        public IEnumerable<Brand> GetAllBrand(string _path = @"..\..\..\..\ProductData\Brand.xml")
        {
            XmlSerializer deserializer = null;
            List<Brand> allbrand = null;
            try
            {
                using StreamReader reader = new StreamReader(_path);
                deserializer = new XmlSerializer(typeof(List<Brand>));
                allbrand = (List<Brand>)deserializer.Deserialize(reader);
            }
            catch (DirectoryNotFoundException ex)
            {
                System.Console.WriteLine("Invalid path to the file");
            }
            catch (FileNotFoundException ex)
            {
                System.Console.WriteLine("Invalid path to the file");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception");
            }
            if (allbrand != null)
            {
                if (allbrand.Count > 0)
                    return allbrand;
            }
            else
                throw new System.NullReferenceException();
            return null;
        }
        public IEnumerable<Color> GetAllColor(string _path = @"..\..\..\..\ProductData\Color.xml")
        {
            XmlSerializer deserializer = null;
            List<Color> allcolor = null;
            try
            {
                using StreamReader reader = new StreamReader(_path);
                deserializer = new XmlSerializer(typeof(List<Color>));
                allcolor = (List<Color>)deserializer.Deserialize(reader);
            }
            catch (DirectoryNotFoundException ex)
            {
                System.Console.WriteLine("Invalid path to the file");
            }
            catch (FileNotFoundException ex)
            {
                System.Console.WriteLine("Invalid path to the file");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception");
            }
            if (allcolor != null)
            {
                if (allcolor.Count > 0)
                    return allcolor;
            }
            else
                throw new System.NullReferenceException();
            return null;
        }
        public IEnumerable<Size> GetAllSize(string _path = @"..\..\..\..\ProductData\Size.xml")
        {
            XmlSerializer deserializer = null;
            List<Size> allsize = null;
            try
            {
                using StreamReader reader = new StreamReader(_path);
                deserializer = new XmlSerializer(typeof(List<Size>));
                allsize = (List<Size>)deserializer.Deserialize(reader);
            }
            catch (DirectoryNotFoundException ex)
            {
                System.Console.WriteLine("Invalid path to the file");
            }
            catch (FileNotFoundException ex)
            {
                System.Console.WriteLine("Invalid path to the file");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception");
            }
            if (allsize != null)
            {
                if (allsize.Count > 0)
                    return allsize;
            }
            else
                throw new System.NullReferenceException();
            return null;
        }
        public IEnumerable<ProductColor> GetAllProductColor(string _path = @"..\..\..\..\ProductData\ProductColor.xml")
        {
            XmlSerializer deserializer = null;
            List<ProductColor> allproductcolor = null;
            try
            {
                using StreamReader reader = new StreamReader(_path);
                deserializer = new XmlSerializer(typeof(List<ProductColor>));
                allproductcolor = (List<ProductColor>)deserializer.Deserialize(reader);
            }
            catch (DirectoryNotFoundException ex)
            {
                System.Console.WriteLine("Invalid path to the file");
            }
            catch (FileNotFoundException ex)
            {
                System.Console.WriteLine("Invalid path to the file");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception");
            }
            if (allproductcolor != null)
            {
                if (allproductcolor.Count > 0)
                    return allproductcolor;
            }
            else
                throw new System.NullReferenceException();
            return null;
        }
        public IEnumerable<ProductSize> GetAllProductSize(string _path = @"..\..\..\..\ProductData\ProductSize.xml")
        {
            XmlSerializer deserializer = null;
            List<ProductSize> allproductSize = null;
            try
            {
                using StreamReader reader = new StreamReader(_path);
                deserializer = new XmlSerializer(typeof(List<ProductSize>));
                allproductSize = (List<ProductSize>)deserializer.Deserialize(reader);
            }
            catch (DirectoryNotFoundException ex)
            {
                System.Console.WriteLine("Invalid path to the file");
            }
            catch (FileNotFoundException ex)
            {
                System.Console.WriteLine("Invalid path to the file");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception");
            }
            if (allproductSize != null)
            {
                if (allproductSize.Count > 0)
                    return allproductSize;
            }
            else
                throw new System.NullReferenceException();
            return null;
        }
    }
}
