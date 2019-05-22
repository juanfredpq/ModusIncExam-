using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModusInc.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
    public class PageObjectBudget
    {
        public TestResult TestResult { get; set; }
        public InputDataModel InputData { get; set; }
        public IWebDriver Browser { get; set; }
        /// <summary>
        /// It is a Select drowpDown field located into the Section footer that allow us to choose a Category.
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "select[name='categoryId']")]
        public IWebElement Category { get; set; }

        /// <summary>
        /// It is a input field located into the Section footer that allow us to insert a comment 
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "input[placeholder = 'Description']")]
        public IWebElement Description { get; set; }
        /// <summary>
        /// It is a input field located into the Section footer that allow us to insert a value
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "input[placeholder = 'Value']")]
        public IWebElement Value { get; set; }

        /// <summary>
        /// It is a button field located into the Section footer that allow us to add a budget transaction
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "tfoot button")]
        public IWebElement Add { get; set; }

        /// <summary>
        /// It is a button field located into the Section body that allow us to delete a budget transaction
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "tbody button[class*='delete']")]
        public IWebElement Delete { get; set; }

        /// <summary>
        /// It is a button field located into the Section body that allow us to update a budget transaction
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "tbody button[class*='submit']")]
        public IWebElement Update { get; set; }

        /// <summary>
        /// It is a button field located into the Section body that allow us to cancel a budget transaction
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "tbody button[class*='cancel']")]
        public IWebElement Cancel { get; set; }

        /// <summary>
        /// It is the Collection that retrieves the list of existing Budged transactions on the Section
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "section table tbody tr td div")]
        public IList<IWebElement> ExistingBudgetTransactions { get; set; }

        /// <summary>
        /// It is a field that displays the current Total Inflow in Budget page
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "div[id='root'] main section div div div:nth-child(1) div div")]
        public IWebElement TotalInflow { get; set; }

        /// <summary>
        /// It is a field that displays the current Total OutFlow in Budget page
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "div[id='root'] main section div div div:nth-child(3) div div")]
        public IWebElement TotalOutflow { get; set; }

        /// <summary>
        /// It is a field that displays the current Working Balance in Budget page
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "div[id='root'] main section div div div:nth-child(5) div div")]
        public IWebElement WorkingBalance { get; set; }

        /// <summary>
        /// It is the field that allow us to navigate to Budget page
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "main div a[href*='budget']")]
        public IWebElement BudgetTab { get; set; }

        public PageObjectBudget(IWebDriver driver, InputDataModel inputData, TestResult testResult)
        {
            PageFactory.InitElements(driver, this);
            this.InputData = inputData;
            this.TestResult = testResult;
            this.Browser = driver;
            InputData.composeBudget = new BudgetModel();
        }

        public void NavigageToBudget()
        {
            BudgetTab.Click();
        }

        public void AddTransaction()
        {
            try
            {
                SelectElement select = new SelectElement(Category);
                select.SelectByText(InputData.Category);
                Description.SendKeys(InputData.Description);
                Value.SendKeys(InputData.Amount);
                Add.Click();
                
                InputData.composeBudget.TotalInflow = double.Parse(TotalInflow.Text.Replace("$", ""));
                InputData.composeBudget.TotalOutflow = double.Parse(TotalOutflow.Text.Replace("$", ""));
                InputData.composeBudget.WorkingBalance = double.Parse(WorkingBalance.Text.Replace("$", ""));
            }
            catch (Exception e)
            {
                TestResult.Outcome = UnitTestOutcome.Failed;
            }

            // here we can create functionality of Baselines in order to insert data in a repository (DB) with the current build(that its in production)
            //and then once the new build( features, enhancements, etc) its deployed, we can execute our regression in verify mode in order to comparer
            //the results and see if there is difference in the functionality or such.

            //TODO - Talk this in the interview
        }

        public void DeleteTransaction()
        {
            Delete.Click();
        }

        public void UpdateTransaction()
        {
            SelectElement select = new SelectElement(Category);
            select.SelectByText(InputData.Category);
            Category.SendKeys(Keys.Tab);
            Description.SendKeys(InputData.Description);
            Description.SendKeys(Keys.Tab);
            Value.SendKeys(InputData.Amount);
            Update.Click();
        }

        public void SearchForExistingTransactionByCategory()
        {
            foreach (IWebElement element in ExistingBudgetTransactions)
            {
                if (element.Text.Equals(InputData.Category))
                {
                    element.Click();
                    break;
                }

            }
        }
    }
}
