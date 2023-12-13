using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;

namespace WebAdressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = GenerateRandomString(10),
                    Header = GenerateRandomString(20),
                    Footer = GenerateRandomString(20)
                });
            }
            return groups;
        }
        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData()
                {
                    Name = parts[0],
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }
        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) 
                new XmlSerializer(typeof(List<GroupData>))
                    .Deserialize(new StreamReader(@"groups.xml"));
        }
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }
        /// <summary>
        /// Тест в котором происходит создание групппы.
        /// Здесь собраны методы, которые изначально проверяют наличие групп на странице групп.
        /// Сверяют количество групп на странице до и после создания новой группы.
        /// И совершается разлогин.
        /// </summary>
        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData group)
        {
            //GroupData group = new GroupData()
            //{
            //    Name = GenerateRandomString(10),
            //    Header = GenerateRandomString(20),
            //    Footer = GenerateRandomString(20)
            //};            
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.CreateNewGroup(group);
            app.Navigator.GoToGroupsPage();
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            app.Auth.Logout();
        }

        /// <summary>
        /// Тест в котором происходит создание групппы с пустыми полями.
        /// Здесь собраны методы, которые изначально проверяют наличие групп на странице групп.
        /// Сверяют количество групп на странице до и после создания новой группы с пустыми полями.
        /// И совершается разлогин.
        /// </summary>
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData()
            {
                Name = GenerateRandomString(10),
                Header = GenerateRandomString(10),
                Footer = GenerateRandomString(10)
            };

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.CreateNewGroup(group);
            app.Navigator.GoToGroupsPage();
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            app.Auth.Logout();
        }

        /// <summary>
        /// Тест в котором не происходит создание группы т.к. в имени группы содердится невалидный символ "'".
        /// Здесь собраны методы, которые изначально проверяют наличие групп на странице групп.
        /// Сверяют количество групп на странице до и после попытки создания невалидной сущности.
        /// И совершается разлогин.
        /// </summary>
        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData()
            {
                Name = "a'a",
                Header = "hhh",
                Footer = "hhh"
            };
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.CreateNewGroup(group);
            app.Navigator.GoToGroupsPage();
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            app.Auth.Logout();
        }
        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUi = app.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            AddressBookDB db = new AddressBookDB();
            List<GroupData> fromDb = (from g in db.Groups select g).ToList();
            db.Close();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(end));
        }
    }
}
