using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ModusInc.Model;

namespace ModusInc.DataAccess
{
    public class DataAccess
    {
        public DataAccess()
        {

        }       

        public static string TestDataFileConnection(string fileName)
        {
           // var fileName = ConfigurationManager.AppSettings["TestDataSheetPath"];
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }
        public static InputDataModel GetTestData(string keyName, string fileName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection(fileName)))
            {
                connection.Open();
                var query = string.Format("select * from [DataSet$] where key='{0}'", keyName);
                var value = connection.Query<InputDataModel>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}
