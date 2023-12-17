using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using LinqToDB.Mapping;

namespace WebAdressBookTests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        [Column(Name = "group_name")]
        public string Name { get; set; }
        [Column(Name = "group_header")]
        public string Header { get; set; }
        [Column(Name = "group_footer")]
        public string Footer { get; set; }
        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }
        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }
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
        public static GroupData GetTestingGroup()
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