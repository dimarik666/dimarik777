﻿using System;
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
        /// Метод, который удаляет контакт на странице контактов
        /// </summary>
        [Test]
        public void ContactRemoveTestFromHome()
        {
            app.Contacts.RemoveContactFromHome(1);
            app.Auth.Logout();
        }
        /// <summary>
        /// Метод, который удаляет контакт со страницы редактирования контакта
        /// </summary>
        [Test]
        public void ContactRemoveTestFromEditPage()
        {
            app.Contacts.RemoveContactFromEditContact(1);
            app.Auth.Logout();
        }
    }
}