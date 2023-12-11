using System;
using System.Collections.Generic;
using System.IO;
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
        public static Random rnd = new Random();

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
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
            string[] x = { "-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" };
            return x[new Random().Next(0, x.Length)];
        }
        public static string GenerateRandomMonth()
        {
            string[] y = { "-", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            return y[new Random().Next(0, y.Length)];
        }
        public static string GenerateRandomYear()
        {
            int d = rnd.Next(DateTime.MinValue.Year, DateTime.Today.Year);
            return d.ToString();
        }
    }
}