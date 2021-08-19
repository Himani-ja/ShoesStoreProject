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
            public List<orders> InitOrder(int oid, int sid,double tbill)
            {
            orderlist = new List<orders>(){
                    new orders(){StoreId=sid,OrderId=oid,TotalBill=tbill},


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
        }
    }

