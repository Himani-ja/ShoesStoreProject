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
        public string path = @"..\..\..\..\ShoesData\shoes.xml";
        public List<shoes> Init(int sid,int id,Category category,double size,double price,Colors color,Types type,Lace lace,string brand,int quantity)
        {
            cats = new List<shoes>(){
                    new shoes(){StoreId=sid,Id=id,Category=category,Size=size,Price=price,Color=color,Type=type,Lace=lace,Brand=brand,Quantity=quantity},

                    
                };
            return cats;
        }
        public void Addshoes(List<shoes> cats)
        {
            /*  StreamWriter writer = new StreamWriter(path);
               XmlSerializer serializer = new XmlSerializer(typeof(List<shoes>));
               FileStream fs = File.Open(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
               serializer.Serialize(fs, cats); */

            /*XmlSerializer serializer = new XmlSerializer(typeof(List<shoes>));
            FileStream fs = File.Open(path, FileMode.Append);
            serializer.Serialize(fs, cats); 

            fs.Close();*/

            if (!File.Exists(path))
            {
                XmlSerializer xSeriz = new XmlSerializer(typeof(List<shoes>));
                FileStream fs = File.Open(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                xSeriz.Serialize(fs, cats);

            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                foreach (shoes shoe in cats)
                {
                    XmlNode xnode = doc.CreateNode(XmlNodeType.Element, "Shoes", null);
                    XmlSerializer xSeriz = new XmlSerializer(typeof(shoes));
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
        }

        public IEnumerable<shoes> GetAllShoes(string _path = @"..\..\..\..\ShoesData\shoes.xml")
        {
            XmlSerializer deserializer = null;
            List<shoes> allshoes = null;
            try
            {
                using StreamReader reader = new StreamReader(_path);
                deserializer = new XmlSerializer(typeof(List<shoes>));
                allshoes = (List<shoes>)deserializer.Deserialize(reader);
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
            if (allshoes != null)
            {
                if (allshoes.Count > 0)
                    return allshoes;
            }
            else
                throw new System.NullReferenceException();
            return null;
        }
        public shoes GetShoes(int id)
        {
            var shoes = GetAllShoes();
            var shoe = shoes.Where<shoes>(x => x.Id == id).FirstOrDefault();
            return shoe;
        }
    }
}
