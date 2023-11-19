using System;
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
        /// Метод, который удаляет группу
        /// </summary>
        [Test]
        public void GroupRemovalTest()
        {
            GroupData groupData = new GroupData("Kikimora", null, null);
            app.Groups.RemoveGroup(1, groupData);
            app.Auth.Logout();
        }
    }
}