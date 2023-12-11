using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebAdressBookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }
        public static IEnumerable<ContactData> ContactDataFromXMLFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                    .Deserialize(new StreamReader(@"contacts.xml"));
        }

        /// <summary>
        /// Тест в котором происходит создание контакта.
        /// Здесь собраны методы, которые изначально проверяют наличие контактов на странице контактов.
        /// Сверяют количество контактов на странице до и после создания нового контакта.
        /// И совершается разлогин.
        /// </summary>

        [Test/*, TestCaseSource("ContactDataFromXMLFile")*/]
        public void ContactCreationTest(ContactData contact)
        {
            //ContactData contact = new ContactData()
            //{
            //    Firstname = GenerateRandomString(10),
            //    Lastname = GenerateRandomString(10),
            //    Middlename = GenerateRandomString(10),
            //    Nickname = GenerateRandomString(10),
            //    Title = GenerateRandomString(10),
            //    Company = GenerateRandomString(10),
            //    Address = GenerateRandomString(10),
            //    HomePhone = GenerateRandomString(10),
            //    MobilePhone = GenerateRandomString(10),
            //    WorkPhone = GenerateRandomString(10),
            //    Fax = GenerateRandomString(10),
            //    Email = GenerateRandomString(10) + "@email.com",
            //    Email2 = GenerateRandomString(10) + "@email.com",
            //    Email3 = GenerateRandomString(10) + "@email.com",
            //    Homepage = GenerateRandomString(10) + ".com",
            //    Bday = GenerateRandomDay(),
            //    Bmonth = GenerateRandomMonth(),
            //    Byear = GenerateRandomYear(),
            //    Aday = GenerateRandomDay(),
            //    Amonth = GenerateRandomMonth(),
            //    Ayear = GenerateRandomYear(),
            //    Address2 = GenerateRandomString(10),
            //    Phone2 = GenerateRandomString(10),
            //    Notes = GenerateRandomString(20)
            //};
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
            ContactData contact = new ContactData()
            {
                Firstname = "a'a",
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
                Bday = GenerateRandomDay(),
                Bmonth = GenerateRandomMonth(),
                Byear = GenerateRandomString(4),
                Aday = GenerateRandomDay(),
                Amonth = GenerateRandomMonth(),
                Ayear = GenerateRandomString(4),
                Address2 = GenerateRandomString(10),
                Phone2 = GenerateRandomString(10),
                Notes = GenerateRandomString(20)
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