using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
    }
}

