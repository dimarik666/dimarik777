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
    public class ContactRemoveTests : AuthTestBase
    {
        /// <summary>
        /// Метод, который удаляет контакт на странице контактов
        /// </summary>
        [Test]
        public void ContactRemoveTestFromHome()
        {
            ContactData contactData = new ContactData();
            app.Contacts.RemoveContactFromHome(1, contactData);
            app.Auth.Logout();
        }
        /// <summary>
        /// Метод, который удаляет контакт со страницы редактирования контакта
        /// </summary>
        [Test]
        public void ContactRemoveTestFromEditPage()
        {
            ContactData contactData = new ContactData();
            app.Contacts.RemoveContactFromEditContact(1);
            app.Auth.Logout();
        }
    }
}