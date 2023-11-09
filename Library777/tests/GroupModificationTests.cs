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
    public class GroupModificationTests : TestBase
    {

        /// <summary>
        /// Метод, который редактирует группу
        /// </summary>
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("ddd", "bbb", "mmm");
            app.Groups.ModifyGroup(1, newData);
        }
    }
}