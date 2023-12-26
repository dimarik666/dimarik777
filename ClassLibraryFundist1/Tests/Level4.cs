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
    public class Level4 : AuthTestBase
    {
        [Test]
        public void TestLevel4()
        {
            app.Navigator.OpenHomePage();
            app.Navigator.GoToAffiliatesReports();
            app.Affiliates.SubmitButtonSearch();
            app.Affiliates.CheckAffiliateAtReport();
            app.Affiliates.SortFirstDepositsCount();
            app.Navigator.GoToAffiliateToLevelSecond();
            app.Navigator.GoToAffiliateToLevelThird();
            UserData fromThirdLevel = app.Affiliates.GetAffiliateReportsFromThirdLvl(0);
            if (app.Affiliates.GetGGR() & app.Affiliates.GetFirstDeposit() & app.Affiliates.GetProfit() == true)
                app.Navigator.GoToAffiliateLevelFourth();
            UserData fromFourthLevel = app.Affiliates.GetAffReportsFromFourthLevel();
            Assert.AreEqual(fromThirdLevel.GGR, fromFourthLevel.GGR);
            Assert.AreEqual(fromThirdLevel.TotalAmount, fromFourthLevel.TotalAmount);
            app.Affiliates.GetDataFromUserCard();
            app.Navigator.GoToLevelFifth();
            app.Auth.Logout();
        }
    }
}
