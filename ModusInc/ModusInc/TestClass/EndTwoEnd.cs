using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using ModusInc.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ModusInc.PageObject;

namespace ModusInc.TestClass
{
    /// <summary>
    /// Summary description for EndTwoEnd
    /// </summary>
    [TestClass]
    public class EndTwoEnd
    {

        public static IWebDriver Browser { get; set; }
        public InputDataModel TestData { get; set; }
        public TestResult TestResult { get; set; }

        public EndTwoEnd()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            Browser = Util.Util.Login();

        }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            //mstest /testcontainer:[path of test dll file] /resultfile:testResults.trx
            TestResult = new TestResult();
            DataTable myTable = TestContext.DataRow.Table;
            string xml = Util.Util.ConvertDatatableToXML(myTable, TestContext.DataRow.Table.Rows.IndexOf(TestContext.DataRow));
            TestData = Util.Util.DeserializeXMLToObject<InputDataModel>(xml);

        }
        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {

        }
        //
        #endregion

        [TestMethod]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xls)};dbq=|DataDirectory|InputData\\EndToEnd.xls;defaultdir=.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=true", "data$", DataAccessMethod.Sequential)]
        public void endTwoEnd()
        {
            PageObjectBudget budget = new PageObjectBudget(Browser, TestData, TestResult);
            PageObjectReport report = new PageObjectReport(Browser, TestData, TestResult);
            budget.AddTransaction();
            report.NavigateToReport();

            report.NavigateToSpendingByCategory();


        }

        [TestMethod]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xls)};dbq=|DataDirectory|InputData\\AddBudgetTransaction.xls;defaultdir=.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=true", "data$", DataAccessMethod.Sequential)]
        public void AddBudgetTransaction()
        {
            PageObjectBudget budget = new PageObjectBudget(Browser, TestData, TestResult);
            budget.AddTransaction();
        }

        [TestMethod]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xls)};dbq=|DataDirectory|InputData\\DeleteExistingBudgetTransaction.xls;defaultdir=.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=true", "data$", DataAccessMethod.Sequential)]
        public void DeleteExistingBudgetTransaction()
        {
            PageObjectBudget budget = new PageObjectBudget(Browser, TestData, TestResult);
            budget.SearchForExistingTransactionByCategory();
            budget.DeleteTransaction();
        }

        [TestMethod]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xls)};dbq=|DataDirectory|InputData\\UpdateExistingBudgetTransaction.xls;defaultdir=.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=true", "data$", DataAccessMethod.Sequential)]
        public void UpdateExistingBudgetTransaction()
        {
            PageObjectBudget budget = new PageObjectBudget(Browser, TestData, TestResult);
            budget.SearchForExistingTransactionByCategory();
            budget.UpdateTransaction();
        }
    }
}
