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
    public class UserData
    {
        public string UserID { get; set; }
        public string DateOfRegistration { get; set; }
        public string Country { get; set; }
        public string Campaign {  get; set; }
        public string TotalAmount { get; set; }
        public string DayAmount { get; set; }
        public string AmountOfFirstDeposits {  get; set; }
        public string GGR { get; set; }
        public string NGR { get; set; }
        public string AdminFee { get; set; }
        public string BonusTurnovers { get; set; }
        public string CPA { get; set; }
        public string RS { get; set; }
        public string ProcentFromCPA { get; set; }
        public string ProcentFromRS { get; set; }
        public string ProcentFromRevenue { get; set; }
        public string Profit { get; set; }
        public string Withdrawals { get; set; }
        public string FirstDepositDate { get; set; }
        public string FirstDeposit {  get; set; }
        public string UserStatus { get; set; }
        public UserData() 
        { 

        }
    }
}
