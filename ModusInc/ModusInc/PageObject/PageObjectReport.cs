using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModusInc.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModusInc.PageObject
{
    public class PageObjectReport
    {
        public InputDataModel InputDataModel { get; set; }
        public IWebDriver Browser { get; set; }
        public TestResult TestResult { get; set; }

        /// <summary>
        /// It is field that allow us to access Report page
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "main div a[href*='reports']")]
        public IWebElement ReportTab { get; set; }

        /// <summary>
        /// It is a field that allow us to navigate to Inflow Vs OutFlow section
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "main div a[href*='/reports/inflow-outflow']")]
        public IWebElement InflowVsOutFlow { get; set; }

        /// <summary>
        /// It is a field that allow us to navigate to Spending by Category section
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "main div a[href*='/reports/spending']")]
        public IWebElement SpendingByCategory { get; set; }

        /// <summary>
        /// It is field that displays the current value of InFlow in Report page
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "main section div svg g g g:nth-child(1) text+text")]
        public IWebElement Inflow { get; set; }

        /// <summary>
        /// It is field that displays the current value of OutFlow in Report page
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "main section div svg g g g:nth-child(2) text+text")]
        public IWebElement Outflow { get; set; }

        public PageObjectReport(IWebDriver driver, InputDataModel inputData, TestResult testResult)
        {
            PageFactory.InitElements(driver, this);
            this.InputDataModel = inputData;
            this.Browser = driver;
            this.TestResult = testResult;
        }

        public bool VerifyInflowChart()
        {
            NavigateToReport();
            double p = double.Parse(Inflow.Text.Replace("$", "")) + InputDataModel.Difference;
            bool result = InputDataModel.composeBudget.TotalInflow.Equals(double.Parse(Inflow.Text.Replace("$",""))+ InputDataModel.Difference);            
            return result;
        }

        public void NavigateToReport()
        {
            ReportTab.Click();
        }

        public void NavigateToInflowVsOutFlow()
        {
            InflowVsOutFlow.Click();
        }

        public void NavigateToSpendingByCategory()
        {
            SpendingByCategory.Click();
        }
        
    }
}
