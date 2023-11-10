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
    public class GroupModificationTests : AuthTestBase
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
            GroupData newData = new GroupData("lll")
            {
                Header = null,
                Footer = null
            };
            app.Groups.CheckGroup(newData);
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.ModificationGroup(0, newData);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
            app.Auth.Logout();
        }
    }
}