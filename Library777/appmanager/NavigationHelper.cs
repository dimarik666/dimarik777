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
    public class NavigationHelper : HelperBase
    {

        public string baseURL = "http://localhost/addressbook/";

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        /// <summary>
        /// Метод, который открывает начальную страницу
        /// </summary>
        public void OpenHomePage()
        {

            driver.Navigate().GoToUrl(baseURL);
        }
        /// <summary>
        /// Метод, который совершает переход на страницу групп
        /// </summary>
        public void GoToGroupsPage()
        {
            driver.FindElement(By.CssSelector("a[href='group.php']")).Click();
        }
    }
}
