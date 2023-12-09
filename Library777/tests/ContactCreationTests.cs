﻿using System;
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
    public class ContactCreationTests : AuthTestBase
    {
        /// <summary>
        /// Тест в котором происходит создание контакта.
        /// Здесь собраны методы, которые изначально проверяют наличие контактов на странице контактов.
        /// Сверяют количество контактов на странице до и после создания нового контакта.
        /// И совершается разлогин.
        /// </summary>
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Dmitrii", "Dmitriev")
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
            app.Contacts.CreateNewContact(contact);
            app.Navigator.GoToContactsPage();
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            app.Auth.Logout();
        }

        /// <summary>
        /// Тест в котором происходит создание контакта с пустыми полями.
        /// Здесь собраны методы, которые изначально проверяют наличие контактов на странице контактов.
        /// Сверяют количество контактов на странице до и после создания нового контакта.
        /// И совершается разлогин.
        /// </summary>
        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "")
            {
                Middlename = "",
                Nickname = "",
                Title = "",
                Company = "",
                Address = "",
                HomePhone = "",
                MobilePhone = "",
                WorkPhone = "",
                Fax = "",
                Email = "",
                Email2 = "",
                Email3 = "",
                Homepage = "",
                Bday = "",
                Bmonth = "-",
                Byear = "",
                Aday = "",
                Amonth = "-",
                Ayear = "",
                Address2 = "",
                Phone2 = "",
                Notes = ""
            };
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.CreateNewContact(contact);
            app.Navigator.GoToContactsPage();
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            app.Auth.Logout();
        }

        /// <summary>
        /// Тест в котором происходит создание контакта невалидным именем из-за невалидного символа "'".
        /// Здесь собраны методы, которые изначально проверяют наличие контактов на странице контактов.
        /// Сверяют количество контактов на странице до и после попытки создать новый контакт.
        /// И совершается разлогин.
        /// </summary>
        [Test]
        public void BadNameContactCreationTest()
        {
            ContactData contact = new ContactData("a'a", "Dmitriev")
            {
                Middlename = "Dmitrievich",
                Nickname = "Dimarik",
                Title = "Tirle",
                Company = "Company",
                Address = "Adress",
                HomePhone = "Home",
                MobilePhone = "89992223300",
                WorkPhone = "Work",
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
                Phone2 = "Home",
                Notes = "Notes"
            };
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.CreateNewContact(contact);
            app.Navigator.GoToContactsPage();
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            app.Auth.Logout();
        }
    }
}