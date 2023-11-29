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
    public class GroupRemovalTests : AuthTestBase
    {
        /// <summary>
        /// Тест в котором происходит удаление групппы.
        /// Здесь собраны методы, которые изначально проверяют наличие групп на странице групп.
        /// Сверяют количество групп на странице до и после удаления.
        /// И совершается разлогин.
        /// </summary>
        [Test]
        public void GroupRemovalTest()
        {
            GroupData newData = new GroupData("testremoved")
            {
                Header = "headerremove",
                Footer = "footerremove"
            };
            app.Groups.CheckGroup(newData);
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.RemoveGroup(1, newData);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
            app.Auth.Logout();
        }
    }
}