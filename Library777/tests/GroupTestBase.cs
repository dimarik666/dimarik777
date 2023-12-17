using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebAdressBookTests;

namespace WebAdressBookTests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if  (PERFORM_LONG_UI_CHECKS)
            { 
                List<GroupData> fromUI = app.Groups.GetGroupList();
                List<GroupData> fromDB = GroupData.GetAll();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}
