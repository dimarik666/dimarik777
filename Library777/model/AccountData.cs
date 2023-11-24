using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAdressBookTests
{    public class AccountData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public AccountData(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
