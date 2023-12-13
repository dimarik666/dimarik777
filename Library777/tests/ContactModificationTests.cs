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
            ContactData newContactData = new ContactData("Dmitrii", "Dmitriev")
            {
                Middlename = "Dmitrievich",
                Nickname = "Dimarik",
                Title = "Title",
                Company = "Company",
                Address = "Adress",
                HomePhone = "729911",
                MobilePhone = "89992223300",
                WorkPhone = "89534445566",
                Fax = "Fax",
                Email = "email@softgamings.com",
                Email2 = "email2@softgamings.com",
                Email3 = "email3@softgamimgs.com",
                Homepage = "www.softgamings.com",
                Bday = "10",
                Bmonth = "July",
                Byear = "1990",
                Aday = "10",
                Amonth = "May",
                Ayear = "1995",
                Address2 = "Adress",
                Phone2 = "756090",
                Notes = "Notes"
            };
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            if (oldContacts.Count == 0)
            {
                ContactData testContactData = ContactData.GetTestingContact();
                app.Contacts.CreateNewContact(testContactData);
                oldContacts = app.Contacts.GetContactList();
            }
            ContactData oldData = oldContacts[0];
            app.Contacts.ModificationContact(0, newContactData);
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

