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
    public class AuthTestBase : TestBase
    {
        /// <summary>
        /// Метод авторизации, который совершает логин с валидными кредами.
        /// </summary>
        [SetUp]
        public void SetupLogin()
        {
            app.Auth.Login(new AccountData("op_site_test", "Test123!"));
        }
    }
}
