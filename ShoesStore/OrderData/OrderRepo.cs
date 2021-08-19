using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ShoesData;


namespace OrderData
{
   public class OrderRepo
 
       
        {
            static List<orders> orderlist = null;
            public string path = @"..\..\..\..\OrderData\Orders.xml";
            public List<orders> InitOrder(int oid,int u_id, int sid,double tbill,string orderdate)
            {
            orderlist = new List<orders>(){
                    new orders(){StoreId=sid,Customer_Id=u_id,OrderId=oid,TotalBill=tbill,OrderDate=orderdate},


                };
                return orderlist;
            }
            public void AddOrders(List<orders> orderlist)
            {
                
           

              if (!File.Exists(path))
              {
                  XmlSerializer xSeriz = new XmlSerializer(typeof(List<orders>));
                  FileStream fs = File.Open(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                  xSeriz.Serialize(fs, orderlist);

              }
              else
              {
                  XmlDocument doc = new XmlDocument();
                  doc.Load(path);

                  foreach (orders order in orderlist)
                  {
                      XmlNode xnode = doc.CreateNode(XmlNodeType.Element, "Orders", null);
                      XmlSerializer xSeriz = new XmlSerializer(typeof(orders));
                      XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                      ns.Add("", "");
                      XmlWriterSettings writtersetting = new XmlWriterSettings();
                      writtersetting.OmitXmlDeclaration = true;
                      StringWriter stringwriter = new StringWriter();
                      using (XmlWriter xmlwriter = System.Xml.XmlWriter.Create(stringwriter, writtersetting))
                      {
                          xSeriz.Serialize(xmlwriter, order, ns);
                      }
                      xnode.InnerXml = stringwriter.ToString();
                      XmlNode bindxnode = xnode.SelectSingleNode("orders");
                      doc.DocumentElement.AppendChild(bindxnode);

                  }
                  doc.Save(path);
              }

            System.Console.WriteLine("All orders stored in the XML file at {0}", path);
            }
        public IEnumerable<orders> GetAllOrders(string _path = @"..\..\..\..\OrderData\Orders.xml")
        {
            XmlSerializer deserializer = null;
            List<orders> allorders = null;
            try
            {
                using StreamReader reader = new StreamReader(_path);
                deserializer = new XmlSerializer(typeof(List<orders>));
                allorders = (List<orders>)deserializer.Deserialize(reader);
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
            if (allorders != null)
            {
                if (allorders.Count > 0)
                    return allorders;
            }
            else
                throw new System.NullReferenceException();
            return null;
        }
        
    }
    }

