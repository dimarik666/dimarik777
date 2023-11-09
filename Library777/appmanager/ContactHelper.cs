using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace WebAdressBookTests
{
    public class ContactHelper : HelperBase
    {
        public bool acceptNextAlert = true;
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        /// <summary>
        /// Создание новой группы
        /// </summary>
        /// <param name="group">Данные, которые запаолняются при создании новой группы</param>
        /// <returns></returns>
        public ContactHelper CreateNewContact(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            manager.Navigator.GoToContactsPage();
            AddNewContact();
            FillContactForm(contact);
            SubmitContactCreate();
            manager.Auth.Logout();
            return this;
        }
        /// <summary>
        /// Метод редактирующий контакт
        /// </summary>
        /// <param name="z">Порядковый номер контакта, который необходимо отредактировать</param>
        /// <param name="newContactData">Новые данные для редактирования контакта</param>
        /// <returns></returns>
        public ContactHelper EditContact(int z,ContactData newContactData)
        {
            manager.Navigator.OpenHomePage();
            manager.Navigator.GoToContactsPage();
            ModifyContact(z);
            FillContactForm(newContactData);
            SubmitUpdate();
            manager.Auth.Logout();
            return this;
        }
        /// <summary>
        /// Метод, который удаляет контакт
        /// </summary>
        /// <param name="z">Порядковый номер контакта, который необходимо удалить</param>
        /// <returns></returns>
        public ContactHelper RemoveContact(int z)
        {
            manager.Navigator.OpenHomePage();
            manager.Navigator.GoToContactsPage();
            SelectContact(z);
            SubmitDelete();
            CloseAlertAndGetItsText();
            manager.Auth.Logout();
            return this;
        }

        /// <summary>
        /// Выбор контакта, который необходимо отредактировать
        /// </summary>
        /// <param name="index">порядковый номер контакта</param>
        /// <returns></returns>
        public ContactHelper ModifyContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@title='Edit']) [" + index + "]")).Click();
            return this;
        }
        /// <summary>
        /// Выбор контакта, который необходимо удалить
        /// </summary>
        /// <param name="index">Порядковый номер чекбокса</param>
        /// <returns></returns>
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]']) [" + index + "]")).Click();
            return this;
        }

        /// <summary>
        /// Подтвердить удаление
        /// </summary>
        /// <returns></returns>
        public ContactHelper SubmitDelete()
        {
            driver.FindElement(By.CssSelector("input[value='Delete']")).Click();
            acceptNextAlert = true;
            return this;
        }
        /// <summary>
        /// Метод закрывающий модальное окно, для подтверждения удаления контакта
        /// </summary>
        /// <returns></returns>
        public string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        /// <summary>
        /// Метод, который заполняет поля нового контакта
        /// </summary>
        /// <param name="contact">Данные, которые необходимы при создании нового контакта </param>
        public ContactHelper FillContactForm(ContactData contact)

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
            return this;
        }
        /// <summary>
        /// Метод, который инициализирует добавление нового контакта
        /// </summary>
        /// <returns></returns>
        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.CssSelector("a[href='edit.php']")).Click();
            return this;
        }
        /// <summary>
        /// Метод, который подтверждает создание нового контакта
        /// </summary>
        /// <returns></returns>

        public ContactHelper SubmitContactCreate()
        {
            driver.FindElement(By.CssSelector("input[name='submit'")).Click();
            return this;
        }

        /// <summary>
        /// Метод, который подтверждает редактирование контакта
        /// </summary>
        /// <returns></returns>
        public ContactHelper SubmitUpdate()
        {
            driver.FindElement(By.CssSelector("input[name='update']")).Click();
            return this;
        }
    }
}
