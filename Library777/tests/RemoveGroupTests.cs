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
    public class GroupRemovalTests : GroupTestBase
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
            GroupData newData = new GroupData("default_name")
            {
                Header = "default_header",
                Footer = "default_footer"
            };
            List<GroupData> oldGroups = GroupData.GetAll();
            if (oldGroups.Count == 0)
            {
                GroupData testGroupData = GroupData.GetTestingGroup();
                app.Groups.CreateNewGroup(testGroupData);
                oldGroups = app.Groups.GetGroupList();
            }
            app.Groups.RemoveGroup(oldGroups[0]);
            app.Navigator.GoToGroupsPage();
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
            //app.Auth.Logout();
        }
    }
}