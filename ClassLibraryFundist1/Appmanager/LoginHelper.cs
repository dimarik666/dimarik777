using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestFundist
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        /// <summary>
        /// Метод, который совершает вход в аккаунт с валидными кредами
        /// </summary>
        /// <param name="account">здесь содержатся валидные креды для входа в аккаунт</param>
        public LoginHelper Login(AccountData account)
        {
            Type(By.CssSelector("input[name='Login']"), account.Username);
            Type(By.CssSelector("input[name='Password']"), account.Password);
            driver.FindElement(By.CssSelector("button[id='LoginBtn']")).Click();
            Thread.Sleep(10000);
            return this;
        }

        /// <summary>
        /// Выход из аккаунта
        /// </summary>
        /// <returns></returns>
        public LoginHelper Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector("button[id='LogoutButton']")).Click();
            }
            return this;
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("button[id='LogoutButton']"));
        }
        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == account.Username;
        }

        /// <summary>
        /// Метод, который возвращает имя пользователя, который сейчас залогинен
        /// </summary>
        /// <returns></returns>
        private string GetLoggetUserName()
        {
            string text = driver.FindElement(By.CssSelector("span[id='CurrentLogin']")).Text;
            return text;
        }
    }
}