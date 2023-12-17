using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAdressBookTests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            string filename = args[1];
            string format = args[2];
            string type = args[3];

            if (type == "groups")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData()
                    {
                        Name = TestBase.GenerateRandomString(5),
                        Header = TestBase.GenerateRandomString(5),
                        Footer = TestBase.GenerateRandomString(5)
                    });
                }
                StreamWriter writer = new StreamWriter(filename);
                if (format == "xml")
                {
                    WriteGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    WriteGroupsToJsonFile(groups, writer);
                }
                else
                {
                    Console.Out.Write("Unrecognized format" + format);
                }
                writer.Close();        
            }   
            
            else if (type == "contacts")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData()
                    {
                        Firstname = TestBase.GenerateRandomString(10),
                        Lastname = TestBase.GenerateRandomString(10),
                        Middlename = TestBase.GenerateRandomString(10),
                        Nickname = TestBase.GenerateRandomString(10),
                        Title = TestBase.GenerateRandomString(10),
                        Company = TestBase.GenerateRandomString(10),
                        Address = TestBase.GenerateRandomString(10),
                        HomePhone = TestBase.GenerateRandomString(10),
                        MobilePhone = TestBase.GenerateRandomString(10),
                        WorkPhone = TestBase.GenerateRandomString(10),
                        Fax = TestBase.GenerateRandomString(10),
                        Email = TestBase.GenerateRandomString(10) + "@email.com",
                        Email2 = TestBase.GenerateRandomString(10) + "@email.com",
                        Email3 = TestBase.GenerateRandomString(10) + "@email.com",
                        Homepage = TestBase.GenerateRandomString(10) + ".com",
                        Bday = TestBase.GetRandomNumber(0, 31).ToString(),
                        Bmonth = TestBase.GenerateRandomMonth(),
                        Byear = TestBase.GenerateRandomYear(),
                        Aday = TestBase.GetRandomNumber(0, 31).ToString(),
                        Amonth = TestBase.GenerateRandomMonth(),
                        Ayear = TestBase.GenerateRandomYear(),
                        Address2 = TestBase.GenerateRandomString(10),
                        Phone2 = TestBase.GenerateRandomString(10),
                        Notes = TestBase.GenerateRandomString(20)
                    });
                }
                StreamWriter writer = new StreamWriter(filename);
                if (format == "xml") 
                {
                    WriteContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    WriteContactsToJsonFile(contacts, writer);
                }
                else
                {
                    Console.Out.Write("Unrecognized format" + format);
                }
                writer.Close();                
            }
        }
        static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }
        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
