using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestFundist
{
    public class AffiliateData
    {
        public string AffiliateID { get; set; }
        public string LoginAndEmail {  get; set; }
        public string ReferalCode { get; set; }
        public string Country { get; set; }
        public string CommissionPlan { get; set; }
        public string UniqueVisitors { get; set; }
        public string Registration {  get; set; }
        public string ActivePlayers { get; set; }
        public string NumberOfDeposits { get; set; }
        public string AmountOfDepositsEUR { get; set; }
        public string NumberOfFirstDeposits { get; set; }
        public string AmountOfFirstDepositsEUR { get; set; }
        public string GGR { get; set; }
        public string NGR { get; set; }
        public string AdminFee { get; set; }
        public string BonusTurnovers { get; set; }
        public string ProfitCPA { get; set; }
        public string ProfitRS { get; set; }
        public string SubProfitCPA { get; set; }
        public string SubProfitRS { get; set; }

        public string SubProfitRevenue { get; set; }
        public string Profit {  get; set; }
        public string Withdraws { get; set; }
        public string Manual {  get; set; }

        public AffiliateData()
        {

        }
    }
}
