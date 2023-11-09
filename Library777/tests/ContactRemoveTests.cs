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
    public class ContactRemoveTests : TestBase
    {
        /// <summary>
        /// Метод, который удаляет контакт
        /// </summary>
        [Test]
        public void ContactRemoveTest()
        {
            app.Contacts.RemoveContact(1);

        }
    }
}