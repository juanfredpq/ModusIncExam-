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

        public PageObjectBudget Budget { get; set; }

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
        public static void MyClassCleanup()
        {
            Browser.Close();
        }
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {          
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
        #endregion

        [TestMethod]
        [Description("This test add new transaction on the Budget page and then verify if the Inflow and flow are matching with the values")]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xls)};dbq=|DataDirectory|InputData\\EndToEnd.xls;defaultdir=.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=true", "data$", DataAccessMethod.Sequential), DeploymentItem("EndToEnd.xls")]
        public void endTwoEnd()
        {
            Budget = new PageObjectBudget(Browser, TestData, TestResult);
            PageObjectReport report = new PageObjectReport(Browser, TestData, TestResult);
            Budget.AddTransaction();
            report.NavigateToReport();
            bool actualResult = report.VerifyInflowChart();
            Budget.NavigageToBudget();
            Assert.IsTrue(actualResult, "Total InFlow value that is located in Budget page is not matching with the value InFlow located in Report page");
            
        }

        [TestMethod]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xls)};dbq=|DataDirectory|InputData\\AddBudgetTransaction.xls;defaultdir=.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=true", "data$", DataAccessMethod.Sequential), DeploymentItem("AddBudgetTransaction.xls")]
        public void AddBudgetTransaction()
        {
            PageObjectBudget budget = new PageObjectBudget(Browser, TestData, TestResult);
            budget.AddTransaction();
        }

        [TestMethod]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xls)};dbq=|DataDirectory|InputData\\DeleteExistingBudgetTransaction.xls;defaultdir=.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=true", "data$", DataAccessMethod.Sequential), DeploymentItem("DeleteExistingBudgetTransaction.xls")]
        public void DeleteExistingBudgetTransaction()
        {
            PageObjectBudget budget = new PageObjectBudget(Browser, TestData, TestResult);
            budget.SearchForExistingTransactionByCategory();
            budget.DeleteTransaction();
        }

        [TestMethod]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xls)};dbq=|DataDirectory|InputData\\UpdateExistingBudgetTransaction.xls;defaultdir=.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=true", "data$", DataAccessMethod.Sequential), DeploymentItem("UpdateExistingBudgetTransaction.xls")]
        public void UpdateExistingBudgetTransaction()
        {
            PageObjectBudget budget = new PageObjectBudget(Browser, TestData, TestResult);
            budget.SearchForExistingTransactionByCategory();
            budget.UpdateTransaction();

        }
    }
}
