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

        /// <summary>
        /// Получаем данные по партнёру с первого уровня отчёта
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public AffiliateData GetAffiliateReportsFromFirstLvl(int index)
        {
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
            string profitEUR = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-Profit']")).Text;
            string withdrawalsEUR = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-Withdraws']")).Text;
            string manualCorrectionsEUR = driver.FindElement(By.CssSelector("tbody[class='table-data'] td[name='col-Manual']")).Text;

            return new AffiliateData()
            {
                UniqueVisitors = uniqueVisitors,
                Registration = registration,
                ActivePlayers = activePlayers,
                NumberOfDeposits = numbersOfDeposits,
                AmountOfDepositsEUR = amountOfDepositsEUR,
                NumberOfFirstDeposits = numberOfFirstDeposits,
                AmountFirstDeposits = amountOfFirstDepositsEUR,
                GGR = ggr,
                NGR = ngr,
                AdminFee = adminFeeEUR,
                BonusTurnovers = bonusTurnoverEUR,
                CPA = cpaEUR,
                RS = rsEUR,
                Profit = profitEUR,
                Withdraws = withdrawalsEUR,
                Manual = manualCorrectionsEUR
            };
        }
        /// <summary>
        /// Получаем данные по партнёру со второго уровня по строке по какой-то дате
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public AffiliateData GetAffiliateReportsFromSecondLvlTotalFromDate(int index)
        {
            string uniqueVisitors = driver.FindElement(By.CssSelector("tr td[name='col-Visits']")).Text;
            string registration = driver.FindElement(By.CssSelector("tr td[name='col-Registrations']")).Text;
            string activePlayers = driver.FindElement(By.CssSelector("tr td[name='col-Players']")).Text;
            string numbersOfDeposits = driver.FindElement(By.CssSelector("tr td[name='col-DepositCount']")).Text;
            string amountOfDepositsEUR = driver.FindElement(By.CssSelector("tr td[name='col-DepositAmount']")).Text;
            string numberOfFirstDeposits = driver.FindElement(By.CssSelector("tr td[name='col-FirstDepositsCount']")).Text;
            string amountOfFirstDepositsEUR = driver.FindElement(By.CssSelector("tr td[name='col-FirstDepositsAmount']")).Text;
            string ggr = driver.FindElement(By.CssSelector("tr td[name='col-GGR']")).Text;
            string ngr = driver.FindElement(By.CssSelector("tr td[name='col-NGR']")).Text;
            string adminFeeEUR = driver.FindElement(By.CssSelector("tr td[name='col-AdminFee']")).Text;
            string bonusTurnoverEUR = driver.FindElement(By.CssSelector("tr td[name='col-BonusTurnover']")).Text;
            string cpaEUR = driver.FindElement(By.CssSelector("tr td[name='col-ProfitCPA']")).Text;
            string rsEUR = driver.FindElement(By.CssSelector("tr td[name='col-ProfitRS']")).Text;
            string procentCPA = driver.FindElement(By.CssSelector("tr td[name='col-SubProfitCPA']")).Text;
            string procentRS = driver.FindElement(By.CssSelector("tr td[name='col-SubProfitRS']")).Text;
            string procentFromRevenue = driver.FindElement(By.CssSelector("tr td[name='col-SubProfitRevenue']")).Text;
            string profitEUR = driver.FindElement(By.CssSelector("tr td[name='col-Profit']")).Text;
            string withdrawalsEUR = driver.FindElement(By.CssSelector("tr td[name='col-Withdraws']")).Text;
            string manualCorrectionsEUR = driver.FindElement(By.CssSelector("tr td[name='col-Manual']")).Text;

            return new AffiliateData()
            {
                UniqueVisitors = uniqueVisitors,
                Registration = registration,
                ActivePlayers = activePlayers,
                NumberOfDeposits = numbersOfDeposits,
                AmountOfDepositsEUR = amountOfDepositsEUR,
                NumberOfFirstDeposits = numberOfFirstDeposits,
                AmountFirstDeposits = amountOfFirstDepositsEUR,
                GGR = ggr,
                NGR = ngr,
                AdminFee = adminFeeEUR,
                BonusTurnovers = bonusTurnoverEUR,
                CPA = cpaEUR,
                RS = rsEUR,
                ProcentFromCPA = procentCPA,
                ProcentFromRS = procentRS,
                ProcentFromRevenue = procentFromRevenue,
                Profit = profitEUR,
                Withdraws = withdrawalsEUR,
                Manual = manualCorrectionsEUR
            };
        }
        /// <summary>
        /// Получаем данные по партнёру со второго уровня по ТОТАЛУ
        /// <param name="index"></param>
        /// <returns></returns>
        public AffiliateData GetAffiliateReportsFromSecondLvlTotal(int index)
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
            string procentCPA = driver.FindElement(By.CssSelector("tfoot td[name='col-SubProfitCPA']")).Text;
            string procentRS = driver.FindElement(By.CssSelector("tfoot td[name='col-SubProfitRS']")).Text;
            string procentFromRevenue = driver.FindElement(By.CssSelector("tfoot td[name='col-SubProfitRevenue']")).Text;
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
                AmountFirstDeposits = amountOfFirstDepositsEUR,
                GGR = ggr,
                NGR = ngr,
                AdminFee = adminFeeEUR,
                BonusTurnovers = bonusTurnoverEUR,
                CPA = cpaEUR,
                RS = rsEUR,
                ProcentFromCPA = procentCPA,
                ProcentFromRS = procentRS,
                ProcentFromRevenue = procentFromRevenue,
                Profit = profitEUR,
                Withdraws = withdrawalsEUR,
                Manual = manualCorrectionsEUR
            };
        }
        /// <summary>
        /// Получаем данные по партнёру с третьего уровня по пользователям
        /// <param name="index"></param>
        /// <returns></returns>
        public UserData GetAffiliateReportsFromThirdLvl(int index)
        {
            string totalDepositAmount = driver.FindElement(By.CssSelector("tfoot td[name='col-TotalDepositAmount']")).Text;
            string dayDepositAmount = driver.FindElement(By.CssSelector("tfoot td[name='col-DayDepositAmount']")).Text;
            string amountOfFirstDepositsEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-FirstDepositsAmount']")).Text;
            string ggr = driver.FindElement(By.CssSelector("tfoot td[name='col-GGR']")).Text;
            string ngr = driver.FindElement(By.CssSelector("tfoot td[name='col-NGR']")).Text;
            string adminFeeEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-AdminFee']")).Text;
            string bonusTurnoverEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-BonusTurnover']")).Text;
            string cpaEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-ProfitCPA']")).Text;
            string rsEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-ProfitRS']")).Text;
            string procentFromCPA = driver.FindElement(By.CssSelector("tfoot td[name='col-SubProfitCPA']")).Text;
            string procentFromRS = driver.FindElement(By.CssSelector("tfoot td[name='col-SubProfitRS']")).Text;
            string procentFromRevenue = driver.FindElement(By.CssSelector("tfoot td[name='col-SubProfitRevenue']")).Text;
            string profitEUR = driver.FindElement(By.CssSelector("tfoot td[name='col-Profit']")).Text;

            return new UserData()
            {
                TotalAmount = totalDepositAmount,
                DayAmount = dayDepositAmount,
                AmountOfFirstDeposits = amountOfFirstDepositsEUR,
                GGR = ggr,
                NGR = ngr,
                AdminFee = adminFeeEUR,
                BonusTurnovers = bonusTurnoverEUR,
                CPA = cpaEUR,
                RS = rsEUR,
                ProcentFromCPA = procentFromCPA,
                ProcentFromRS = procentFromRS,
                ProcentFromRevenue = procentFromRevenue,
                Profit = profitEUR,                
            };
        }
        /// <summary>
        /// Получаем данные по партнёру с четверого уровня 
        /// <param name="index"></param>
        /// <returns></returns>
        public UserData GetAffReportsFromFourthLevel()
        {
            string ggr = driver.FindElement(By.CssSelector("tfoot td[name='col-GGR']")).Text;
            string depositAmount = driver.FindElement(By.CssSelector("tfoot td[name='col-DepositAmount']")).Text;
            string withdrawals = driver.FindElement(By.CssSelector("tfoot td[name='col-Withdraws']")).Text;
            return new UserData()
            {
                GGR = ggr,
                TotalAmount = depositAmount,
                Withdrawals = withdrawals,
            };
        }
        /// <summary>
        /// Проверяем наличие данных в таблице Отчёт: Доходы, ()
        /// </summary>
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

        /// <summary>
        /// Сортировка по убыванию столбца количество первых депозитов
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Получение значения "Первый депозит" для дальнейшего сравнения
        /// </summary>
        /// <returns></returns>
        public bool GetFirstDeposit()
        {
            UserData fromThirdLevel = GetAffiliateReportsFromThirdLvl(0);
            int firstDeposit = Int32.Parse(fromThirdLevel.AmountOfFirstDeposits);
            if (firstDeposit > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Получение значения GGR для дальнейшего сравнения
        /// </summary>
        /// <returns></returns>
        public bool GetGGR()
        {
            UserData fromThirdLevel = GetAffiliateReportsFromThirdLvl(0);
            double ggr = Double.Parse(fromThirdLevel.GGR);
            if (ggr != 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Получение значения "Доход" для дальнейшего сравнения
        /// </summary>
        /// <returns></returns>
        public bool GetProfit()
        {
            UserData fromThirdLevel = GetAffiliateReportsFromThirdLvl(0);
            double profit = Double.Parse(fromThirdLevel.Profit);
            if (profit != 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Получение значений из карточки пользователя в партнёрках
        /// </summary>
        /// <returns></returns>
        public UserData GetDataFromUserCard()
        {
            string firstDepositDate = driver.FindElement(By.CssSelector("tbody td[id='FirstDepositDate']")).Text;
            string firstDeposit = driver.FindElement(By.CssSelector("tbody td[id='FirstDeposit']")).Text;
            string ggr = driver.FindElement(By.CssSelector("tbody td[id='GGR']")).Text;
            string userStatus = driver.FindElement(By.CssSelector("tbody td[id='UserStatus']")).Text;

            return new UserData
            {
                FirstDepositDate = firstDepositDate,
                FirstDeposit = firstDeposit,
                GGR = ggr,
                UserStatus = userStatus
            };
        }

        /// <summary>
        /// Поиск даты первого депозита в карточке пользователя
        /// </summary>
        /// <returns></returns>
        public UserData FindFirstDepositDate()
        {
            string firstDepositDate = driver.FindElement(By.CssSelector("tbody td[name='col-Date']")).Text;
            return new UserData()
            {
                FirstDepositDate = firstDepositDate,
            };
        }

        /// <summary>
        /// Поиск суммы первого депозита в карточке пользователя 
        /// </summary>
        /// <returns></returns>
        public UserData FindFirstDeposit()
        {
            string firstDeposit = driver.FindElement(By.CssSelector("tbody td[name='col-Amount']")).Text;
            return new UserData()
            {
                FirstDeposit = firstDeposit,
            };
        }
    }
}
