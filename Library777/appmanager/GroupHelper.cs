using System;
using System.Collections.Generic;
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
        /// Метод, который создаёт новую группу со страницы групп и возвращает полученное значение.
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
        /// Метод, который редактирует группу со страницы групп и возвращает полученное значение.
        /// </summary>
        /// <param name="p">Порядковый номер группы, которую необходимо отредактировать</param>
        /// <param name="newData">Новые данные, которые вносятся при редактировании группы</param>
        /// <returns></returns>
        public GroupHelper ModificationGroup(int p, GroupData newData)
        {
            manager.Navigator.OpenHomePage();
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            return this;
        }

        /// <summary>
        /// Удаление первой в списке группы путём выбора группы с помощью чекбокса.
        /// </summary>
        /// <param name="p">Порядковый номер группы, которая будет удалена</param>
        /// <returns></returns>
        public GroupHelper RemoveGroup(int p, GroupData newData)
        {
            manager.Navigator.OpenHomePage();
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
        /// Метод, который проверяет наличие хотя бы одной группы на странице
        /// </summary>
        /// <param name="newData">Данные, которые будут использоваться для создания новой группы в случае её отсуствия на странице</param>
        /// <returns></returns>
        public GroupHelper CheckGroup(GroupData newData)
        {
            var groupsCount = driver.FindElements(By.XPath("(//input[@name='selected[]'])")).Count;
            if (groupsCount == 0)
                CreateNewGroup(newData);
            return this;
        }

        /// <summary>
        /// Выбор чекбокса группы
        /// </summary>
        /// <param name="index">порядковый номер чекбокса</param>
        /// <returns></returns>
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]']) [" + (index + 1) + "]")).Click();
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
            Type(By.CssSelector("input[name='group_name']"), group.Name);
            Type(By.CssSelector("textarea[name='group_header']"), group.Header);
            Type(By.CssSelector("textarea[name='group_footer']"), group.Footer);
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

        /// <summary>
        /// Запись всех контактов на странице в один лист
        /// </summary>
        /// <returns></returns>
        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }
    }
}
