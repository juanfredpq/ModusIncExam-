using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Xml.Serialization;
using System.Xml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ModusInc.Util
{
    public static class Util
    {        

        public static string ConvertDatatableToXML(DataTable dt, int iteration)
        {
            MemoryStream str = new MemoryStream();
            dt.WriteXml(str, true);
            str.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(str);
            string xmlstr;
            xmlstr = sr.ReadToEnd();
            return GetXmlNodeListByName(xmlstr, iteration);
        }

        public static T DeserializeXMLToObject<T>(string XmlFilename)
        {
            T returnObject = default(T);
            if (string.IsNullOrEmpty(XmlFilename)) return default(T);

            try
            {
                StringReader stringReader = new StringReader(XmlFilename);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                returnObject = (T)serializer.Deserialize(stringReader);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnObject;
        }

        public static string GetXmlNodeListByName(string xmlString, int iteration)
        {
            string xmlNodeIteration = string.Empty;
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlString);
            XmlNodeList nodes = xml.GetElementsByTagName("data_x0024_");
            for (int i = 0; i < nodes.Count; i++)
            {
                if (i == iteration)
                {
                    xmlNodeIteration = nodes[i].OuterXml;
                    xmlNodeIteration = xmlNodeIteration.Replace("data_x0024_", "InputData");
                    return xmlNodeIteration;
                }
            }
            return xmlNodeIteration;
        }

        public static IWebDriver Login()
        {
            IWebDriver browser = new ChromeDriver();
            browser.Navigate().GoToUrl("https://budget.modus.app/budget");
            return browser;
        }

        public static void GenerateReport() {
            //TODO - TRX research again about this report generation
        }

    }
}
