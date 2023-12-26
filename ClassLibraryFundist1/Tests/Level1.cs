using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestFundist
{
    public class Level1 : AuthTestBase
    {
        [Test]
        public void TestLevel1()
        {
            app.Navigator.OpenHomePage();
            app.Navigator.GoToAffiliatesReports();
            app.Affiliates.SubmitButtonSearch();
            app.Affiliates.CheckAffiliateAtReport();
            app.Affiliates.SortFirstDepositsCount();
            app.Affiliates.GetAffiliateReportsFromFirstLvl(1);
            app.Affiliates.GoToAffiliateToLevelSecond();
            Thread.Sleep(10000);
            app.Auth.Logout();
            app.Auth.Logout();
        }
    }
}
