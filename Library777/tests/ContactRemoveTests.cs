﻿using System;
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
    public class ContactRemoveTests : TestBase
    {
        [Test]
        public void ContactRemoveTest()
        {
            app.Contacts.Remove(1);

        }
    }
}