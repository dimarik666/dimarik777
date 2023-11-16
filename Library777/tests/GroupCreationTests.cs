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
    public class GroupCreationTests : TestBase
    {
        /// <summary>
        /// Метод, который создаёт новый контакт 
        /// </summary>
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("aaa", "bbb", "sss");

            app.Groups.CreateNewGroup(group);
            app.Auth.Logout();
        }
        /// <summary>
        /// Метод, который создаёт новый контакт с пустыми полями
        /// </summary>
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("", "", "");

            app.Groups.CreateNewGroup(group);
            app.Auth.Logout();
        }
    }
}
