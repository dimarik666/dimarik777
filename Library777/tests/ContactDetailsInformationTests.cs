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
    public class ContactDetailsInformationTests : AuthTestBase
    {
        [Test]
        public void TestDetailsContactInformation()
        {
            ContactData fromForm = app.Contacts.GetContactInformationEditForm(2);
            ContactData fromDetail = app.Contacts.GetContactInformationDetailForm(2);

            Assert.AreEqual(fromForm.ContactDetails, fromDetail.ContactDetails);
        }
    }
}