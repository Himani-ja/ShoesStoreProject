using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;


namespace Users
{
    public class CustomerLoginRepo
    {
        //customer login password

        static List<User> user = null;
        public string path1 = @"..\..\..\..\Users\UserData.xml";
        public List<User> UserInit(int id, Role role, string username, string password)
        {

            user = new List<User>(){
                    new User(){User_ID=id,Role=role,UserName=username,Password=password},

                };
            return user;
        }
        // login details store in xml
        public void AddUser(List<User> userdetail)
        {
            StreamWriter writer = new StreamWriter(path1);
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            serializer.Serialize(writer, userdetail);

            writer.Close();

            /*if (!File.Exists(path1))
            {
               
                XmlSerializer xSeriz = new XmlSerializer(typeof(List<User>));
                FileStream fs = File.Open(path1, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                xSeriz.Serialize(fs, userdetail);

            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path1);

                foreach (User user in userdetail)
                {
                    XmlNode xnode = doc.CreateNode(XmlNodeType.Element, "User", null);
                    XmlSerializer xSeriz = new XmlSerializer(typeof(User));
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlWriterSettings writtersetting = new XmlWriterSettings();
                    writtersetting.OmitXmlDeclaration = true;
                    StringWriter stringwriter = new StringWriter();
                    using (XmlWriter xmlwriter = System.Xml.XmlWriter.Create(stringwriter, writtersetting))
                    {
                        xSeriz.Serialize(xmlwriter, user, ns);
                    }
                    xnode.InnerXml = stringwriter.ToString();
                    XmlNode bindxnode = xnode.SelectSingleNode("User");
                    doc.DocumentElement.AppendChild(bindxnode);

                }
                doc.Save(path1);
            }*/

            Console.WriteLine("All user credential  has been stored in the XML file at {0}", path1);
        }

            //Customerlogin credential extract from xml
            public IEnumerable<User> GetAllUser(string _path = @"..\..\..\..\Users\UserData.xml")
            {
                XmlSerializer deserializer = null;
                List<User> alluserCredential = null;
                try
                {
                    using StreamReader reader = new StreamReader(_path);
                    deserializer = new XmlSerializer(typeof(List<User>));
                    alluserCredential = (List<User>)deserializer.Deserialize(reader);
                }
                catch (DirectoryNotFoundException)
                {
                    System.Console.WriteLine("Invalid path to the file");
                }
                catch (FileNotFoundException)
                {
                    System.Console.WriteLine("Invalid path to the file");
                }
                catch (Exception)
                {
                    Console.WriteLine("Exception");
                }
                if (alluserCredential != null)
                {
                    if (alluserCredential.Count > 0)
                        return alluserCredential;
                }
                else
                    throw new System.NullReferenceException();
                return null;
            }


            public User GetUserlogin(string name)
            {
                var users = GetAllUser();
                var username = users.Where<User>(x => x.UserName == name).FirstOrDefault();

                return username;
            }
        }
    }

