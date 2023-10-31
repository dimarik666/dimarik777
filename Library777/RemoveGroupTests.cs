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
    public class RemoveGroupTests : TestBase
    {
        /// <summary>
        /// Удаление группы
        /// </summary>
        [Test]
        public void RemoveGroupTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            SelectGroup(1);
            DeleteGroup();
            ReturnToGroupsPage();
            Logout();
        }
    }
}