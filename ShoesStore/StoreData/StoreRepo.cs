using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;


namespace StoreData
{
    public class FileRepoStore
    {
        static List<Store> stores = null;
        public string path1 = @"..\..\..\..\StoreData\storedata.xml";
        public List<Store> Init(int id, string location)
        {

            stores = new List<Store>(){
                    new Store(){Id=id,Location=location},

                };
            return stores;
        }
        public void Addstore(List<Store> stores)
        {
            /*StreamWriter writer = new StreamWriter(path1);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Store>));
            serializer.Serialize(writer, stores);

            writer.Close();
            System.Console.WriteLine("All stores has been stored in the XML file at {0}", path1);*/


            if (!File.Exists(path1))
            {
                XmlSerializer xSeriz = new XmlSerializer(typeof(List<Store>));
                FileStream fs = File.Open(path1, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                xSeriz.Serialize(fs, stores);

            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path1);

                foreach (Store store in stores)
                {
                    XmlNode xnode = doc.CreateNode(XmlNodeType.Element, "Stores", null);
                    XmlSerializer xSeriz = new XmlSerializer(typeof(Store));
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlWriterSettings writtersetting = new XmlWriterSettings();
                    writtersetting.OmitXmlDeclaration = true;
                    StringWriter stringwriter = new StringWriter();
                    using (XmlWriter xmlwriter = System.Xml.XmlWriter.Create(stringwriter, writtersetting))
                    {
                        xSeriz.Serialize(xmlwriter, store, ns);
                    }
                    xnode.InnerXml = stringwriter.ToString();
                    XmlNode bindxnode = xnode.SelectSingleNode("Store");
                    doc.DocumentElement.AppendChild(bindxnode);

                }
                doc.Save(path1);
            }

            System.Console.WriteLine("All stores has been stored in the XML file at {0}", path1);
        }

        public IEnumerable<Store> GetAllStores(string _path = @"..\..\..\..\StoreData\storedata.xml")
        {
            XmlSerializer deserializer = null;
            List<Store> allstore = null;
            try
            {
                using StreamReader reader = new StreamReader(_path);
                deserializer = new XmlSerializer(typeof(List<Store>));
                allstore = (List<Store>)deserializer.Deserialize(reader);
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
            if (allstore != null)
            {
                if (allstore.Count > 0)
                    return allstore;
            }
            else
                throw new System.NullReferenceException();
            return null;
        }

        public Store GetStore(int id)
        {
            var stores = GetAllStores();
            var store = stores.Where<Store>(x => x.Id == id).FirstOrDefault();
            
            return store;
        }









    }
}
