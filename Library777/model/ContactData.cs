﻿using System;
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
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
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
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
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
                return Firstname.CompareTo(other.Firstname);
            }
           return Lastname.CompareTo(other.Lastname);
        }
        public override string ToString()
        {
            return
                "Имя = " + Firstname + ", " +
                "Фамилия = " + Lastname;
        }
        public ContactData ReturnContact()
        {
            return this;
        }
    }
}