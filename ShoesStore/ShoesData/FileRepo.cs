using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;


namespace ShoesData
{
    public class FileRepo
    {
        static List<shoes> cats = null;
        static string path = @"C:\shoesproject\ShoesStoreProject\ShoesStore\ShoesStore\shoes.xml";
        public List<shoes> Init(int id,Category category)
        {
            Console.WriteLine("hello");
            cats = new List<shoes>(){
                    new shoes(){Id=id,Category=category},
                    
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
