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
    public class Level2 : AuthTestBase
    {
        [Test]
        public void TestLevel2() 
        {
            app.Navigator.OpenHomePage();
            app.Navigator.GoToAffiliatesReports();
            app.Affiliates.SubmitButtonSearch();
            app.Affiliates.CheckAffiliateAtReport();
            app.Affiliates.SortFirstDepositsCount();
            AffiliateData fromFirstLevel = app.Affiliates.GetAffiliateReportsFromFirstLvl(1);
            app.Affiliates.GoToAffiliateToLevelSecond();
            AffiliateData fromSecondLevel = app.Affiliates.GetAffiliateReportsFromSecondLvl(0);
            Assert.AreEqual(fromFirstLevel.UniqueVisitors, fromSecondLevel.UniqueVisitors);
            Assert.AreEqual(fromFirstLevel.Registration, fromSecondLevel.Registration);
            Assert.AreEqual(fromFirstLevel.ActivePlayers, fromSecondLevel.ActivePlayers);
            Assert.AreEqual(fromFirstLevel.NumberOfDeposits, fromSecondLevel.NumberOfDeposits);
            Assert.AreEqual(fromFirstLevel.AmountOfDepositsEUR, fromSecondLevel.AmountOfDepositsEUR);
            Assert.AreEqual(fromFirstLevel.NumberOfFirstDeposits, fromSecondLevel.NumberOfFirstDeposits);
            Assert.AreEqual(fromFirstLevel.AmountOfFirstDepositsEUR, fromSecondLevel.AmountOfFirstDepositsEUR);
            Assert.AreEqual(fromFirstLevel.GGR, fromSecondLevel.GGR);
            Assert.AreEqual(fromFirstLevel.NGR, fromSecondLevel.NGR);
            Assert.AreEqual(fromFirstLevel.AdminFee, fromSecondLevel.AdminFee);
            Assert.AreEqual(fromFirstLevel.ActivePlayers, fromSecondLevel.ActivePlayers);
            Assert.AreEqual(fromFirstLevel.BonusTurnovers, fromSecondLevel.BonusTurnovers);
            Assert.AreEqual(fromFirstLevel.ProfitCPA, fromSecondLevel.ProfitCPA);
            Assert.AreEqual(fromFirstLevel.ProfitRS, fromSecondLevel.ProfitRS);
            Assert.AreEqual(fromFirstLevel.Profit, fromSecondLevel.Profit);
            Assert.AreEqual(fromFirstLevel.Withdraws, fromSecondLevel.Withdraws);
            Assert.AreEqual(fromFirstLevel.Manual, fromSecondLevel.Manual);
            app.Affiliates.GoToAffiliateToLevelThird();
            Thread.Sleep(1000);
            app.Auth.Logout();
        }
    }
}
