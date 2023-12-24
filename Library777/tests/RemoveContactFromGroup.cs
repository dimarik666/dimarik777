using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using OpenQA.Selenium.Remote;
using System.Net;
using System.Linq;
using System.Collections.Generic;

namespace WebAdressBookTests
{
    public class RemoveContactFromGroup : AuthTestBase
    {
        [Test]
        public void TestRemoveContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            app.Contacts.ContactInGroup(group);
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = group.GetContacts().First();
            app.Contacts.RemoveContactFromGroup(contact, group);
            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
