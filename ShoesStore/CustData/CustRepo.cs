using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CustData
{
   public class CustRepo
    {
        static List<Customer> Custs = null;
        static string path = @"D:\Training1\pro\dotnet\ShoesStore\CustData\CustomerData.xml";
        public List<Customer> Init(int Id,  string name,string email,Int32 contact,string locat)
        {
            //Console.WriteLine("hello");
            Custs = new List<Customer>(){
                    new Customer(){ C_Id=Id, C_name=name,C_Email=email,C_contact=contact,C_location=locat},

                };
            return Custs;
        }
        public void AddCustomer(List<Customer> Custs)
        {
            StreamWriter writer = new StreamWriter(path);
           // FileStream fs = File.Open("CustomerData.xml", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
            serializer.Serialize(writer, Custs);

            writer.Close();
            System.Console.WriteLine("All Customer data has been stored in the XML file at {0}", path);
        }
    }
}
