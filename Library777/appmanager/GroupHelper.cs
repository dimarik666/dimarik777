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
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        /// <summary>
        /// Создание новой группы
        /// </summary>
        /// <param name="group">Данные, которые заполняются при создании новой группы</param>
        /// <returns></returns>
        public GroupHelper CreateNewGroup(GroupData group)
        {
            manager.Navigator.OpenHomePage();
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            return this;
        }

        /// <summary>
        /// Метод, который редактирует группу
        /// </summary>
        /// <param name="p">Порядковый номер группы, которую необходимо отредактировать</param>
        /// <param name="newData">Новые данные, которые вносятся при редактировании группы</param>
        /// <returns></returns>
        public GroupHelper ModificationGroup(int p, GroupData newData)
        {
            manager.Navigator.OpenHomePage();
            manager.Navigator.GoToGroupsPage();
            CheckGroup(newData);
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            return this;
        }

        /// <summary>
        /// Удаление первой в списке группы
        /// </summary>
        /// <param name="p">Порядковый номер группы, которая будет удалена</param>
        /// <returns></returns>
        public GroupHelper RemoveGroup(int p, GroupData newData)
        {
            manager.Navigator.OpenHomePage();
            CheckGroup(newData);
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            SubmitRemoveGroup();
            return this;
        }

        /// <summary>
        /// Подтверждение удаления группы
        /// </summary>
        /// <returns></returns>
        public GroupHelper SubmitRemoveGroup()
        {
            driver.FindElement(By.CssSelector("input[name='delete']")).Click();
            return this;
        }

        /// <summary>
        /// Выбор чекбокса группы
        /// </summary>
        /// <param name="index">порядковый номер чекбокса</param>
        /// <returns></returns>
        public GroupHelper CheckGroup(GroupData newData)
        {
            var groupsCount = driver.FindElements(By.XPath("(//input[@name='selected[]'])")).Count;
            if (groupsCount == 0)
                CreateNewGroup(newData);
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]']) [" + index + "]")).Click();
            return this;
        }

        /// <summary>
        /// Метод, который подтверждает создание группы
        /// </summary>
        /// <returns></returns>
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.CssSelector("input[name='submit']")).Click();
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

        /// <summary>
        /// Подтверждение редактирования группы
        /// </summary>
        /// <returns></returns>
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.CssSelector("input[name='update']")).Click();
            return this;
        }

        /// <summary>
        /// Инициализация инпута для редактирования группы
        /// </summary>
        /// <returns></returns>
        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.CssSelector("input[name='edit']")).Click();
            return this;
        }
    }
}
