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
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }
        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }


        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.CssSelector("input[name='delete']")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]']) [" + index + "]")).Click();
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.CssSelector("a[href='group.php']")).Click();
            return this;
        }
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[name='submit']"));
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            driver.FindElement(By.CssSelector("input[name='group_name']")).Clear();
            driver.FindElement(By.CssSelector("input[name='group_name']")).SendKeys(group.Name);
            driver.FindElement(By.CssSelector("textarea[name='group_header']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='group_header']")).SendKeys(group.Header);
            driver.FindElement(By.CssSelector("textarea[name='group_footer']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='group_footer']")).SendKeys(group.Footer);
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[name='new']")).Click();
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.CssSelector("input[name='update']")).Click();
            return this;

        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.CssSelector("input[name='edit']")).Click();
            return this;

        }


    }
}
