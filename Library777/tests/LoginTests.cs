using System;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAdressBookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        /// <summary>
        /// Тест, который совершает логин с валидными кредами, и проверяет это утвреждение на true.
        /// </summary>     
        public void LoginWithValidCredentials()
        {
            //подготовка
            app.Auth.Logout();

            //действие
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            //проверка
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        /// <summary>
        /// Тест, который осуществляет логин с невалидными кредами, и проверяет это утверждение на false.
        /// </summary>
        public void LoginWithInValidCredentials()
        {
            //подготовка
            app.Auth.Logout();

            //действие
            AccountData account = new AccountData("admin", "123456");
            app.Auth.Login(account);

            //проверка
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
