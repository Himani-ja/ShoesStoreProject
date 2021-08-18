using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace ShoesData
{
    public class FileRepo
    {
        static List<shoes> cats = null;
        static string path = @"C:\Projectshoes\ShoesStoreProject\ShoesStore\ShoesData\shoes.xml";
        public List<shoes> Init(int id,Category category,double size,double price,Colors color,Types type,Lace lace,string brand,int quantity)
        {
            cats = new List<shoes>(){
                    new shoes(){Id=id,Category=category,Size=size,Price=price,Color=color,Type=type,Lace=lace,Brand=brand,Quantity=quantity},

                    
                };
            return cats;
        }
        public void Addshoes(List<shoes> cats)
        {
            StreamWriter writer = new StreamWriter(path);
            XmlSerializer serializer = new XmlSerializer(typeof(List<shoes>));
            serializer.Serialize(writer, cats);
            writer.Close();
            System.Console.WriteLine("All cats has bee stored in the XML file at {0}", path);
        }
    }
}
