using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestFundist
{
    public class NavigationHelper : HelperBase
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
        /// Переход на страницу "Отчёты:Доходы,()"
        /// </summary>
        /// <returns></returns>
        public void GoToAffiliatesReports()
        {
            driver.FindElement(By.CssSelector("a[id='SideMenu-AffiliatePrograms']")).Click();
            Thread.Sleep(15000);
            driver.FindElement(By.CssSelector("a[id='SideMenu-Affiliates-Reports']")).Click();
        }

        /// <summary>
        /// Переход на пятый уровень по клику на PageTitle
        /// </summary>
        /// <returns></returns>
        public void GoToLevelFifth()
        {
            driver.FindElement(By.CssSelector("[id='PageTitle']")).Click();
        }

        /// <summary>
        /// Переход на второй уровень отчёта по клику на ID партнёра 
        /// </summary>
        /// <returns></returns>
        public NavigationHelper GoToAffiliateToLevelSecond()
        {
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("td[name='col-AffiliateID'] a"));
            elements.First().Click();
            return this;
        }

        /// <summary>
        /// Переход на третий уровень отчёта по клику на дату
        /// </summary>
        /// <returns></returns>
        public NavigationHelper GoToAffiliateToLevelThird()
        {
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("td[name='col-Date'] a"));
            elements.First().Click();
            return this;
        }

        /// <summary>
        /// Переход на четвертый уровень отчёта по клику на UserID
        /// </summary>
        /// <returns></returns>
        public NavigationHelper GoToAffiliateLevelFourth()
        {
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("td[name='col-UserID'] a"));
            elements.First().Click();
            return this;
        }
    }
}

