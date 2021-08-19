using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;


namespace StoreData
{
    public class FileRepoStore
    {
        static List<Store> stores = null;
        static string path1 = @"..\..\..\..\StoreData\storedata.xml";
        public List<Store> Init(int id, string location)
        {

            stores = new List<Store>(){
                    new Store(){Id=id,Location=location},

                };
            return stores;
        }
        public void Addstore(List<Store> stores)
        {
            StreamWriter writer = new StreamWriter(path1);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Store>));
            serializer.Serialize(writer, stores);

            writer.Close();
            System.Console.WriteLine("All stores has been stored in the XML file at {0}", path1);
        }









    }
}
