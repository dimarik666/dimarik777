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
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }
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
        public string TotalAgeAnniversary
        {
            get
            {
                int totalAgeAnniversary;
                if (!int.TryParse(Ayear, out int ayearResult))
                    return "";
                else if (ayearResult < 1874)
                    return "";
                else if (ayearResult >= 2023 & ayearResult < 2200)
                {
                    totalAgeAnniversary = 2023 - ayearResult;
                    return "(" + totalAgeAnniversary.ToString() + ")";
                }
                else if (ayearResult > 2200)
                {
                    return "";
                }

                totalAgeAnniversary = 2023 - ayearResult;
                return "(" + totalAgeAnniversary.ToString() + ")";
            }
        }
        public string TotalAgeBirthday
        {
            get
            {
                int totalAgeBirthday;
                if (!int.TryParse(Byear, out int byearResult))
                    return "";
                else if (byearResult < 1874)
                    return "";
                else if (byearResult >= 2023 & byearResult < 2200)
                {
                    totalAgeBirthday = 2023 - byearResult;
                    return "(" + totalAgeBirthday.ToString() + ")";
                }
                else if(byearResult > 2200)
                {
                    return "";
                }

                totalAgeBirthday = 2023 - byearResult;
                return "(" + totalAgeBirthday.ToString() + ")";
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
                    string finishAgeBirthday = !string.IsNullOrEmpty(TotalAgeBirthday) ? TotalAgeBirthday : "";
                    string finishAgeAnniversary = !string.IsNullOrEmpty(TotalAgeAnniversary) ? TotalAgeAnniversary : "";
                    string finishHomePhone = string.IsNullOrEmpty(HomePhone) ? "" : "H:" + HomePhone;
                    string finishMobilePhone = string.IsNullOrEmpty(MobilePhone) ? "" : "M:" + MobilePhone;
                    string finishWorkPhone = string.IsNullOrEmpty(WorkPhone) ? "" : "W:" + WorkPhone;
                    string finishFax = string.IsNullOrEmpty(Fax) ? "" : "F:" + Fax;
                    string finishHomepage = string.IsNullOrEmpty(Homepage) ? "" : "Homepage:" + Homepage;
                    string finishBday = string.IsNullOrEmpty(Bday) ? "" : "Birthday" + Bday + ".";
                    string finishBmonth = string.IsNullOrEmpty(Bmonth) || Bmonth == "-" ? "" : UpperFirstChar(Bmonth);
                    string finishByear = string.IsNullOrEmpty(Byear) ? "" : Byear;
                    string finishAday = string.IsNullOrEmpty(Aday) ? "" : "Anniversary" + Aday + ".";
                    string finishAmonth = string.IsNullOrEmpty(Amonth) || Amonth == "-" ? "" : UpperFirstChar(Amonth);
                    string finishAyear = string.IsNullOrEmpty(Ayear) ? "" : Ayear;
                    string finishPhone2 = string.IsNullOrEmpty(Phone2) ? "" : "P:" + Phone2;

                    return
                        ($"{Firstname}{Middlename}{Lastname}{Nickname}{Title}{Company}{Address}" +
                        $"{finishHomePhone}{finishMobilePhone}{finishWorkPhone}{finishFax}" +
                        $"{AllEmails}{finishHomepage}" +
                        $"{finishBday}{finishBmonth}{finishByear}{finishAgeBirthday}" +
                        $"{finishAday}{finishAmonth}{finishAyear}{finishAgeAnniversary}" +
                        $"{Address2}{finishPhone2}{Notes}").Trim();
                }
            }
            set
            {
                contactDetails = value;
            }
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