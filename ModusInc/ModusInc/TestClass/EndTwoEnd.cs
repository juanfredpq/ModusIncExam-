using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using ModusInc.Model;

namespace ModusInc.TestClass
{
    /// <summary>
    /// Summary description for EndTwoEnd
    /// </summary>
    [TestClass]
    public class EndTwoEnd
    {
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
            DataTable myTable = TestContext.DataRow.Table;
            string xml = Util.Util.ConvertDatatableToXML(myTable, TestContext.DataRow.Table.Rows.IndexOf(TestContext.DataRow));
            InputDataModel testData = Util.Util.DeserializeXMLFileToObject<InputDataModel>(xml);          

        }
        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        //[DataSource("System.Data.Odbc", @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =|DataDirectory|InputData\EndToEnd.xlsx;defaultdir=.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=true", "Sheet1$", DataAccessMethod.Sequential)]
        //[DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xls)};dbq=|DataDirectory|InputData\\EndToEnd.xlsx;defaultdir=.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=true", "Sheet1$", DataAccessMethod.Sequential)]
        //[DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xls)};dbq=|DataDirectory|InputData\\EndToEnd.xls;defaultdir=.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=true", "Sheet1$", DataAccessMethod.Sequential), DeploymentItem("Sheet1.xls")]
        // [DataSource("System.Data.OleDB", @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=|DataDirectory|InputData\EndToEnd.xls; Extended Properties='Excel 12.0;HDR=yes';",  "Sheet1$",  DataAccessMethod.Sequential), DeploymentItem("EndToEnd.xls")]
        // [DataSource("System.Data.OleDB", @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\TestData\EndToEnd.xls; Extended Properties='Excel 12.0;HDR=yes';",  "Sheet1$",  DataAccessMethod.Sequential)]
        // [DataSource("System.Data.OleDb", @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\TestData\EndToEnd.xls;Persist Security Info=False;Extended Properties=""Excel 12.0 Xml;HDR=YES""", "Sheet1$", DataAccessMethod.Sequential)]
        //[DataSource("System.Data.Odbc", @"Driver={Microsoft Excel Driver (*.xls)};DriverId=790;Dbq=C:\TestData\EndToEnd.xls;DefaultDir=.","data$", DataAccessMethod.Sequential)]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xls)};dbq=|DataDirectory|InputData\\EndToEnd.xls;defaultdir=.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=true", "data$", DataAccessMethod.Sequential)]
        public void endTwoEnd()
        {

        }
    }
}
