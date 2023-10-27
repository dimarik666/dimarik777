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
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }
        /// <summary>
        /// Создание новой группы
        /// </summary>
        /// <param name="group">Данные, которые запаолняются при создании новой группы</param>
        /// <returns></returns>
        public GroupHelper CreateNewGroup(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }
        /// <summary>
        /// Удаление группы
        /// </summary>
        /// <param name="p">Порядковый номер группы, которая будет удалена</param>
        /// <returns></returns>
        public GroupHelper RemoveGroup(int p)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(1);
            SubmitDeleteGroup();
            ReturnToGroupsPage();
            return this;
        }
        /// <summary>
        /// Подтверждение удаления группы
        /// </summary>
        /// <returns></returns>
        public GroupHelper SubmitDeleteGroup()
        {
            driver.FindElement(By.CssSelector("input[name='delete']")).Click();
            return this;
        }
        /// <summary>
        /// Выбор чекбокса группы
        /// </summary>
        /// <param name="index">порядковый номер чекбокса</param>
        /// <returns></returns>
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]']) [" + index + "]")).Click();
            return this;
        }
        /// <summary>
        /// Метод, который возвращает на страницу групп
        /// </summary>
        /// <returns></returns>
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.CssSelector("a[href='group.php']")).Click();
            return this;
        }
        /// <summary>
        /// Метод, который подтверждает создание группы
        /// </summary>
        /// <returns></returns>
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[name='submit']"));
            return this;
        }
        /// <summary>
        /// Метод, который заполняет поля новой группы
        /// </summary>
        /// <param name="group">Поля, которые метод заполнит</param>
        /// <returns></returns>
        public GroupHelper FillGroupForm(GroupData group)
        {
            driver.FindElement(By.CssSelector("input[name='group_name']")).Clear();
            driver.FindElement(By.CssSelector("input[name='group_name']")).SendKeys(group.Name);
            driver.FindElement(By.CssSelector("textarea[name='group_header']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='group_header']")).SendKeys(group.Header);
            driver.FindElement(By.CssSelector("textarea[name='group_footer']")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='group_footer']")).SendKeys(group.Footer);
            return this;
        }
        /// <summary>
        /// Метод, который инициализирует создание группы
        /// </summary>
        /// <returns></returns>
        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[name='new']")).Click();
            return this;
        }


    }
}
