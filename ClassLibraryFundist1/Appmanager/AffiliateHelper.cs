using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestFundist
{
    public class AffiliateHelper : HelperBase
    {
        public AffiliateHelper(ApplicationManager manager) : base(manager) { }

        public AffiliateData GetAffiliateReportsFromFirstLvl(int index)
        {
            //string affiliateID = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-AffiliateID']")).Text;
            //string loginAndEmail = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-Login']")).Text;
            //string referalCode = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-RefCode']")).Text;
            //string country = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-Country']")).Text;
            //string commissionPlan = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-CommissionPlanName']")).Text;
            string uniqueVisitors = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-Visits']")).Text;
            string registration = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-Registrations']")).Text;
            string activePlayers = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-Players']")).Text;
            string numbersOfDeposits = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-DepositCount']")).Text;
            string amountOfDepositsEUR = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-DepositAmount']")).Text;
            string numberOfFirstDeposits = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-FirstDepositsCount']")).Text;
            string amountOfFirstDepositsEUR = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-FirstDepositsAmount']")).Text;
            string ggr = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-GGR']")).Text;
            string ngr = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-NGR']")).Text;
            string adminFeeEUR = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-AdminFee']")).Text;
            string bonusTurnoverEUR = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-BonusTurnover']")).Text;
            string cpaEUR = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-ProfitCPA']")).Text;
            string rsEUR = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-ProfitRS']")).Text;
            //string procentFromCPA_EUR = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-SubProfitCPA']")).Text;
            //string procentFromRS_EUR = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-SubProfitRS']")).Text;
            //string profitFromRevenueEUR = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-SubProfitRevenue']")).Text;
            string profitEUR = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-Profit']")).Text;
            string withdrawalsEUR = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-Withdraws']")).Text;
            string manualCorrectionsEUR = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-Manual']")).Text;

            return new AffiliateData()
            {
                //AffiliateID = affiliateID,
                //LoginAndEmail = loginAndEmail,
                //ReferalCode = referalCode,
                //Country = country,
                //CommissionPlan = commissionPlan,
                UniqueVisitors = uniqueVisitors,
                Registration = registration,
                ActivePlayers = activePlayers,
                NumberOfDeposits = numbersOfDeposits,
                AmountOfDepositsEUR = amountOfDepositsEUR,
                NumberOfFirstDeposits = numberOfFirstDeposits,
                AmountOfFirstDepositsEUR = amountOfFirstDepositsEUR,
                GGR = ggr,
                NGR = ngr,
                AdminFee = adminFeeEUR,
                BonusTurnovers = bonusTurnoverEUR,
                ProfitCPA = cpaEUR,
                ProfitRS = rsEUR,
                //SubProfitCPA = procentFromCPA_EUR,
                //SubProfitRS = procentFromRS_EUR,
                //SubProfitRevenue = profitFromRevenueEUR,
                Profit = profitEUR,
                Withdraws = withdrawalsEUR,
                Manual = manualCorrectionsEUR
            };
        }
        public AffiliateData GetAffiliateReportsFromSecondLvl(int index)
        {
            string uniqueVisitors = driver.FindElement(By.CssSelector("tfoot td[name='col-Visits']")).Text;
            string registration = driver.FindElement(By.CssSelector("tfoot td[name='col-Registrations']")).Text;
            string activePlayers = driver.FindElement(By.CssSelector("tfoot td[name='col-Players']")).Text;
            string numbersOfDeposits = driver.FindElement(By.CssSelector("tfoot td[name='col-DepositCount']")).Text;
            string amountOfDepositsEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-DepositAmount']")).Text;
            string numberOfFirstDeposits = driver.FindElement(By.CssSelector("tfoot td[name='col-FirstDepositsCount']")).Text;
            string amountOfFirstDepositsEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-FirstDepositsAmount']")).Text;
            string ggr = driver.FindElement(By.CssSelector("tfoot td[name='col-GGR']")).Text;
            string ngr = driver.FindElement(By.CssSelector("tfoot td[name='col-NGR']")).Text;
            string adminFeeEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-AdminFee']")).Text;
            string bonusTurnoverEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-BonusTurnover']")).Text;
            string cpaEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-ProfitCPA']")).Text;
            string rsEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-ProfitRS']")).Text;
            string profitEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-Profit']")).Text;
            string withdrawalsEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-Withdraws']")).Text;
            string manualCorrectionsEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-Manual']")).Text;

            return new AffiliateData()
            {
                UniqueVisitors = uniqueVisitors,
                Registration = registration,
                ActivePlayers = activePlayers,
                NumberOfDeposits = numbersOfDeposits,
                AmountOfDepositsEUR = amountOfDepositsEUR,
                NumberOfFirstDeposits = numberOfFirstDeposits,
                AmountOfFirstDepositsEUR = amountOfFirstDepositsEUR,
                GGR = ggr,
                NGR = ngr,
                AdminFee = adminFeeEUR,
                BonusTurnovers = bonusTurnoverEUR,
                ProfitCPA = cpaEUR,
                ProfitRS = rsEUR,
                Profit = profitEUR,
                Withdraws = withdrawalsEUR,
                Manual = manualCorrectionsEUR
            };
        }

        public AffiliateData GetAffiliateReportsFromThirdLvl(int index)
        {
            //string uniqueVisitors = driver.FindElement(By.CssSelector("tfoot td[name='col-Visits']")).Text;
            //string registration = driver.FindElement(By.CssSelector("tfoot td[name='col-Registrations']")).Text;
            //string activePlayers = driver.FindElement(By.CssSelector("tfoot td[name='col-Players']")).Text;
            //string numbersOfDeposits = driver.FindElement(By.CssSelector("tfoot td[name='col-DepositCount']")).Text;
            string amountOfDepositsEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-TotalDepositAmount']")).Text;
            string dayDepositAmount = driver.FindElement(By.CssSelector("tfoot td[name='col-DayDepositAmount']")).Text;
            string amountOfFirstDepositsEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-FirstDepositsAmount']")).Text;
            string ggr = driver.FindElement(By.CssSelector("tfoot td[name='col-GGR']")).Text;
            string ngr = driver.FindElement(By.CssSelector("tfoot td[name='col-NGR']")).Text;
            string adminFeeEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-AdminFee']")).Text;
            string bonusTurnoverEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-BonusTurnover']")).Text;
            string cpaEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-ProfitCPA']")).Text;
            string rsEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-ProfitRS']")).Text;
            string profitEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-Profit']")).Text;
            string withdrawalsEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-Withdraws']")).Text;
            string manualCorrectionsEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-Manual']")).Text;

            return new AffiliateData()
            {
                UniqueVisitors = uniqueVisitors,
                Registration = registration,
                ActivePlayers = activePlayers,
                NumberOfDeposits = numbersOfDeposits,
                AmountOfDepositsEUR = amountOfDepositsEUR,
                NumberOfFirstDeposits = numberOfFirstDeposits,
                AmountOfFirstDepositsEUR = amountOfFirstDepositsEUR,
                GGR = ggr,
                NGR = ngr,
                AdminFee = adminFeeEUR,
                BonusTurnovers = bonusTurnoverEUR,
                ProfitCPA = cpaEUR,
                ProfitRS = rsEUR,
                Profit = profitEUR,
                Withdraws = withdrawalsEUR,
                Manual = manualCorrectionsEUR
            };
        }
        public void CheckAffiliateAtReport()
        {
            var checkAffiliate = driver.FindElements(By.CssSelector("td[name='col-NoData']")).Count;
            switch (checkAffiliate)
            {                
                case 1:
                    driver.FindElement(By.Id("select2-Month-result-6sta-2023-11")).Click();
                    SubmitButtonSearch();
                    if(checkAffiliate > 0)
                    {
                        goto case 2;
                    }
                    break;
                case 2:
                    driver.FindElement(By.Id("select2-Month-result-6sta-2023-11")).Click();
                    SubmitButtonSearch();
                    if( checkAffiliate > 0)
                    {
                        goto case 3;
                    }
                    break;
                case 3:
                    driver.FindElement(By.Id("select2-Month-result-1c8z-2023-10")).Click();
                    SubmitButtonSearch();
                    if (checkAffiliate > 0)
                    {
                        goto case 4;
                    }
                    break;
                case 4:
                    driver.FindElement(By.Id("select2-Month-result-49z6-2023-9")).Click();
                    SubmitButtonSearch();
                    if (checkAffiliate > 0)
                    {
                        goto case 5;
                    }
                    break;
                case 5:
                    driver.FindElement(By.Id("select2-Month-result-osw5-2023-8")).Click();
                    SubmitButtonSearch();
                    if (checkAffiliate > 0)
                    {
                        goto case 6;
                    }
                    break;
                case 6:
                    driver.FindElement(By.Id("select2-Month-result-0hu9-2023-7")).Click();
                    SubmitButtonSearch();
                    if (checkAffiliate > 0)
                    {
                        goto case 7;
                    }
                    break;
                case 7:
                    driver.FindElement(By.Id("select2-Month-result-ll48-2023-6")).Click();
                    SubmitButtonSearch();
                    if (checkAffiliate > 0)
                    {
                        goto case 8;
                    }
                    break;
                case 8:
                    driver.FindElement(By.Id("select2-Month-result-ss6x-2023-5")).Click();
                    SubmitButtonSearch();
                    if (checkAffiliate > 0)
                    {
                        goto case 9;
                    }
                    break;
                case 9:
                    driver.FindElement(By.Id("select2-Month-result-l4ea-2023-4")).Click();
                    SubmitButtonSearch();
                    if (checkAffiliate > 0)
                    {
                        goto case 10;
                    }
                    break;
                case 10:
                    driver.FindElement(By.Id("select2-Month-result-mlff-2023-3")).Click();
                    SubmitButtonSearch();
                    if (checkAffiliate > 0)
                    {
                        goto case 11;
                    }
                    break;
                case 11:
                    driver.FindElement(By.Id("select2-Month-result-0nrr-2023-2")).Click();
                    SubmitButtonSearch();
                    if (checkAffiliate > 0)
                    {
                        goto case 12;
                    }
                    break;
                case 12:
                    driver.FindElement(By.Id("select2-Month-result-hnsc-2023-1")).Click();
                    SubmitButtonSearch();
                    if (checkAffiliate > 0)
                    {
                        Console.WriteLine("TEST FAILED");
                        Thread.CurrentThread.Abort();
                    }
                    break;
            }
        }

        public AffiliateHelper SortFirstDepositsCount()
        {
            driver.FindElement(By.Id("sortFirstDepositsCount")).Click();
            return this;
        }

        /// <summary>
        /// Клик по кнопке "Найти"
        /// </summary>
        public void SubmitButtonSearch()
        {
            driver.FindElement(By.CssSelector("button[id='ButtonFilter']")).Click();
        }
        public AffiliateHelper GoToAffiliateToLevelSecond()
        {
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("td[name='col-AffiliateID'] a"));
            elements.First().Click();
            return this;
        }
        public AffiliateHelper GoToAffiliateToLevelThird()
        {
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("td[name='col-Date'] a"));
            elements.First().Click();
            return this;
        }
    }
}
