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

        /// <summary>
        /// Метод, который генерирует случайное строковое значение
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static string GenerateRandomString(int max)
        {
            char[] strings = "ABCDEFGHIJKLMNOPQRSTUVWXYZ~!@#$%^&*()№;%:?*,/".ToCharArray();
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            string word = "";
            for (int i = 0; i < l; i++)
            {
                int letter_num = rnd.Next(0, strings.Length - 1);
                word += strings[letter_num];
            }
            return word.ToString();
        }
        /// <summary>
        /// Метод, который генерирует случайное числовое значение в выбранной диапозоне
        /// </summary>
        /// <param name="minValue">Минимальное значение в диапазоне</param>
        /// <param name="maxValue">Максимальное значение в диапазоне</param>
        /// <returns></returns>
        public static int GetRandomNumber(int minValue, int maxValue)
        {
            Thread.Sleep(100);
            return rnd.Next(minValue, maxValue);
        }
        /// <summary>
        /// Генератор случайного месяца.
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomMonth()
        {
            string[] y = { "-", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            return y[GetRandomNumber(0, 13)];
        }
        /// <summary>
        /// Метод, который генерирует случайный год. Может быть как буквенное значение + символы, так и числовоею
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomYear()
        {
            string z = GenerateRandomString(4);
            int q = rnd.Next(0, 2);
            if (q == 1)
            {
                return z;
            }
            int d = rnd.Next(-999, 9999);
            return d.ToString();
        }
    }
}