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
    public class ContactModificationTests : TestBase

    {
        /// <summary>
        /// Метод, который редактирует контакт
        /// </summary>
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData
            {
                Firstname = "Ivan",
                Lastname = "Ivanov",
                Middlename = "Ivanovich",
                Nickname = "Ivasik",
                Title = "Popile",
                Company = "Mapany",
                Address = "Kertegg",
                Home = "House",
                Mobile = "911002233",
                Work = "Wewewe",
                Fax = "Safafaf",
                Email = "email@gmail.com",
                Email2 = "email2@gmail.com",
                Email3 = "email3@gmail.com",
                Homepage = "www.gmail.com",
                Bday = "30",
                Bmonth = "June",
                Byear = "2000",
                Aday = "20",
                Amonth = "November",
                Ayear = "2002",
                Address2 = "Swwerqt",
                Phone2 = "Vbbbbbb",
                Notes = "Zametki"
            };
            app.Contacts.ModificationContact(1, newContactData);
            app.Auth.Logout();
        }
    }

}

