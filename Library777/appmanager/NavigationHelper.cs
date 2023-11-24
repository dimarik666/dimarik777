using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAdressBookTests
{    public class NavigationHelper : HelperBase
    {
        public string baseURL;
        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        /// <summary>
        /// Метод, который открывает начальную страницу
        /// </summary>
        public NavigationHelper OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
            return this;
        }

        /// <summary>
        /// Метод, который совершает переход на страницу групп
        /// </summary>
        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.CssSelector("a[href='group.php']")).Click();
        }

        /// <summary>
        /// Переход на страницу со всеми контактами
        /// </summary>
        /// <returns></returns>
        public NavigationHelper GoToContactsPage()
        {
            driver.FindElement(By.CssSelector("a[href='./']")).Click();
            return this;
        }
    }
}
