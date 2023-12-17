using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebAdressBookTests;

namespace WebAdressBookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        /// <summary>
        /// Тест в котором происходит модификация групппы.
        /// Здесь собраны методы, которые изначально проверяют наличие групп на странице групп.
        /// Сверяют количество групп на странице до и после модификации.
        /// И совершается разлогин.
        /// </summary>
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData()
            {
                Name = GenerateRandomString(10),
                Header = GenerateRandomString(10),
                Footer = GenerateRandomString(10)
            };
            List<GroupData> oldGroups = GroupData.GetAll();
            if (oldGroups.Count == 0) 
            {
                GroupData testGroupData = GroupData.GetTestingGroup();
                app.Groups.CreateNewGroup(testGroupData);
                oldGroups = app.Groups.GetGroupList();
            }
            GroupData toBeModified = oldGroups[0];
            app.Groups.ModificationGroup(toBeModified, newData);
            app.Navigator.GoToGroupsPage();
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups[0].Header = newData.Header;
            oldGroups[0].Footer = newData.Footer;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModified.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                    Assert.AreEqual(newData.Header, group.Header);
                    Assert.AreEqual(newData.Footer, group.Footer);
                }
            }
            app.Auth.Logout();
        }
    }
}
