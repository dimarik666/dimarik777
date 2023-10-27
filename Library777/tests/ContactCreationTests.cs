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
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData
            {
                Firstname = "Dmitrii",
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
            app.Contacts.CreateContact(contact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData
            {
                Firstname = "",
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
            app.Contacts.CreateContact(contact);
        }


    }
}