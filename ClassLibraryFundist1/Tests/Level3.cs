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
    public class Level3 : AuthTestBase
    {
        [Test]
        public void TestLevel3()
        {
            app.Navigator.OpenHomePage();
            app.Navigator.GoToAffiliatesReports();
            app.Affiliates.SubmitButtonSearch();
            app.Affiliates.CheckAffiliateAtReport();
            app.Affiliates.SortFirstDepositsCount();
            app.Navigator.GoToAffiliateToLevelSecond();
            AffiliateData fromSecondLevel = app.Affiliates.GetAffiliateReportsFromSecondLvlTotalFromDate(0);
            app.Navigator.GoToAffiliateToLevelThird();
            UserData fromThirdLevel = app.Affiliates.GetAffiliateReportsFromThirdLvl(0);
            Assert.AreEqual(fromSecondLevel.AmountOfDepositsEUR, fromThirdLevel.TotalAmount);
            Assert.AreEqual(fromSecondLevel.AmountFirstDeposits, fromThirdLevel.AmountOfFirstDeposits);
            Assert.AreEqual(fromSecondLevel.GGR, fromThirdLevel.GGR);
            Assert.AreEqual(fromSecondLevel.NGR, fromThirdLevel.NGR);
            Assert.AreEqual(fromSecondLevel.AdminFee, fromThirdLevel.AdminFee);
            Assert.AreEqual(fromSecondLevel.BonusTurnovers, fromThirdLevel.BonusTurnovers);
            Assert.AreEqual(fromSecondLevel.CPA, fromThirdLevel.CPA);
            Assert.AreEqual(fromSecondLevel.RS, fromThirdLevel.RS);
            Assert.AreEqual(fromSecondLevel.ProcentFromCPA, fromThirdLevel.ProcentFromCPA);
            Assert.AreEqual(fromSecondLevel.ProcentFromRS, fromThirdLevel.ProcentFromRS);
            Assert.AreEqual(fromSecondLevel.ProcentFromRevenue, fromThirdLevel.ProcentFromRevenue);
            Assert.AreEqual(fromSecondLevel.Profit, fromThirdLevel.Profit);
            if (app.Affiliates.GetGGR() & app.Affiliates.GetFirstDeposit() & app.Affiliates.GetProfit() == true)
                app.Navigator.GoToAffiliateLevelFourth();
            Thread.Sleep(10000);               
            app.Auth.Logout();
        }
    }
}
