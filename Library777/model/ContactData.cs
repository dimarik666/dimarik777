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

namespace WebAdressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allPhones;

        public string allEmails;

        //public string contactDetails;
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        private string bday;
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

        public string Bmonth { get; set; }
        public string Byear { get; set; }
        private string aday;
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
        public string Amonth { get; set; }
        public string Ayear { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get; set; }
        public string Id {  get; set; }
        public string AllEmails
        {
            get
            {
                return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
            }
            set
            {
                allEmails = value;
            }
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
                    return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone) + CleanUpPhone(Phone2)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }
        
        /// <summary>
        /// Метод, который используется для превращения строчной буквы в прописную
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string UpperFirstChar(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            return char.ToUpper(input[0]) + input.Substring(1);
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
        /// Вспомогательный метод, который очищает значение от необязательных символов для телефонов
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        private string CleanUpPhone(string phone)
        {
            if (String.IsNullOrEmpty(phone))
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + Environment.NewLine;
        }
        /// <summary>
        /// Вспомогательный метод, который очищает значение от необязательных символов для емейлов
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private string CleanUpEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                return "";
            }
            return email + Environment.NewLine;
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