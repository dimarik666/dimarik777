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
    public class GroupRemovalTests : TestBase
    {
        /// <summary>
        /// Метод, который удаляет группу
        /// </summary>
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.RemoveGroup(1);
            app.Auth.Logout();
        }
    }
}