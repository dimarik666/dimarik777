using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
    public class ContactModificationTests : AuthTestBase

    {
        /// <summary>
        /// Тест в котором происходит модификация контакта.
        /// Здесь собраны методы, которые изначально проверяют наличие контактов на странице контактов.
        /// Сверяют количество контактов на странице до и после модификации.
        /// И совершается разлогин.
        /// </summary>
        [Test]
        public void ContactModificationTest()
        {
            ContactData modelContact = new ContactData();
            ContactData newContactData = modelContact.GetContact("Albert", "Voronov");
            var contactsCount = app.driver.FindElements(By.XPath("(//input[@name='selected[]'])")).Count;
            if (contactsCount == 0)
                app.Contacts.CreateNewContact(modelContact.GetContact("Maksim", "Maksimov"));
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];
            app.Contacts.ModificationContact(1, newContactData);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newContactData.Firstname;
            oldContacts[0].Lastname = newContactData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id) 
                { 
                    Assert.AreEqual(newContactData.Firstname, contact.Firstname);
                    Assert.AreEqual(newContactData.Lastname, contact.Lastname);
                }
            }
            app.Auth.Logout();
        }
    }
}

