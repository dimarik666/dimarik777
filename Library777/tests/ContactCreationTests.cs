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
            ContactData contact = new ContactData("Dmitrii")
            {
                Lastname = "Dmitriev",
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
            app.Contacts.CheckContact(contact);
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.CreateNewContact(contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
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
            ContactData contact = new ContactData("")
            {
                Lastname = "",
                Middlename = "",
                Nickname = "",
                Title = "",
                Company = "",
                Address = "",
                Home = "",
                Mobile = "",
                Work = "",
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
            app.Contacts.CheckContact(contact);
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.CreateNewContact(contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
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
            ContactData contact = new ContactData("a'a")
            {
                Lastname = "Dmitriev",
                Middlename = "Dmitrievich",
                Nickname = "Dimarik",
                Title = "Tirle",
                Company = "Company",
                Address = "Adress",
                Home = "Home",
                Mobile = "89992223300",
                Work = "Work",
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
            app.Contacts.CheckContact(contact);
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.CreateNewContact(contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);
            app.Auth.Logout();
        }
    }
}