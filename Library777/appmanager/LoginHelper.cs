using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAdressBookTests
{
    public class LoginHelper : HelperBase

    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        { }

        /// <summary>
        /// Метод, который совершает вход в аккаунт с валидными кредами
        /// </summary>
        /// <param name="account">здесь содержатся валидные креды для входа в аккаунт</param>
        public LoginHelper Login(AccountData account)
        {
            driver.FindElement(By.CssSelector("input[name='user']")).Clear();
            driver.FindElement(By.CssSelector("input[name='user']")).SendKeys(account.Username);
            driver.FindElement(By.CssSelector("input[name='pass']")).Clear();
            driver.FindElement(By.CssSelector("input[name='pass']")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();
            return this;
        }

        /// <summary>
        /// Выход из аккаунта
        /// </summary>
        /// <returns></returns>
        public LoginHelper Logout()
        {
            driver.FindElement(By.CssSelector("form[name='logout']")).Click();
            return this;
        }
    }
}
