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
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public string Name { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public string Id { get; set; }
        public GroupData(string name)
        {
            Name = name;
        }
        public GroupData()
        {

        }

        /// <summary>
        /// Сравнение на равенство полученных значений.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name  && Header == other.Header && Footer == other.Footer;
        }
        public override int GetHashCode()
        {
            return (Name + Header + Footer).GetHashCode();
        }
        public override string ToString()
        {
            return
                "ИМЯ= " + Name + ", " +
                "Header= " + Header + ", " +
                "Footer= " + Footer;
        }
        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
        /// <summary>
        /// Метод, который возвращает валидную тестовую группу
        /// </summary>
        /// <returns></returns>
        public GroupData GetTestingGroup()
        {
            GroupData getGroup = new GroupData()
            {
                Name = "test_name",
                Header = "test_header",
                Footer = "test_footer"
            };
            return getGroup;
        }
    }
}