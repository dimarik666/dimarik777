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
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allPhones;

        public string allEmails;
        public string contactDetails;
        [Column(Name = "firstname")]
        public string Firstname { get; set; }
        [Column(Name = "middlename")]
        public string Middlename { get; set; }
        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        [Column(Name = "nickname")]
        public string Nickname { get; set; }
        [Column(Name = "title")]
        public string Title { get; set; }
        [Column(Name = "company")]
        public string Company { get; set; }
        [Column(Name = "address")]
        public string Address { get; set; }
        [Column(Name = "home")]
        public string HomePhone { get; set; }
        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }
        [Column(Name = "work")]
        public string WorkPhone { get; set; }
        [Column(Name = "fax")]
        public string Fax { get; set; }
        [Column(Name = "email")]
        public string Email { get; set; }
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        [Column(Name = "email3")]
        public string Email3 { get; set; }
        [Column(Name = "homepage")]
        public string Homepage { get; set; }
        private string bday;
        [Column(Name = "bday")]
        public string Bday
        {
            get
            {
                return bday;
            }
            set
            {
                if (!int.TryParse(value, out int val) || (val < 0 || val > 31))
                    throw new ArgumentException();
                if (val == 0)
                    bday = "-";
                else
                    bday = value;
            }
        }
        [Column(Name = "bmonth")]
        public string Bmonth { get; set; }
        [Column(Name = "byear")]
        public string Byear { get; set; }
        private string aday;
        [Column(Name = "aday")]
        public string Aday
        {
            get
            {
                return aday;
            }
            set
            {
                if (!int.TryParse(value, out int val) || (val < 0 || val > 31))
                    throw new ArgumentException();
                if (val == 0)
                    aday = "-";
                else
                    aday = value;
            }
        }
        [Column(Name = "amonth")]
        public string Amonth { get; set; }
        [Column(Name = "ayear")]
        public string Ayear { get; set; }
        [Column(Name = "address2")]
        public string Address2 { get; set; }
        [Column(Name = "phone2")]
        public string Phone2 { get; set; }
        [Column(Name = "notes")]
        public string Notes { get; set; }
        [Column(Name = "id")]
        public string Id {  get; set; }
        [Column(Name = "deprecated")]
        public string Deprecated {  get; set; }
        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select g).ToList();
            }
        }
        public string AllEmails
        {
            get
            {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
            }
            set
            {
                allEmails = value;
            }
        }

        public string UpperFirstChar(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            return char.ToUpper(input[0]) + input.Substring(1);
        }
        /// <summary>
        /// Метод, который получает строкой все данные по контакту
        /// </summary>
        /// <returns></returns>
        public string GetAllString()
        {
            string getAllString = "";
            getAllString = (Firstname + " " + Middlename + " " + Lastname + Nickname + Title + Company + Address +
            (string.IsNullOrEmpty(HomePhone) ? "" : "H: " + HomePhone) +
            (string.IsNullOrEmpty(MobilePhone) ? "" : "M: " + MobilePhone) +
            (string.IsNullOrEmpty(WorkPhone) ? "" : "W: " + WorkPhone) +
            (string.IsNullOrEmpty(Fax) ? "" : "F: " + Fax) + AllEmails +
            (string.IsNullOrEmpty(Homepage) ? "" : "Homepage:" + Homepage) +
            GetAllBirthday() + GetAllAnniversary() +
            Address2 + (string.IsNullOrEmpty(Phone2) ? "" : "P: " + Phone2) +
            Notes).Replace("\r\n", "");
            return getAllString.Trim();
        }
        /// <summary>
        /// Метод, получает день юбилея контакта целиком. День юбилея + месяц + год + разницу лет.
        /// </summary>
        /// <returns></returns>
        private string GetAllAnniversary()
        {
            string getAllAnniversary = string.Empty;
            if (!string.IsNullOrEmpty(Aday) && Aday != "-")
                getAllAnniversary += "Anniversary " + Aday + ". ";
            if (!string.IsNullOrEmpty(Amonth) && Amonth != "-")
                getAllAnniversary += UpperFirstChar(Amonth) + " ";
            if (!string.IsNullOrEmpty(Ayear))
            {
                if (int.TryParse(Ayear, out int value))
                {
                    getAllAnniversary += Ayear;
                    int yearNow = DateTime.Now.Year;
                    if (value > (yearNow - 149) && value < (yearNow + 177))
                    {
                        getAllAnniversary += "(" + (yearNow - value) + ")";
                    }
                }
                else
                    getAllAnniversary += Ayear;
            }
            return getAllAnniversary.Trim();
        }
        /// <summary>
        /// Метод, получает день рождения контакта целиком. День рождения + месяц + год + разницу лет.
        /// </summary>
        /// <returns></returns>
        private string GetAllBirthday()
        {
            string getAllBnniversary = string.Empty;
            if (!string.IsNullOrEmpty(Bday) && Bday != "-")
                getAllBnniversary += "Birthday " + Bday + ". ";
            if (!string.IsNullOrEmpty(Bmonth) && Bmonth != "-")
                getAllBnniversary += UpperFirstChar(Bmonth) + " ";
            if (!string.IsNullOrEmpty(Byear))
            {
                if (int.TryParse(Byear, out int value))
                {
                    getAllBnniversary += Byear;
                    int yearNow = DateTime.Now.Year;
                    if (value > (yearNow - 149) && value < (yearNow + 177))
                    {
                        getAllBnniversary += "(" + (yearNow - value) + ")";
                    }
                }
                else
                    getAllBnniversary += Byear;
            }
            return getAllBnniversary.Trim();
        }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(Phone2)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public ContactData()
        {

        }
        /// <summary>
        /// Вспомогательный метод, который очищает значение от необязательных символов
        /// </summary>
        /// <param name="meaning"></param>
        /// <returns></returns>
        private string CleanUp(string replacement)
        {
            if (replacement == null || replacement == "")
            {
                return "";
            }
            return Regex.Replace(replacement, "[ -()]", "") + "\r\n";
        }

        /// <summary>
        /// Сравнение на равенство полученных значений.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }
        public override int GetHashCode()
        {
            return (Firstname + Lastname).GetHashCode();
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            var result = Firstname.CompareTo(other.Firstname);
            if ( result != 0)
            {
                return result;
            }
            return Lastname.CompareTo(other.Lastname);
        }
        public override string ToString()
        {
            return
                "Firstname = " + Firstname + ", " +
                "Middlename = " + Middlename + ", " +
                "Lastname = " + Lastname + ", " +
                "Nickname = " + Nickname + ", " +
                "Company = " + Company + ", " +
                "Title = " + Title + ", " +
                "Address = " + Address + ", " +
                "Homephone = " + HomePhone + ", " +
                "Mobilephone = " + MobilePhone + ", " +
                "Workphone = " + WorkPhone + ", " +
                "Fax = " + Fax + ", " +
                "Email = " + Email + ", " +
                "Email2 = " + Email2 + ", " +
                "Email3 = " + Email3 + ", " +
                "Homepage = " + Homepage + ", " +
                "Bday = " + Bday + ", " +
                "Bmonth = " + Bmonth + ", " +
                "Byear = " + Byear + ", " +
                "Aday = " + Aday + ", " +
                "Amonth = " + Amonth + ", " +
                "Ayear = " + Ayear + ", " +
                "SecondAddress = " + Address2 + ", " +
                "Phone2 = " + Phone2 + ", " +
                "Notes = " + Notes;
        }
        /// <summary>
        /// Метод, который возвращает валидный тестовый контакт
        /// </summary>
        /// <returns></returns>
        public static ContactData GetTestingContact()
        {
            ContactData getContact = new ContactData()
            {
                Firstname = "Oleg_test",
                Lastname = "Olegov_test",
                Middlename = "Ivanovich_test",
                Nickname = "Ivasik_test",
                Title = "Popile_test",
                Company = "Mapany_test",
                Address = "Kertegg_test",
                HomePhone = "777777",
                MobilePhone = "911002233",
                WorkPhone = "99999999999",
                Fax = "Safafaf_test",
                Email = "test@gmail.com",
                Email2 = "test2@gmail.com",
                Email3 = "test3@gmail.com",
                Homepage = "www.test.com",
                Bday = "30",
                Bmonth = "June",
                Byear = "2000",
                Aday = "20",
                Amonth = "November",
                Ayear = "2002",
                Address2 = "Swwerqt_test",
                Phone2 = "911",
                Notes = "Zametki_test"
            };
            return getContact;
        }

    }
}