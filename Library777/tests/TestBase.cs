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
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            char[] strings = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            string word = "";
            for (int i = 0; i < l; i++)
            {
                int letter_num = rnd.Next(0, strings.Length - 1);
                word += strings[letter_num];
            }
            return word.ToString();
        }
        public static string GenerateRandomDay()
        {
            int x = rnd.Next(1, 31);
            return x.ToString();
        }
        public static string GenerateRandomMonth()
        {
            string[] y = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            return y[new Random().Next(0, y.Length)];
        }
        public static string GenerateRandomYear()
        {
            int d = rnd.Next(DateTime.MinValue.Year, DateTime.Today.Year);
            return d.ToString();
        }
    }
}