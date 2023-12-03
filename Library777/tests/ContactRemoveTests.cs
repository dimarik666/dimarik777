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
    public class ContactRemoveTests : AuthTestBase
    {
        /// <summary>
        /// Тест в котором происходит создание контакта с домашней страницы.
        /// Здесь собраны методы, которые изначально проверяют наличие контактов на странице контактов.
        /// Сверяют количество групп на странице до и после создания контакта.
        /// И совершается разлогин.
        /// </summary>
        [Test]
        public void ContactRemoveTestFromHome()
        {
            ContactData modelContact = new ContactData();
            ContactData newContactData = modelContact.GetContact("Albert", "Voronov");
            var contactsCount = app.driver.FindElements(By.XPath("(//input[@name='selected[]'])")).Count;
            if (contactsCount == 0)
                app.Contacts.CreateNewContact(modelContact.GetContact("Vasya", "Vasiliev"));
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.RemoveContactFromHome(1, newContactData);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
            app.Auth.Logout();
        }

        /// <summary>
        /// Тест в котором происходит создание контакта со страницы редактирования.
        /// Здесь собраны методы, которые изначально проверяют наличие контактов на странице контактов.
        /// Сверяют количество контактов на странице до и после создания контакта.
        /// И совершается разлогин.
        /// </summary>
        [Test]
        public void ContactRemoveTestFromEditPage()
        {
            ContactData modelContact = new ContactData();
            ContactData newContactData = modelContact.GetContact("Albert", "Voronov");
            var contactsCount = app.driver.FindElements(By.XPath("(//input[@name='selected[]'])")).Count;
            if (contactsCount == 0)
                app.Contacts.CreateNewContact(modelContact.GetContact("Vasya", "Vasiliev"));
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.RemoveContactFromEditContact(1);
            app.Navigator.GoToContactsPage();
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
            app.Auth.Logout();
        }
    }
}