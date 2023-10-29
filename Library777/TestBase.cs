using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace WebAdressBookTests
{
    public class TestBase
    {
        public IWebDriver driver;
        public StringBuilder verificationErrors;
        public string baseURL = "http://localhost/addressbook/";

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        /// <summary>
        /// Заполнение формы контакта
        /// </summary>
        /// <param name="contact"></param>
        public void FillFormContact(ContactData contact)
        {
            driver.FindElement(By.CssSelector("input[name='firstname'")).Clear();
            driver.FindElement(By.CssSelector("input[name='firstname'")).SendKeys(contact.Firstname);
            driver.FindElement(By.CssSelector("input[name='middlename'")).Clear();
            driver.FindElement(By.CssSelector("input[name='middlename'")).SendKeys(contact.Middlename);
            driver.FindElement(By.CssSelector("input[name='lastname'")).Clear();
            driver.FindElement(By.CssSelector("input[name='lastname'")).SendKeys(contact.Lastname);
            driver.FindElement(By.CssSelector("input[name='nickname'")).Clear();
            driver.FindElement(By.CssSelector("input[name='nickname'")).SendKeys(contact.Nickname);
            driver.FindElement(By.CssSelector("input[name='title'")).Clear();
            driver.FindElement(By.CssSelector("input[name='title'")).SendKeys(contact.Title);
            driver.FindElement(By.CssSelector("input[name='company'")).Clear();
            driver.FindElement(By.CssSelector("input[name='company'")).SendKeys(contact.Company);
            driver.FindElement(By.CssSelector("textarea[name='address'")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='address'")).SendKeys(contact.Address);
            driver.FindElement(By.CssSelector("input[name='home'")).Clear();
            driver.FindElement(By.CssSelector("input[name='home'")).SendKeys(contact.Home);
            driver.FindElement(By.CssSelector("input[name='mobile'")).Clear();
            driver.FindElement(By.CssSelector("input[name='mobile'")).SendKeys(contact.Mobile);
            driver.FindElement(By.CssSelector("input[name='work'")).Clear();
            driver.FindElement(By.CssSelector("input[name='work'")).SendKeys(contact.Work);
            driver.FindElement(By.CssSelector("input[name='fax'")).Clear();
            driver.FindElement(By.CssSelector("input[name='fax'")).SendKeys(contact.Fax);
            driver.FindElement(By.CssSelector("input[name='email'")).Clear();
            driver.FindElement(By.CssSelector("input[name='email'")).SendKeys(contact.Email);
            driver.FindElement(By.CssSelector("input[name='email2'")).Clear();
            driver.FindElement(By.CssSelector("input[name='email2'")).SendKeys(contact.Email2);
            driver.FindElement(By.CssSelector("input[name='email3'")).Clear();
            driver.FindElement(By.CssSelector("input[name='email3'")).SendKeys(contact.Email3);
            driver.FindElement(By.CssSelector("input[name='homepage'")).Clear();
            driver.FindElement(By.CssSelector("input[name='homepage'")).SendKeys(contact.Homepage);
            new SelectElement(driver.FindElement(By.CssSelector("select[name='bday'"))).SelectByText(contact.Bday);
            new SelectElement(driver.FindElement(By.CssSelector("select[name='bmonth'"))).SelectByText(contact.Bmonth);
            driver.FindElement(By.CssSelector("input[name='byear'")).Clear();
            driver.FindElement(By.CssSelector("input[name='byear'")).SendKeys(contact.Byear);
            new SelectElement(driver.FindElement(By.CssSelector("select[name='aday'"))).SelectByText(contact.Aday);
            new SelectElement(driver.FindElement(By.CssSelector("select[name='amonth'"))).SelectByText(contact.Amonth);
            driver.FindElement(By.CssSelector("input[name='ayear'")).Clear();
            driver.FindElement(By.CssSelector("input[name='ayear'")).SendKeys(contact.Ayear);
            driver.FindElement(By.CssSelector("textarea[name='address2'")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='address2'")).SendKeys(contact.Address2);
            driver.FindElement(By.CssSelector("input[name='phone2'")).Clear();
            driver.FindElement(By.CssSelector("input[name='phone2'")).SendKeys(contact.Phone2);
            driver.FindElement(By.CssSelector("textarea[name='notes'")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='notes'")).SendKeys(contact.Notes);

        }

       /// <summary>
       /// Заполнение формы логина и вход в аккаунт
       /// </summary>
       /// <param name="account"></param>
        protected void Login(AccountData account)
        {
            driver.FindElement(By.CssSelector("input[name='user']")).Clear();
            driver.FindElement(By.CssSelector("input[name='user']")).SendKeys(account.Username);
            driver.FindElement(By.CssSelector("input[name='pass']")).Clear();
            driver.FindElement(By.CssSelector("input[name='pass']")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();
        }

        /// <summary>
        /// Открытие домашней страницы
        /// </summary>
        public void OpenHomePage()
        {

            driver.Navigate().GoToUrl(baseURL);
        }

        /// <summary>
        /// Переход на страницу групп
        /// </summary>
        public void GoToGroupsPage()
        {
            driver.FindElement(By.CssSelector("a[href='group.php']")).Click();
        }

        /// <summary>
        /// Инициализация создания группы
        /// </summary>

        public void InitGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[name='new']")).Click();
        }

        /// <summary>
        /// Форма заполнения группы
        /// </summary>
        /// <param name="group"></param>
        public void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.CssSelector("input[name='group_name']")).Clear();
            driver.FindElement(By.CssSelector("input[name='group_name']")).SendKeys(group.Name);
            driver.FindElement(By.CssSelector("textarea[name='group_header']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='group_header']")).SendKeys(group.Header);
            driver.FindElement(By.CssSelector("textarea[name='group_footer']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='group_footer']")).SendKeys(group.Footer);
        }

        /// <summary>
        /// Подтверждение создания группы
        /// </summary>
        public void SubmitGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[name='submit']")).Click();
        }

        /// <summary>
        /// Возвращение на страницу групп
        /// </summary>
        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.CssSelector("a[href='group.php']")).Click();
        }

        /// <summary>
        /// Выбор группы с помощью чекбокса
        /// </summary>
        /// <param name="index"></param>
        public void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }

        /// <summary>
        /// Удаление группы 
        /// </summary>
        public void DeleteGroup()
        {
            driver.FindElement(By.CssSelector("input[name='delete']")).Click();
        }

        /// <summary>
        /// Выход из аккаунта
        /// </summary>
        public void Logout()
        {
            driver.FindElement(By.CssSelector("form[name='logout']")).Click();
        }

        /// <summary>
        /// Добавление нового контакта
        /// </summary>
        public void AddNewContact()
        {
            driver.FindElement(By.CssSelector("a[href='edit.php']")).Click();
        }

        /// <summary>
        /// Подтверждение создания нового контакта
        /// </summary>
        public void SubmitContactCreate()
        {
            driver.FindElement(By.CssSelector("input[name='submit'")).Click();
        }
    }
}