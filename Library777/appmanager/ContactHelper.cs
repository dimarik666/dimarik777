using System;
using System.Collections.Generic;
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
        public ContactHelper(ApplicationManager manager) : base(manager) { }

        /// <summary>
        /// Создание новой группы со страницы контактов
        /// </summary>
        /// <param name="group">Данные, которые запаолняются при создании новой группы</param>
        /// <returns></returns>
        public ContactHelper CreateNewContact(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            manager.Navigator.GoToContactsPage();
            InitNewContact();
            FillContactForm(contact);
            SubmitContactCreate();
            return this;
        }

        /// <summary>
        /// Метод редактирующий контакт
        /// </summary>
        /// <param name="z">Порядковый номер контакта, который необходимо отредактировать</param>
        /// <param name="newContactData">Новые данные для редактирования контакта</param>
        /// <returns></returns>
        public ContactHelper ModificationContact(int z,ContactData newContactData)
        {
            manager.Navigator.OpenHomePage();
            manager.Navigator.GoToContactsPage();
            InitContactModification(z);
            FillContactForm(newContactData);
            SubmitModification();
            manager.Navigator.GoToContactsPage();
            return this;
        }

        /// <summary>
        /// Метод, который удаляет контакт со странице где расположены все контакты
        /// </summary>
        /// <param name="z">Порядковый номер контакта, который необходимо удалить</param>
        /// <returns></returns>
        public ContactHelper RemoveContactFromHome(int z, ContactData newContactData)
        {
            manager.Navigator.OpenHomePage();
            manager.Navigator.GoToContactsPage();
            SelectContact(z);
            SubmitRemove();
            ContactCloseAlert();
            manager.Navigator.GoToContactsPage();
            return this;
        }

        /// <summary>
        /// Метод, который удаляет контакт со страницы редактирования контакта
        /// </summary>
        /// <param name="z">Порядковый номер контакта, который необходимо удалить</param>
        /// <returns></returns>
        public ContactHelper RemoveContactFromEditContact(int z)
        {
            manager.Navigator.OpenHomePage();
            manager.Navigator.GoToContactsPage();
            InitContactModification(z);
            SubmitRemoveContact();
            manager.Navigator.GoToContactsPage();
            return this;
        }

        /// <summary>
        /// Метод, который подтверждает удаление контакта на странице редактирования контакта
        /// </summary>
        /// <returns></returns>
        public ContactHelper SubmitRemoveContact()
        {
            driver.FindElement(By.CssSelector("input[value='Delete']")).Click();
            contactCache = null;
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
        /// Метод проверяющий наличие хотя бы одного контакта на странице
        /// </summary>
        /// <param name="newContactData">Данные, которые будут использованы для создания контакта в случае их отсутствия на странице контактов</param>
        public ContactHelper CheckContact(ContactData newContactData)
        {
            manager.Navigator.GoToContactsPage();
            var contactsCount = driver.FindElements(By.XPath("(//input[@name='selected[]'])")).Count;
            if (contactsCount == 0)
                CreateNewContact(newContactData);
            return this;
        }

        /// <summary>
        /// Подтверждает удаление контакта
        /// </summary>
        /// <returns></returns>
        public ContactHelper SubmitRemove()
        {
            driver.FindElement(By.CssSelector("input[value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        /// <summary>
        /// Метод закрывающий модальное окно, для подтверждения удаления контакта
        /// </summary>
        /// <returns></returns>
        public ContactHelper ContactCloseAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        /// <summary>
        /// Метод, который заполняет поля нового контакта
        /// </summary>
        /// <param name="contact">Данные, которые необходимы при создании нового контакта </param>
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.CssSelector("input[name='firstname']"), contact.Firstname);
            Type(By.CssSelector("input[name='middlename']"), contact.Middlename);
            Type(By.CssSelector("input[name='lastname']"), contact.Lastname);
            Type(By.CssSelector("input[name='nickname']"), contact.Nickname);
            Type(By.CssSelector("input[name='title']"), contact.Title);
            Type(By.CssSelector("input[name='company']"), contact.Company);
            Type(By.CssSelector("textarea[name='address']"), contact.Address);
            Type(By.CssSelector("input[name='home']"), contact.HomePhone);
            Type(By.CssSelector("input[name='mobile']"), contact.MobilePhone);
            Type(By.CssSelector("input[name='work']"), contact.WorkPhone);
            Type(By.CssSelector("input[name='fax']"), contact.Fax);
            Type(By.CssSelector("input[name='email']"), contact.Email);
            Type(By.CssSelector("input[name='email2']"), contact.Email2);
            Type(By.CssSelector("input[name='email3']"), contact.Email3);
            Type(By.CssSelector("input[name='homepage']"), contact.Homepage);
            new SelectElement(driver.FindElement(By.CssSelector("select[name='bday']"))).SelectByText(contact.Bday);
            new SelectElement(driver.FindElement(By.CssSelector("select[name='bmonth']"))).SelectByText(contact.Bmonth);
            Type(By.CssSelector("input[name='byear']"), contact.Byear);
            new SelectElement(driver.FindElement(By.CssSelector("select[name='aday']"))).SelectByText(contact.Aday);
            new SelectElement(driver.FindElement(By.CssSelector("select[name='amonth']"))).SelectByText(contact.Amonth);
            Type(By.CssSelector("input[name='ayear']"), contact.Ayear);
            Type(By.CssSelector("textarea[name='address2']"), contact.Address2);
            Type(By.CssSelector("input[name='phone2']"), contact.Phone2);
            Type(By.CssSelector("textarea[name='notes']"), contact.Notes);
            return this;
        }

        /// <summary>
        /// Метод, который инициализирует добавление нового контакта
        /// </summary>
        /// <returns></returns>
        public ContactHelper InitNewContact()
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
            contactCache = null;
            return this;
        }

        /// <summary>
        /// Метод, который подтверждает редактирование контакта
        /// </summary>
        /// <returns></returns>
        public ContactHelper SubmitModification()
        {
            driver.FindElement(By.CssSelector("input[name='update']")).Click();
            contactCache = null;
            return this;
        }
        /// <summary>
        /// Метод, который переход в форму редактирования контакта 
        /// </summary>
        /// <param name="index"></param>
        public void InitContactModification(int index) => driver.FindElements(By.CssSelector("[title='Edit']"))[index].Click();

        private List<ContactData> contactCache = null;

        /// <summary>
        /// Запись всех контактов на странице в один лист
        /// </summary>
        /// <returns></returns>
        public List<ContactData> GetContactList()
        {
            if (contactCache == null) 
            { 
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                var elements = driver.FindElements(By.CssSelector("#maintable [name='entry']"));
                foreach (IWebElement element in elements)
                {
                contactCache.Add(new ContactData(
                    element.FindElement(By.CssSelector("td:nth-child(3)")).Text,
                    element.FindElement(By.CssSelector("td:nth-child(2)")).Text)
                    {                        
                    Id = element.FindElement(By.CssSelector("input")).GetAttribute("id")
                    });
                }
            }
                return new List<ContactData>(contactCache);
        }

        /// <summary>
        /// Метод, который получается информацию из таблицы
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        internal ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            return new ContactData()
            {
                Lastname = cells[1].Text,
                Firstname = cells[2].Text,
                Address = cells[3].Text,
                AllEmails = cells[4].Text,
                AllPhones = cells[5].Text,
            };
        }

        /// <summary>
        /// Метод, который получает информацию из формы редактирования
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        internal ContactData GetContactInformationEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(index);

            return new ContactData()
            {
                Firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value"),
                Lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value"),
                Middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value"),
                Nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value"),
                Company = driver.FindElement(By.Name("company")).GetAttribute("value"),
                Title = driver.FindElement(By.Name("title")).GetAttribute("value"),
                Address = driver.FindElement(By.Name("address")).GetAttribute("value"),
                HomePhone = driver.FindElement(By.Name("home")).GetAttribute("value"),
                MobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value"),
                WorkPhone = driver.FindElement(By.Name("work")).GetAttribute("value"),
                Fax = driver.FindElement(By.Name("fax")).GetAttribute("value"),
                Email = driver.FindElement(By.Name("email")).GetAttribute("value"),
                Email2 = driver.FindElement(By.Name("email2")).GetAttribute("value"),
                Email3 = driver.FindElement(By.Name("email3")).GetAttribute("value"),
                Homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value"),
                Bday = driver.FindElement(By.Name("bday")).GetAttribute("value"),
                Bmonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value"),
                Byear = driver.FindElement(By.Name("byear")).GetAttribute("value"),
                Aday = driver.FindElement(By.Name("aday")).GetAttribute("value"),
                Amonth = driver.FindElement(By.Name("amonth")).GetAttribute("value"),
                Ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value"),
                Address2 = driver.FindElement(By.Name("address2")).GetAttribute("value"),
                Phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value"),
                Notes = driver.FindElement(By.Name("notes")).GetAttribute("value"),
            };
        }

        /// <summary>
        /// Считает количество контактов на странице
        /// </summary>
        /// <returns></returns>
        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("#maintable [name='entry']")).Count;
        }
    }
}
