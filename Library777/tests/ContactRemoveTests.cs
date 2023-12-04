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
            ContactData newContactData = new ContactData("Dmitrii", "Dmitriev")
            {
                Middlename = "Dmitrievich",
                Nickname = "Dimarik",
                Title = "Title",
                Company = "Company",
                Address = "Adress",
                Home = "729911",
                Mobile = "89992223300",
                Work = "89534445566",
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
                ContactData modelContact = new ContactData();
                ContactData testContactData = modelContact.GetTestingContact();
                app.Contacts.CreateNewContact(testContactData);
                oldContacts = app.Contacts.GetContactList();
            }
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
            ContactData newContactData = new ContactData("Dmitrii", "Dmitriev")
            {
                Middlename = "Dmitrievich",
                Nickname = "Dimarik",
                Title = "Title",
                Company = "Company",
                Address = "Adress",
                Home = "729911",
                Mobile = "89992223300",
                Work = "89534445566",
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
                ContactData modelContact = new ContactData();
                ContactData testContactData = modelContact.GetTestingContact();
                app.Contacts.CreateNewContact(testContactData);
                oldContacts = app.Contacts.GetContactList();
            }
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