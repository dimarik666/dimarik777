﻿using System;
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
            GroupData newData = new GroupData("thisisname")
            {
                Header = "thisisheader",
                Footer = "thisisfooter"
            };
            app.Groups.CheckGroup(newData);
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];
            app.Groups.ModificationGroup(1, newData);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups[0].Header = newData.Header;
            oldGroups[0].Footer = newData.Footer;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
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
