using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAdressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        /// <summary>
        /// Тест в котором происходит создание групппы.
        /// Здесь собраны методы, которые изначально проверяют наличие групп на странице групп.
        /// Сверяют количество групп на странице до и после создания новой группы.
        /// И совершается разлогин.
        /// </summary>
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData()
            {
                Name = GenerateRandomString(10),
                Header = GenerateRandomString(20),
                Footer = GenerateRandomString(20)
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
            GroupData group = new GroupData("a'a")
            {
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
    }
}
