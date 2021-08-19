using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace CustData
{
   public class CustRepo
    {
        static List<Customer> Custs = null;
        static string path = @"..\..\..\..\CustData\CustomerData.xml";
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
            /*StreamWriter writer = new StreamWriter(path);
           // FileStream fs = File.Open("CustomerData.xml", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
            serializer.Serialize(writer, Custs);

            writer.Close();
            System.Console.WriteLine("All Customer data has been stored in the XML file at {0}", path);*/


            if (!File.Exists(path))
            {
                XmlSerializer xSeriz = new XmlSerializer(typeof(List<Customer>));
                FileStream fs = File.Open(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                xSeriz.Serialize(fs, Custs);

            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                foreach (Customer cust in Custs)
                {
                    XmlNode xnode = doc.CreateNode(XmlNodeType.Element, "Customer", null);
                    XmlSerializer xSeriz = new XmlSerializer(typeof(Customer));
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlWriterSettings writtersetting = new XmlWriterSettings();
                    writtersetting.OmitXmlDeclaration = true;
                    StringWriter stringwriter = new StringWriter();
                    using (XmlWriter xmlwriter = System.Xml.XmlWriter.Create(stringwriter, writtersetting))
                    {
                        xSeriz.Serialize(xmlwriter, cust, ns);
                    }
                    xnode.InnerXml = stringwriter.ToString();
                    XmlNode bindxnode = xnode.SelectSingleNode("Customer");
                    doc.DocumentElement.AppendChild(bindxnode);

                }
                doc.Save(path);
            }

            System.Console.WriteLine("All cats has bee stored in the XML file at {0}", path);
        }
        public IEnumerable<Customer> GetAllCustomer(string _path = @"..\..\..\..\CustData\CustomerData.xml")
        {
            XmlSerializer deserializer = null;
            List<Customer> allcustomer = null;
            try
            {
                using StreamReader reader = new StreamReader(_path);
                deserializer = new XmlSerializer(typeof(List<Customer>));
                allcustomer = (List<Customer>)deserializer.Deserialize(reader);
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
            if (allcustomer != null)
            {
                if (allcustomer.Count > 0)
                    return allcustomer;
            }
            else
                throw new System.NullReferenceException();
            return null;
        }
        public Customer GetCustomer(string name)
        {
            var customers = GetAllCustomer();
            var customer = customers.Where<Customer>(x => x.C_name == name).FirstOrDefault();

            return customer;
        }

        //customer login password

       /* static List<CustomerCredential> credential = null;
        public string path1 = @"..\..\..\..\CustData\CustomerCredentialData.xml";
        public List<CustomerCredential> CredentialInit( int id,string username, string password )
        {
           
            credential = new List<CustomerCredential>(){
                    new CustomerCredential(){Customer_ID=id,C_UserName=username,C_Password=password},

                };
            return credential;
        }
        // login details store in xml
        public void AddCustomerCredential(List<CustomerCredential> customerdetial)
        {
            /*StreamWriter writer = new StreamWriter(path);
           // FileStream fs = File.Open("CustomerData.xml", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
            serializer.Serialize(writer, Custs);

            writer.Close();
            System.Console.WriteLine("All Customer data has been stored in the XML file at {0}", path);*/


            /*if (!File.Exists(path1))
            {
                XmlSerializer xSeriz = new XmlSerializer(typeof(List<CustomerCredential>));
                FileStream fs = File.Open(path1, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                xSeriz.Serialize(fs, customerdetial);

            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path1);

                foreach (CustomerCredential customer in customerdetial)
                {
                    XmlNode xnode = doc.CreateNode(XmlNodeType.Element, "CustomerCredential", null);
                    XmlSerializer xSeriz = new XmlSerializer(typeof(CustomerCredential));
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlWriterSettings writtersetting = new XmlWriterSettings();
                    writtersetting.OmitXmlDeclaration = true;
                    StringWriter stringwriter = new StringWriter();
                    using (XmlWriter xmlwriter = System.Xml.XmlWriter.Create(stringwriter, writtersetting))
                    {
                        xSeriz.Serialize(xmlwriter, customer, ns);
                    }
                    xnode.InnerXml = stringwriter.ToString();
                    XmlNode bindxnode = xnode.SelectSingleNode("CustomerCredential");
                    doc.DocumentElement.AppendChild(bindxnode);

                }
                doc.Save(path1);
            }

            Console.WriteLine("All customer credential  has been stored in the XML file at {0}", path1);
        }*/
    }
}
