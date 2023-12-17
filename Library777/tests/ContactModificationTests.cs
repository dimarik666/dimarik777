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
    public class ContactModificationTests : ContactTestBase

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
            ContactData newContactData = new ContactData()
            {
                Firstname = GenerateRandomString(10),
                Lastname = GenerateRandomString(10),
                Middlename = GenerateRandomString(10),
                Nickname = GenerateRandomString(10),
                Title = GenerateRandomString(10),
                Company = GenerateRandomString(10),
                Address = GenerateRandomString(10),
                HomePhone = GenerateRandomString(10),
                MobilePhone = GenerateRandomString(10),
                WorkPhone = GenerateRandomString(10),
                Fax = GenerateRandomString(10),
                Email = GenerateRandomString(10) + "@email.com",
                Email2 = GenerateRandomString(10) + "@email.com",
                Email3 = GenerateRandomString(10) + "@email.com",
                Homepage = GenerateRandomString(10) + ".com",
                Bday = GetRandomNumber(0, 31).ToString(),
                Bmonth = GenerateRandomMonth(),
                Byear = GenerateRandomYear(),
                Aday = GetRandomNumber(0, 31).ToString(),
                Amonth = GenerateRandomMonth(),
                Ayear = GenerateRandomYear(),
                Address2 = GenerateRandomString(10),
                Phone2 = GenerateRandomString(10),
                Notes = GenerateRandomString(10)
            };
            List<ContactData> oldContacts = ContactData.GetAll();
            if (oldContacts.Count == 0)
            {
                ContactData testContactData = ContactData.GetTestingContact();
                app.Contacts.CreateNewContact(testContactData);
                oldContacts = app.Contacts.GetContactList();
            }
            ContactData toBeModified = oldContacts[0];
            app.Contacts.ModificationContact(toBeModified, newContactData);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].Firstname = newContactData.Firstname;
            oldContacts[0].Lastname = newContactData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == toBeModified.Id) 
                { 
                    Assert.AreEqual(newContactData.Firstname, contact.Firstname);
                    Assert.AreEqual(newContactData.Lastname, contact.Lastname);
                }
            }
            app.Auth.Logout();
        }
    }
}

