using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAdressBookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void AddContact(ContactData contact)

        {
            driver.FindElement(By.CssSelector("a[href='edit.php']")).Click();
            driver.FindElement(By.CssSelector("input[name='firstname'")).Clear();
            driver.FindElement(By.CssSelector("input[name='firstname'")).SendKeys(contact.Firstname);
            driver.FindElement(By.CssSelector("input[name='middlename'")).Clear();
            driver.FindElement(By.CssSelector("input[name='middlename'")).SendKeys(contact.Middlename);
            driver.FindElement(By.CssSelector("input[name='lastname'")).Clear();
            driver.FindElement(By.CssSelector("input[name='lastname'")).SendKeys(contact.Lastname);
            driver.FindElement(By.CssSelector("input[name='nickname'")).Clear();
            driver.FindElement(By.CssSelector("input[name='nickname'")).SendKeys(contact.Nickname);
            driver.FindElement(By.CssSelector("input[name='title'")).Clear();
            driver.FindElement(By.CssSelector("input[name='title'")).SendKeys(contact.Title);
            driver.FindElement(By.CssSelector("input[name='company'")).Clear();
            driver.FindElement(By.CssSelector("input[name='company'")).SendKeys(contact.Company);
            driver.FindElement(By.CssSelector("textarea[name='address'")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='address'")).SendKeys(contact.Address);
            driver.FindElement(By.CssSelector("input[name='home'")).Clear();
            driver.FindElement(By.CssSelector("input[name='home'")).SendKeys(contact.Home);
            driver.FindElement(By.CssSelector("input[name='mobile'")).Clear();
            driver.FindElement(By.CssSelector("input[name='mobile'")).SendKeys(contact.Mobile);
            driver.FindElement(By.CssSelector("input[name='work'")).Clear();
            driver.FindElement(By.CssSelector("input[name='work'")).SendKeys(contact.Work);
            driver.FindElement(By.CssSelector("input[name='fax'")).Clear();
            driver.FindElement(By.CssSelector("input[name='fax'")).SendKeys(contact.Fax);
            driver.FindElement(By.CssSelector("input[name='email'")).Clear();
            driver.FindElement(By.CssSelector("input[name='email'")).SendKeys(contact.Email);
            driver.FindElement(By.CssSelector("input[name='email2'")).Clear();
            driver.FindElement(By.CssSelector("input[name='email2'")).SendKeys(contact.Email2);
            driver.FindElement(By.CssSelector("input[name='email3'")).Clear();
            driver.FindElement(By.CssSelector("input[name='email3'")).SendKeys(contact.Email3);
            driver.FindElement(By.CssSelector("input[name='homepage'")).Clear();
            driver.FindElement(By.CssSelector("input[name='homepage'")).SendKeys(contact.Homepage);
            new SelectElement(driver.FindElement(By.CssSelector("select[name='bday'"))).SelectByText(contact.Bday);
            new SelectElement(driver.FindElement(By.CssSelector("select[name='bmonth'"))).SelectByText(contact.Bmonth);
            driver.FindElement(By.CssSelector("input[name='byear'")).Clear();
            driver.FindElement(By.CssSelector("input[name='byear'")).SendKeys(contact.Byear);
            new SelectElement(driver.FindElement(By.CssSelector("select[name='aday'"))).SelectByText(contact.Aday);
            new SelectElement(driver.FindElement(By.CssSelector("select[name='amonth'"))).SelectByText(contact.Amonth);
            driver.FindElement(By.CssSelector("input[name='ayear'")).Clear();
            driver.FindElement(By.CssSelector("input[name='ayear'")).SendKeys(contact.Ayear);
            driver.FindElement(By.CssSelector("textarea[name='address2'")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='address2'")).SendKeys(contact.Address2);
            driver.FindElement(By.CssSelector("input[name='phone2'")).Clear();
            driver.FindElement(By.CssSelector("input[name='phone2'")).SendKeys(contact.Phone2);
            driver.FindElement(By.CssSelector("textarea[name='notes'")).Clear();
            driver.FindElement(By.CssSelector("textarea[name='notes'")).SendKeys(contact.Notes);
            driver.FindElement(By.CssSelector("input[name='submit'")).Click();
        }
    }
}
