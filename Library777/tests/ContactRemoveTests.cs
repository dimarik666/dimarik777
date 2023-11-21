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
    public class ContactRemoveTests : AuthTestBase
    {
        /// <summary>
        /// Метод, который удаляет контакт на странице контактов
        /// </summary>
        [Test]
        public void ContactRemoveTestFromHome()
        {
            ContactData contactData = new ContactData()
            {
                Firstname = "Ivan",
                Lastname = "Ivanov",
                Middlename = "Ivanovich",
                Nickname = "Ivasik",
                Title = "Popile",
                Company = "Mapany",
                Address = "Kertegg",
                Home = "777777",
                Mobile = "911002233",
                Work = "99999999999",
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
                Phone2 = "911",
                Notes = "Zametki"
            };
            app.Contacts.CheckContact(contactData);
            app.Contacts.RemoveContactFromHome(1, contactData);
            app.Auth.Logout();
        }
        /// <summary>
        /// Метод, который удаляет контакт со страницы редактирования контакта
        /// </summary>
        [Test]
        public void ContactRemoveTestFromEditPage()
        {
            ContactData contactData = new ContactData()
            {
                Firstname = "Ivan",
                Lastname = "Ivanov",
                Middlename = "Ivanovich",
                Nickname = "Ivasik",
                Title = "Popile",
                Company = "Mapany",
                Address = "Kertegg",
                Home = "777777",
                Mobile = "911002233",
                Work = "99999999999",
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
                Phone2 = "911",
                Notes = "Zametki"
            };
            app.Contacts.CheckContact(contactData);
            app.Contacts.RemoveContactFromEditContact(1);
            app.Auth.Logout();
        }
    }
}