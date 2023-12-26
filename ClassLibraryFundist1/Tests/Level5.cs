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
    public class Level5 : AuthTestBase
    {
        [Test]
        public void TestLevel5()
        {
            app.Navigator.OpenHomePage();
            app.Navigator.GoToAffiliatesReports();
            app.Affiliates.SubmitButtonSearch();
            app.Affiliates.CheckAffiliateAtReport();
            app.Affiliates.SortFirstDepositsCount();
            app.Navigator.GoToAffiliateToLevelSecond();
            app.Navigator.GoToAffiliateToLevelThird();
            app.Navigator.GoToAffiliateLevelFourth();
            app.Affiliates.GetDataFromUserCard();
            app.Navigator.GoToLevelFifth();
            app.Affiliates.FindFirstDepositDate();
            app.Affiliates.FindFirstDeposit();
            app.Auth.Logout();
        }
    }
}
