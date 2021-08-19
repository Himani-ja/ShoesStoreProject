using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;


namespace LoginCredential
{
    public class CustomerLoginRepo
    {
        //customer login password

        static List<CustomerCredential> credential = null;
        public string path1 = @"..\..\..\..\LoginCredential\CustomerCredentialData.xml";
        public List<CustomerCredential> CredentialInit(int id, string username, string password)
        {

            credential = new List<CustomerCredential>(){
                    new CustomerCredential(){Customer_ID=id,C_UserName=username,C_Password=password},

                };
            return credential;
        }
        // login details store in xml
        public void AddCustomerCredential(List<CustomerCredential> customerdetial)
        {
           /* StreamWriter writer = new StreamWriter(path1);
            XmlSerializer serializer = new XmlSerializer(typeof(List<CustomerCredential>));
            serializer.Serialize(writer, customerdetial);

            writer.Close();*/

            if (!File.Exists(path1))
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
                    XmlNode xnode = doc.CreateNode(XmlNodeType.Element, "Credential", null);
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
        }

        //Customerlogin credential extract from xml
        public IEnumerable<CustomerCredential> GetAllCustomerCredential(string _path = @"..\..\..\..\LoginCredential\CustomerCredentialData.xml")
        {
            XmlSerializer deserializer = null;
            List<CustomerCredential> allloginCredential = null;
            try
            {
                using StreamReader reader = new StreamReader(_path);
                deserializer = new XmlSerializer(typeof(List<CustomerCredential>));
                allloginCredential = (List<CustomerCredential>)deserializer.Deserialize(reader);
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
                Console.WriteLine("Exception"+ex);
            }
            if (allloginCredential != null)
            {
                if (allloginCredential.Count > 0)
                    return allloginCredential;
            }
            else
                  throw new System.NullReferenceException();
            return null;
        }
       

        public CustomerCredential GetCustomerlogin(string name)
        {
            var customerCredentials = GetAllCustomerCredential();
            var customerusername = customerCredentials.Where<CustomerCredential>(x => x.C_UserName == name).FirstOrDefault();

            return customerusername;
        }
    }
}
