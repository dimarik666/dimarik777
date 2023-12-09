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
        public string contactDetails;
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
        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public string Aday { get; set; }
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
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        Dictionary<int, string> MonthListBirthday = new Dictionary<int, string>()
        {
            {0, "-" },
            {1, "January" },
            {2, "February" },
            {3, "March" },
            {4, "April" },
            {5, "May" },
            {6, "June" },
            {7, "July" },
            {8, "August" },
            {9, "September" },
            {10, "October" },
            {11, "November" },
            {12, "December" }
        };
        public string UpperFirstChar(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            return char.ToUpper(input[0]) + input.Substring(1);
        }
        public string TotalAgeAnniversary
        {
            get
            {
                if (!int.TryParse(Ayear, out int ayearResult))
                    return "";
                else if (ayearResult < 1874)
                    return "";

                DateTime dateToday = DateTime.Today;
                DateTime dateAnniversary = new DateTime(ayearResult, MonthListBirthday.First(x => x.Value == UpperFirstChar(Amonth)).Key, int.Parse(Aday));
                TimeSpan ageAnniversary = dateToday - dateAnniversary;
                int totalAgeAnniversary = ageAnniversary.Days / 365;
                return totalAgeAnniversary.ToString();
            }
        }
        public string TotalAgeBirthday
        {
            get
            {
                if (!int.TryParse(Byear, out int byearResult))
                    return "";
                else if (byearResult < 1874)
                    return "";

                DateTime dateToday = DateTime.Today;
                DateTime dateBirthday = new DateTime(byearResult, MonthListBirthday.First(x => x.Value == UpperFirstChar(Bmonth)).Key, int.Parse(Bday));
                TimeSpan ageBirthday = dateToday - dateBirthday;
                int totalAgeBirthday = ageBirthday.Days / 365;
                return totalAgeBirthday.ToString();
            }
        }
        public string ContactDetails
        {
            get
            {
                if (contactDetails != null)
                {
                    return contactDetails;
                }

                else
                {
                    string finishAgeBirthday = TotalAgeBirthday != "" ? " (" + TotalAgeBirthday + ")" : "";
                    string finishAgeAnniversary = TotalAgeAnniversary != "" ? " (" + TotalAgeAnniversary + ")" : "";

                    return
                        (Firstname + " " + Middlename + " " + Lastname + "\r\n"
                        + Nickname + "\r\n"
                        + Title + "\r\n"
                        + Company + "\r\n"
                        + Address + "\r\n\r\n"
                        + "H: " + HomePhone + "\r\n"
                        + "M: " + MobilePhone + "\r\n"
                        + "W: " + WorkPhone + "\r\n"
                        + "F: " + Fax + "\r\n\r\n"
                        + Email + "\r\n"
                        + Email2 + "\r\n"
                        + Email3 + "\r\n"
                        + "Homepage:" + "\r\n" + Homepage + "\r\n\r\n"
                        + "Birthday " + Bday + ". " + UpperFirstChar(Bmonth) + " " + Byear + finishAgeBirthday + "\r\n"
                        + "Anniversary " + Aday + ". " + UpperFirstChar(Amonth) + " " + Ayear + finishAgeAnniversary + "\r\n\r\n"
                        + Address2 + "\r\n\r\n"
                        + "P: " + Phone2 + "\r\n\r\n"
                        + Notes).Trim();
                }
            }
            set
            {
                contactDetails = value;
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