using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModusInc.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.PageObjects;
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

        [FindsBy(How = How.CssSelector, Using = "main div a[href*='reports']")]
        public IWebElement ReportTab { get; set; }

        [FindsBy(How = How.CssSelector, Using = "main div a[href*='/reports/inflow-outflow']")]
        public IWebElement InflowVsOutFlow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "main div a[href*='/reports/spending']")]
        public IWebElement SpendingByCategory { get; set; }


        [FindsBy(How = How.CssSelector, Using = "main section div svg g g g:nth-child(1) text")]
        public IWebElement Inflow { get; set; }

        [FindsBy(How = How.CssSelector, Using = "main section div svg g g g:nth-child(2) text")]
        public IWebElement Outflow { get; set; }

        public PageObjectReport(IWebDriver driver, InputDataModel inputData, TestResult testResult)
        {
            PageFactory.InitElements(driver, this);
            this.InputDataModel = inputData;
            this.Browser = driver;
            this.TestResult = testResult;
        }

        public void VerifyInflowChart()
        {
            NavigateToReport();
            double CurrentInflowValue = double.Parse(Inflow.Text);
           // Assert.AreEqual(CurrentInflowValue, double.Parse())

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
